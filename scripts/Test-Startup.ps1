param([string]$Configuration = 'Release')
$ErrorActionPreference = 'Stop'
$root = Split-Path $PSScriptRoot -Parent
$exe = Join-Path $root "artifacts\bin\$Configuration\net472\TMFTool.exe"
New-Item -ItemType Directory -Path (Join-Path $root 'artifacts\tests') -Force | Out-Null
$runnerPath = Join-Path $root "artifacts\tests\StartupProbe.dll"
if (-not (Test-Path $runnerPath)) {
Add-Type -TypeDefinition @"
using System;
using System.Reflection;
using System.Windows.Forms;
public sealed class StartupProbe : MarshalByRefObject {
 public string Run(string exe) {
  try {
   Application.EnableVisualStyles();
   Application.SetCompatibleTextRenderingDefault(false);
   var assembly = Assembly.LoadFrom(exe);
   var lines = new System.Collections.Generic.List<string>();
   string[] types = { "qc.LoginFrom", "qc.Form1", "qc.Form3", "qc.Authe", "qc.AuthFrp", "qc.andform", "qc.Form5" };
   foreach (var name in types) {
    var type = assembly.GetType(name, true);
    var constructor = type.GetConstructors()[0];
    var parameters = constructor.GetParameters();
    object[] args = new object[parameters.Length];
    for (int i = 0; i < args.Length; i++)
     args[i] = parameters[i].ParameterType == typeof(string) ? (object)"" : Activator.CreateInstance(parameters[i].ParameterType);
    using (var form = (Form)constructor.Invoke(args)) {
     form.CreateControl();
     var handle = form.Handle;
     using (var image = new System.Drawing.Bitmap(form.Width, form.Height))
      form.DrawToBitmap(image, new System.Drawing.Rectangle(0, 0, form.Width, form.Height));
     lines.Add("PASS " + name + " handle=" + handle + " controls=" + form.Controls.Count);
    }
   }
   return string.Join(Environment.NewLine, lines);
  } catch (Exception e) { return "FAIL " + e; }
 }
}
"@ -ReferencedAssemblies System.Windows.Forms,System.Drawing -OutputAssembly $runnerPath
}
$setup = New-Object AppDomainSetup
$setup.ApplicationBase = Split-Path $exe -Parent
$setup.ConfigurationFile = $exe + '.config'
$domain = [AppDomain]::CreateDomain('TMFTool.StartupProbe', $null, $setup)
try {
 $probe = $domain.CreateInstanceFromAndUnwrap($runnerPath, 'StartupProbe')
 $runnerAssembly = [Reflection.Assembly]::LoadFrom($runnerPath)
 $result = $runnerAssembly.GetType('StartupProbe').GetMethod('Run').Invoke($probe, [object[]]@([string]$exe))
 $result
 if ($result.StartsWith('FAIL')) { exit 1 }
} finally { [AppDomain]::Unload($domain) }
