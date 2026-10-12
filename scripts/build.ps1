param(
    [ValidateSet('Debug', 'Release')][string]$Configuration = 'Release',
    [switch]$TestStartup,
    [switch]$Package
)
$ErrorActionPreference = 'Stop'
$root = Split-Path $PSScriptRoot -Parent
$logDirectory = Join-Path $root 'logs\build'
New-Item -ItemType Directory -Path $logDirectory -Force | Out-Null
$log = Join-Path $logDirectory ($Configuration.ToLowerInvariant() + '.log')
& dotnet build (Join-Path $root 'TMFTool.sln') -c $Configuration -t:Rebuild --nologo -v:minimal 2>&1 |
    Tee-Object -FilePath $log
if ($LASTEXITCODE -ne 0) { exit $LASTEXITCODE }
if ($TestStartup) {
    $testLog = Join-Path $logDirectory ('startup-' + $Configuration.ToLowerInvariant() + '.log')
    & "$env:SystemRoot\System32\WindowsPowerShell\v1.0\powershell.exe" -NoProfile -STA -ExecutionPolicy Bypass -File (Join-Path $PSScriptRoot 'Test-Startup.ps1') -Configuration $Configuration 2>&1 |
        Tee-Object -FilePath $testLog
    if ($LASTEXITCODE -ne 0) { exit $LASTEXITCODE }
}
if ($Package) {
    $output = Join-Path $root "artifacts\bin\$Configuration\net472"
    $archive = Join-Path $root "artifacts\TMFTool-$Configuration.zip"
    Compress-Archive -Path (Join-Path $output '*') -DestinationPath $archive -Force
    Write-Output "Package: $archive"
}
