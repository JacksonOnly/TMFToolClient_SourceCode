using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ChromeosUpdateEngine;
using Google.Protobuf;
using Ionic.BZip2;
using Ionic.Zip;
using ManagedXZ;

namespace WinFormsPayload;

public class Payload : IDisposable
{
	public class PayloadInitException : Exception
	{
		public PayloadInitException(string message)
			: base(message)
		{
		}
	}

	public class PayloadExtractionException : Exception
	{
		public PayloadExtractionException(string message)
			: base(message)
		{
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass14_0
	{
		public Payload _003C_003E4__this;

		public bool doSha256Check;

		public SHA256 sha256;

		public string which;

		public IProgress<(long writtenBytes, long totalBytes, string message)> progress;

		public bool ignore_unknown_op;

		public Func<InstallOperation, long> _003C_003E9__0 = default;

		internal long _1(InstallOperation op)
		{
			return (long)(op.DstExtents[0].NumBlocks * _003C_003E4__this.manifest.BlockSize);
		}
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass14_1
	{
		public string outFile;

		public long writtenBytes;

		public long totalBytes;

		public _003C_003Ec__DisplayClass14_0 CS_0024_003C_003E8__locals1;
	}

	[CompilerGenerated]
	private sealed class _003C_003Ec__DisplayClass14_2
	{
		public SemaphoreSlim semaphore;

		public _003C_003Ec__DisplayClass14_1 CS_0024_003C_003E8__locals2;

		internal async Task _1(InstallOperation installOperation)
		{
			await semaphore.WaitAsync();
			try
			{
				long num = (long)(installOperation.DstExtents[0].StartBlock * CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1._003C_003E4__this.manifest.BlockSize);
				long num2 = (long)(installOperation.DstExtents[0].NumBlocks * CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1._003C_003E4__this.manifest.BlockSize);
				((BinaryReader)CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1._003C_003E4__this.m_1).BaseStream.Seek(CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1._003C_003E4__this.a + (long)installOperation.DataOffset, SeekOrigin.Begin);
				object obj = ((BinaryReader)CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1._003C_003E4__this.m_1).ReadBytes((int)installOperation.DataLength);
				if (CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1.doSha256Check && installOperation.HasDataSha256Hash)
				{
					object inArray = CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1.sha256.ComputeHash((byte[])obj);
					if (Convert.ToBase64String((byte[])inArray) != installOperation.DataSha256Hash.ToBase64())
					{
						throw new PayloadExtractionException("Block hash check failed for partition " + CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1.which);
					}
				}
				switch (installOperation.Type)
				{
				case InstallOperation.Types.Type.Replace:
				{
					object obj2 = new FileStream(CS_0024_003C_003E8__locals2.outFile, FileMode.Open, FileAccess.Write, FileShare.Write, 81920, useAsync: true);
					try
					{
						((Stream)obj2).Seek(num, SeekOrigin.Begin);
						await ((Stream)obj2).WriteAsync((byte[])obj, 0, ((Array)obj).Length);
					}
					finally
					{
						((IDisposable)obj2)?.Dispose();
					}
					Interlocked.Add(ref CS_0024_003C_003E8__locals2.writtenBytes, ((Array)obj).Length);
					CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1.progress?.Report((CS_0024_003C_003E8__locals2.writtenBytes, CS_0024_003C_003E8__locals2.totalBytes, "[payload]导出 " + CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1.which + ".img : " + (string)CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1._003C_003E4__this._1(CS_0024_003C_003E8__locals2.writtenBytes) + " / " + (string)CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1._003C_003E4__this._1(CS_0024_003C_003E8__locals2.totalBytes)));
					break;
				}
				case InstallOperation.Types.Type.ReplaceBz:
				{
					object obj9 = new MemoryStream((byte[])obj);
					try
					{
						object obj10 = (object)new BZip2InputStream((Stream)obj9);
						try
						{
							object obj11 = new FileStream(CS_0024_003C_003E8__locals2.outFile, FileMode.Open, FileAccess.Write, FileShare.Write, 81920, useAsync: true);
							try
							{
								object obj12 = new byte[81920];
								((Stream)obj11).Seek(num, SeekOrigin.Begin);
								while (true)
								{
									int num6;
									nint num7 = (num6 = ((Stream)obj10).Read((byte[])obj12, 0, ((Array)obj12).Length));
									if (num6 <= 0)
									{
										break;
									}
									await ((Stream)obj11).WriteAsync((byte[])obj12, 0, (int)num7);
									num += num7;
									Interlocked.Add(ref CS_0024_003C_003E8__locals2.writtenBytes, num7);
									CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1.progress?.Report((CS_0024_003C_003E8__locals2.writtenBytes, CS_0024_003C_003E8__locals2.totalBytes, "[payload]导出 " + CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1.which + ".img : " + (string)CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1._003C_003E4__this._1(CS_0024_003C_003E8__locals2.writtenBytes) + " / " + (string)CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1._003C_003E4__this._1(CS_0024_003C_003E8__locals2.totalBytes)));
								}
							}
							finally
							{
								((IDisposable)obj11)?.Dispose();
							}
						}
						finally
						{
							((IDisposable)obj10)?.Dispose();
						}
					}
					finally
					{
						((IDisposable)obj9)?.Dispose();
					}
					break;
				}
				case InstallOperation.Types.Type.ReplaceXz:
				{
					object obj5 = new MemoryStream((byte[])obj);
					try
					{
						object obj6 = (object)new XZDecompressStream((Stream)obj5);
						try
						{
							object obj7 = new FileStream(CS_0024_003C_003E8__locals2.outFile, FileMode.Open, FileAccess.Write, FileShare.Write, 81920, useAsync: true);
							try
							{
								object obj8 = new byte[81920];
								((Stream)obj7).Seek(num, SeekOrigin.Begin);
								while (true)
								{
									int num6;
									nint num5 = (num6 = ((Stream)obj6).Read((byte[])obj8, 0, ((Array)obj8).Length));
									if (num6 <= 0)
									{
										break;
									}
									await ((Stream)obj7).WriteAsync((byte[])obj8, 0, (int)num5);
									num += num5;
									Interlocked.Add(ref CS_0024_003C_003E8__locals2.writtenBytes, num5);
									CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1.progress?.Report((CS_0024_003C_003E8__locals2.writtenBytes, CS_0024_003C_003E8__locals2.totalBytes, "[payload]导出 " + CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1.which + ".img : " + (string)CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1._003C_003E4__this._1(CS_0024_003C_003E8__locals2.writtenBytes) + " / " + (string)CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1._003C_003E4__this._1(CS_0024_003C_003E8__locals2.totalBytes)));
								}
							}
							finally
							{
								((IDisposable)obj7)?.Dispose();
							}
						}
						finally
						{
							((IDisposable)obj6)?.Dispose();
						}
					}
					finally
					{
						((IDisposable)obj5)?.Dispose();
					}
					break;
				}
				case InstallOperation.Types.Type.Zero:
				{
					object obj3 = new byte[81920];
					long num3 = num2;
					object obj4 = new FileStream(CS_0024_003C_003E8__locals2.outFile, FileMode.Open, FileAccess.Write, FileShare.Write, 81920, useAsync: true);
					try
					{
						((Stream)obj4).Seek(num, SeekOrigin.Begin);
						while (num3 > 0)
						{
							nint num4 = (int)Math.Min(((Array)obj3).Length, num3);
							await ((Stream)obj4).WriteAsync((byte[])obj3, 0, (int)num4);
							num3 -= num4;
							num += num4;
							Interlocked.Add(ref CS_0024_003C_003E8__locals2.writtenBytes, num4);
							CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1.progress?.Report((CS_0024_003C_003E8__locals2.writtenBytes, CS_0024_003C_003E8__locals2.totalBytes, "[payload]导出 " + CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1.which + ".img : " + (string)CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1._003C_003E4__this._1(CS_0024_003C_003E8__locals2.writtenBytes) + " / " + (string)CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1._003C_003E4__this._1(CS_0024_003C_003E8__locals2.totalBytes)));
						}
					}
					finally
					{
						((IDisposable)obj4)?.Dispose();
					}
					break;
				}
				default:
					if (!CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1.ignore_unknown_op)
					{
						throw new PayloadExtractionException("Unknown action type " + installOperation.Type);
					}
					break;
				}
			}
			finally
			{
				semaphore.Release();
			}
		}
	}

	private object _0;

	private object m_1;

	private const string _2 = "";

	public ulong file_format_version;

	public ulong manifest_size;

	public uint metadata_signature_size;

	public DeltaArchiveManifest manifest;

	public Signatures metadata_signature_message;

	public ulong payload_signatures_message_size;

	public Signatures payload_signatures_message;

	private long a;

	public ulong data_size;

	public async Task<PayloadExtractionException> ExtractAsync(string which, string path, bool ignore_unknown_op, bool doSha256Check, IProgress<(long writtenBytes, long totalBytes, string message)> progress = null, Action<string> logAction = null, bool autoThreads = true, int maxThreads = 128)
	{
		object obj = new _003C_003Ec__DisplayClass14_0();
		((_003C_003Ec__DisplayClass14_0)obj)._003C_003E4__this = this;
		((_003C_003Ec__DisplayClass14_0)obj).doSha256Check = doSha256Check;
		((_003C_003Ec__DisplayClass14_0)obj).which = which;
		((_003C_003Ec__DisplayClass14_0)obj).progress = progress;
		((_003C_003Ec__DisplayClass14_0)obj).ignore_unknown_op = ignore_unknown_op;
		((_003C_003Ec__DisplayClass14_0)obj).sha256 = SHA256.Create();
		object enumerator = manifest.Partitions.GetEnumerator();
		try
		{
			while (((IEnumerator)enumerator).MoveNext())
			{
				object current = ((IEnumerator<PartitionUpdate>)enumerator).Current;
				object obj2 = new _003C_003Ec__DisplayClass14_1();
				((_003C_003Ec__DisplayClass14_1)obj2).CS_0024_003C_003E8__locals1 = (_003C_003Ec__DisplayClass14_0)obj;
				if (((PartitionUpdate)current).PartitionName != ((_003C_003Ec__DisplayClass14_1)obj2).CS_0024_003C_003E8__locals1.which)
				{
					continue;
				}
				((_003C_003Ec__DisplayClass14_1)obj2).outFile = Path.Combine(path, ((_003C_003Ec__DisplayClass14_1)obj2).CS_0024_003C_003E8__locals1.which + ".img");
				((_003C_003Ec__DisplayClass14_1)obj2).totalBytes = ((IEnumerable<InstallOperation>)((PartitionUpdate)current).Operations).Sum((InstallOperation op) => (long)(op.DstExtents[0].NumBlocks * ((_003C_003Ec__DisplayClass14_1)obj2).CS_0024_003C_003E8__locals1._003C_003E4__this.manifest.BlockSize));
				((_003C_003Ec__DisplayClass14_1)obj2).writtenBytes = 0L;
				logAction?.Invoke("[Payload]导出 " + ((_003C_003Ec__DisplayClass14_1)obj2).CS_0024_003C_003E8__locals1.which + " 分区...");
				object obj3 = new FileStream(((_003C_003Ec__DisplayClass14_1)obj2).outFile, FileMode.Create, FileAccess.Write, FileShare.None);
				try
				{
					((Stream)obj3).SetLength(((_003C_003Ec__DisplayClass14_1)obj2).totalBytes);
				}
				finally
				{
					((IDisposable)obj3)?.Dispose();
				}
				nint num = (autoThreads ? ((PartitionUpdate)current).Operations.Count : maxThreads);
				object CS_0024_003C_003E8__locals55 = new _003C_003Ec__DisplayClass14_2();
				((_003C_003Ec__DisplayClass14_2)CS_0024_003C_003E8__locals55).CS_0024_003C_003E8__locals2 = (_003C_003Ec__DisplayClass14_1)obj2;
				((_003C_003Ec__DisplayClass14_2)CS_0024_003C_003E8__locals55).semaphore = new SemaphoreSlim((int)num);
				try
				{
					object tasks = ((IEnumerable<InstallOperation>)((PartitionUpdate)current).Operations).Select((Func<InstallOperation, Task>)(async (InstallOperation installOperation) =>
					{
						await ((_003C_003Ec__DisplayClass14_2)CS_0024_003C_003E8__locals55).semaphore.WaitAsync();
						try
						{
							long num2 = (long)(installOperation.DstExtents[0].StartBlock * ((_003C_003Ec__DisplayClass14_2)CS_0024_003C_003E8__locals55).CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1._003C_003E4__this.manifest.BlockSize);
							long num3 = (long)(installOperation.DstExtents[0].NumBlocks * ((_003C_003Ec__DisplayClass14_2)CS_0024_003C_003E8__locals55).CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1._003C_003E4__this.manifest.BlockSize);
							((BinaryReader)((_003C_003Ec__DisplayClass14_2)CS_0024_003C_003E8__locals55).CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1._003C_003E4__this.m_1).BaseStream.Seek(((_003C_003Ec__DisplayClass14_2)CS_0024_003C_003E8__locals55).CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1._003C_003E4__this.a + (long)installOperation.DataOffset, SeekOrigin.Begin);
							object obj6 = ((BinaryReader)((_003C_003Ec__DisplayClass14_2)CS_0024_003C_003E8__locals55).CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1._003C_003E4__this.m_1).ReadBytes((int)installOperation.DataLength);
							if (((_003C_003Ec__DisplayClass14_2)CS_0024_003C_003E8__locals55).CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1.doSha256Check && installOperation.HasDataSha256Hash)
							{
								object inArray2 = ((_003C_003Ec__DisplayClass14_2)CS_0024_003C_003E8__locals55).CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1.sha256.ComputeHash((byte[])obj6);
								if (Convert.ToBase64String((byte[])inArray2) != installOperation.DataSha256Hash.ToBase64())
								{
									throw new PayloadExtractionException("Block hash check failed for partition " + ((_003C_003Ec__DisplayClass14_2)CS_0024_003C_003E8__locals55).CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1.which);
								}
							}
							switch (installOperation.Type)
							{
							case InstallOperation.Types.Type.Replace:
							{
								object obj7 = new FileStream(((_003C_003Ec__DisplayClass14_2)CS_0024_003C_003E8__locals55).CS_0024_003C_003E8__locals2.outFile, FileMode.Open, FileAccess.Write, FileShare.Write, 81920, useAsync: true);
								try
								{
									((Stream)obj7).Seek(num2, SeekOrigin.Begin);
									await ((Stream)obj7).WriteAsync((byte[])obj6, 0, ((Array)obj6).Length);
								}
								finally
								{
									((IDisposable)obj7)?.Dispose();
								}
								Interlocked.Add(ref ((_003C_003Ec__DisplayClass14_2)CS_0024_003C_003E8__locals55).CS_0024_003C_003E8__locals2.writtenBytes, ((Array)obj6).Length);
								((_003C_003Ec__DisplayClass14_2)CS_0024_003C_003E8__locals55).CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1.progress?.Report((((_003C_003Ec__DisplayClass14_2)CS_0024_003C_003E8__locals55).CS_0024_003C_003E8__locals2.writtenBytes, ((_003C_003Ec__DisplayClass14_2)CS_0024_003C_003E8__locals55).CS_0024_003C_003E8__locals2.totalBytes, "[payload]导出 " + ((_003C_003Ec__DisplayClass14_2)CS_0024_003C_003E8__locals55).CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1.which + ".img : " + (string)((_003C_003Ec__DisplayClass14_2)CS_0024_003C_003E8__locals55).CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1._003C_003E4__this._1(((_003C_003Ec__DisplayClass14_2)CS_0024_003C_003E8__locals55).CS_0024_003C_003E8__locals2.writtenBytes) + " / " + (string)((_003C_003Ec__DisplayClass14_2)CS_0024_003C_003E8__locals55).CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1._003C_003E4__this._1(((_003C_003Ec__DisplayClass14_2)CS_0024_003C_003E8__locals55).CS_0024_003C_003E8__locals2.totalBytes)));
								break;
							}
							case InstallOperation.Types.Type.ReplaceBz:
							{
								object obj14 = new MemoryStream((byte[])obj6);
								try
								{
									object obj15 = (object)new BZip2InputStream((Stream)obj14);
									try
									{
										object obj16 = new FileStream(((_003C_003Ec__DisplayClass14_2)CS_0024_003C_003E8__locals55).CS_0024_003C_003E8__locals2.outFile, FileMode.Open, FileAccess.Write, FileShare.Write, 81920, useAsync: true);
										try
										{
											object obj17 = new byte[81920];
											((Stream)obj16).Seek(num2, SeekOrigin.Begin);
											while (true)
											{
												int num7;
												nint num8 = (num7 = ((Stream)obj15).Read((byte[])obj17, 0, ((Array)obj17).Length));
												if (num7 <= 0)
												{
													break;
												}
												await ((Stream)obj16).WriteAsync((byte[])obj17, 0, (int)num8);
												num2 += num8;
												Interlocked.Add(ref ((_003C_003Ec__DisplayClass14_2)CS_0024_003C_003E8__locals55).CS_0024_003C_003E8__locals2.writtenBytes, num8);
												((_003C_003Ec__DisplayClass14_2)CS_0024_003C_003E8__locals55).CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1.progress?.Report((((_003C_003Ec__DisplayClass14_2)CS_0024_003C_003E8__locals55).CS_0024_003C_003E8__locals2.writtenBytes, ((_003C_003Ec__DisplayClass14_2)CS_0024_003C_003E8__locals55).CS_0024_003C_003E8__locals2.totalBytes, "[payload]导出 " + ((_003C_003Ec__DisplayClass14_2)CS_0024_003C_003E8__locals55).CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1.which + ".img : " + (string)((_003C_003Ec__DisplayClass14_2)CS_0024_003C_003E8__locals55).CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1._003C_003E4__this._1(((_003C_003Ec__DisplayClass14_2)CS_0024_003C_003E8__locals55).CS_0024_003C_003E8__locals2.writtenBytes) + " / " + (string)((_003C_003Ec__DisplayClass14_2)CS_0024_003C_003E8__locals55).CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1._003C_003E4__this._1(((_003C_003Ec__DisplayClass14_2)CS_0024_003C_003E8__locals55).CS_0024_003C_003E8__locals2.totalBytes)));
											}
										}
										finally
										{
											((IDisposable)obj16)?.Dispose();
										}
									}
									finally
									{
										((IDisposable)obj15)?.Dispose();
									}
								}
								finally
								{
									((IDisposable)obj14)?.Dispose();
								}
								break;
							}
							case InstallOperation.Types.Type.ReplaceXz:
							{
								object obj10 = new MemoryStream((byte[])obj6);
								try
								{
									object obj11 = (object)new XZDecompressStream((Stream)obj10);
									try
									{
										object obj12 = new FileStream(((_003C_003Ec__DisplayClass14_2)CS_0024_003C_003E8__locals55).CS_0024_003C_003E8__locals2.outFile, FileMode.Open, FileAccess.Write, FileShare.Write, 81920, useAsync: true);
										try
										{
											object obj13 = new byte[81920];
											((Stream)obj12).Seek(num2, SeekOrigin.Begin);
											while (true)
											{
												int num7;
												nint num6 = (num7 = ((Stream)obj11).Read((byte[])obj13, 0, ((Array)obj13).Length));
												if (num7 <= 0)
												{
													break;
												}
												await ((Stream)obj12).WriteAsync((byte[])obj13, 0, (int)num6);
												num2 += num6;
												Interlocked.Add(ref ((_003C_003Ec__DisplayClass14_2)CS_0024_003C_003E8__locals55).CS_0024_003C_003E8__locals2.writtenBytes, num6);
												((_003C_003Ec__DisplayClass14_2)CS_0024_003C_003E8__locals55).CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1.progress?.Report((((_003C_003Ec__DisplayClass14_2)CS_0024_003C_003E8__locals55).CS_0024_003C_003E8__locals2.writtenBytes, ((_003C_003Ec__DisplayClass14_2)CS_0024_003C_003E8__locals55).CS_0024_003C_003E8__locals2.totalBytes, "[payload]导出 " + ((_003C_003Ec__DisplayClass14_2)CS_0024_003C_003E8__locals55).CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1.which + ".img : " + (string)((_003C_003Ec__DisplayClass14_2)CS_0024_003C_003E8__locals55).CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1._003C_003E4__this._1(((_003C_003Ec__DisplayClass14_2)CS_0024_003C_003E8__locals55).CS_0024_003C_003E8__locals2.writtenBytes) + " / " + (string)((_003C_003Ec__DisplayClass14_2)CS_0024_003C_003E8__locals55).CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1._003C_003E4__this._1(((_003C_003Ec__DisplayClass14_2)CS_0024_003C_003E8__locals55).CS_0024_003C_003E8__locals2.totalBytes)));
											}
										}
										finally
										{
											((IDisposable)obj12)?.Dispose();
										}
									}
									finally
									{
										((IDisposable)obj11)?.Dispose();
									}
								}
								finally
								{
									((IDisposable)obj10)?.Dispose();
								}
								break;
							}
							case InstallOperation.Types.Type.Zero:
							{
								object obj8 = new byte[81920];
								long num4 = num3;
								object obj9 = new FileStream(((_003C_003Ec__DisplayClass14_2)CS_0024_003C_003E8__locals55).CS_0024_003C_003E8__locals2.outFile, FileMode.Open, FileAccess.Write, FileShare.Write, 81920, useAsync: true);
								try
								{
									((Stream)obj9).Seek(num2, SeekOrigin.Begin);
									while (num4 > 0)
									{
										nint num5 = (int)Math.Min(((Array)obj8).Length, num4);
										await ((Stream)obj9).WriteAsync((byte[])obj8, 0, (int)num5);
										num4 -= num5;
										num2 += num5;
										Interlocked.Add(ref ((_003C_003Ec__DisplayClass14_2)CS_0024_003C_003E8__locals55).CS_0024_003C_003E8__locals2.writtenBytes, num5);
										((_003C_003Ec__DisplayClass14_2)CS_0024_003C_003E8__locals55).CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1.progress?.Report((((_003C_003Ec__DisplayClass14_2)CS_0024_003C_003E8__locals55).CS_0024_003C_003E8__locals2.writtenBytes, ((_003C_003Ec__DisplayClass14_2)CS_0024_003C_003E8__locals55).CS_0024_003C_003E8__locals2.totalBytes, "[payload]导出 " + ((_003C_003Ec__DisplayClass14_2)CS_0024_003C_003E8__locals55).CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1.which + ".img : " + (string)((_003C_003Ec__DisplayClass14_2)CS_0024_003C_003E8__locals55).CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1._003C_003E4__this._1(((_003C_003Ec__DisplayClass14_2)CS_0024_003C_003E8__locals55).CS_0024_003C_003E8__locals2.writtenBytes) + " / " + (string)((_003C_003Ec__DisplayClass14_2)CS_0024_003C_003E8__locals55).CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1._003C_003E4__this._1(((_003C_003Ec__DisplayClass14_2)CS_0024_003C_003E8__locals55).CS_0024_003C_003E8__locals2.totalBytes)));
									}
								}
								finally
								{
									((IDisposable)obj9)?.Dispose();
								}
								break;
							}
							default:
								if (!((_003C_003Ec__DisplayClass14_2)CS_0024_003C_003E8__locals55).CS_0024_003C_003E8__locals2.CS_0024_003C_003E8__locals1.ignore_unknown_op)
								{
									throw new PayloadExtractionException("Unknown action type " + installOperation.Type);
								}
								break;
							}
						}
						finally
						{
							((_003C_003Ec__DisplayClass14_2)CS_0024_003C_003E8__locals55).semaphore.Release();
						}
					})).ToArray();
					try
					{
						await Task.WhenAll((Task[])tasks);
					}
					catch (PayloadExtractionException ex)
					{
						object obj4 = ex;
						logAction?.Invoke(((Exception)obj4).Message);
						return (PayloadExtractionException)obj4;
					}
				}
				finally
				{
					if (((_003C_003Ec__DisplayClass14_2)CS_0024_003C_003E8__locals55).semaphore != null)
					{
						((IDisposable)((_003C_003Ec__DisplayClass14_2)CS_0024_003C_003E8__locals55).semaphore).Dispose();
					}
				}
				if (((_003C_003Ec__DisplayClass14_1)obj2).CS_0024_003C_003E8__locals1.doSha256Check && (((PartitionUpdate)current).NewPartitionInfo?.HasHash ?? false))
				{
					object obj5 = new FileStream(((_003C_003Ec__DisplayClass14_1)obj2).outFile, FileMode.Open, FileAccess.Read, FileShare.Read);
					try
					{
						object inArray = ((_003C_003Ec__DisplayClass14_1)obj2).CS_0024_003C_003E8__locals1.sha256.ComputeHash((Stream)obj5);
						if (Convert.ToBase64String((byte[])inArray) != ((PartitionUpdate)current).NewPartitionInfo.Hash.ToBase64())
						{
							logAction?.Invoke("校验 " + ((_003C_003Ec__DisplayClass14_1)obj2).CS_0024_003C_003E8__locals1.which + " 失败！\n");
							return new PayloadExtractionException("Final image hash check failed");
						}
					}
					finally
					{
						((IDisposable)obj5)?.Dispose();
					}
				}
				logAction?.Invoke("OK\n");
				if (((_003C_003Ec__DisplayClass14_1)obj2).CS_0024_003C_003E8__locals1.doSha256Check)
				{
					logAction?.Invoke("校验Sha256 " + ((_003C_003Ec__DisplayClass14_1)obj2).CS_0024_003C_003E8__locals1.which + " 分区...OK\n");
				}
				return null;
			}
		}
		finally
		{
			((IDisposable)enumerator)?.Dispose();
		}
		return new PayloadExtractionException("Unable to find target partition");
	}

	private object _1(long bytes)
	{
		string[] array = new string[9] { "B", "KB", "MB", "GB", "TB", "PB", "EB", "ZB", "YB" };
		int num = 0;
		double num2 = bytes;
		while (num2 >= 1024.0 && num < array.Length - 1)
		{
			num2 /= 1024.0;
			num++;
		}
		return $"{num2:0.##} {array[num]}";
	}

	public PayloadInitException init()
	{
		try
		{
			if (Encoding.ASCII.GetString(((BinaryReader)this.m_1).ReadBytes(4)) != "CrAU")
			{
				return new PayloadInitException("Magic mismatch");
			}
			file_format_version = BitConverter.ToUInt64(((BinaryReader)this.m_1).ReadBytes(8).Reverse().ToArray(), 0);
			if (file_format_version < 2)
			{
				return new PayloadInitException("format version 1 is not supported");
			}
			manifest_size = BitConverter.ToUInt64(((BinaryReader)this.m_1).ReadBytes(8).Reverse().ToArray(), 0);
			metadata_signature_size = BitConverter.ToUInt32(((BinaryReader)this.m_1).ReadBytes(4).Reverse().ToArray(), 0);
			if (manifest_size > int.MaxValue)
			{
				return new PayloadInitException("manifest_size overflowed");
			}
			manifest = new MessageParser<DeltaArchiveManifest>((Func<DeltaArchiveManifest>)(() => new DeltaArchiveManifest())).ParseFrom(((BinaryReader)this.m_1).ReadBytes((int)manifest_size));
			if (metadata_signature_size > int.MaxValue)
			{
				return new PayloadInitException("metadata_signature_size overflowed");
			}
			metadata_signature_message = new MessageParser<Signatures>((Func<Signatures>)(() => new Signatures())).ParseFrom(((BinaryReader)this.m_1).ReadBytes((int)metadata_signature_size));
			a = ((BinaryReader)this.m_1).BaseStream.Position;
			data_size = manifest.SignaturesOffset;
			((BinaryReader)this.m_1).BaseStream.Seek((long)manifest.SignaturesOffset, SeekOrigin.Current);
			payload_signatures_message_size = manifest.SignaturesSize;
			if (payload_signatures_message_size > int.MaxValue)
			{
				return new PayloadInitException("payload_signatures_message_size overflowed");
			}
			payload_signatures_message = new MessageParser<Signatures>((Func<Signatures>)(() => new Signatures())).ParseFrom(((BinaryReader)this.m_1).ReadBytes((int)payload_signatures_message_size));
		}
		catch (Exception ex)
		{
			return new PayloadInitException(ex.Message);
		}
		return null;
	}

	public void Dispose()
	{
		((BinaryReader)this.m_1)?.Close();
		try
		{
			if (Directory.Exists((string)_0))
			{
				new DirectoryInfo((string)_0).Delete(recursive: true);
			}
		}
		catch
		{
		}
	}

	public Payload(string path, string tmpdir)
	{
		//IL_0024: Unknown result type (might be due to invalid IL or missing references)
		//IL_002a: Expected Obj, but got Unknown
		_0 = tmpdir;
		if (path.EndsWith(".zip", StringComparison.OrdinalIgnoreCase))
		{
			ZipFile val = new ZipFile(path);
			foreach (ZipEntry entry in val.Entries)
			{
				if (entry.FileName.Equals("payload.bin", StringComparison.OrdinalIgnoreCase))
				{
					entry.Extract((string)_0);
					this.m_1 = new BinaryReader(new FileStream(Path.Combine((string)_0, "payload.bin"), FileMode.Open));
					return;
				}
			}
			throw new Exception("Unable to find entry for payload.bin");
		}
		this.m_1 = new BinaryReader(new FileStream(path, FileMode.Open));
	}
}
