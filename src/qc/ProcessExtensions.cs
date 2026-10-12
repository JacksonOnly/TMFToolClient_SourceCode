using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace qc;

public static class ProcessExtensions
{
	public static Task WaitForExitAsync(this Process process, int millisecondsTimeout = -1)
	{
		TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>();
		process.EnableRaisingEvents = true;
		process.Exited += (object sender, EventArgs args) =>
		{
			tcs.TrySetResult(result: true);
		};
		if (millisecondsTimeout != -1)
		{
			new CancellationTokenSource(millisecondsTimeout).Token.Register(() =>
			{
				tcs.TrySetCanceled();
			});
		}
		return tcs.Task;
	}
}
