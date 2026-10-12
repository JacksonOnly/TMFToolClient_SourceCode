using System;
using Google.Protobuf;
using Google.Protobuf.Reflection;

namespace ChromeosUpdateEngine;

public static class UpdateMetadataReflection
{
	private static object _0;

	public static FileDescriptor Descriptor => (FileDescriptor)_0;

	static UpdateMetadataReflection()
	{
		//IL_0261: Unknown result type (might be due to invalid IL or missing references)
		//IL_0267: Expected Obj, but got Unknown
		//IL_02c2: Unknown result type (might be due to invalid IL or missing references)
		//IL_02c8: Expected Obj, but got Unknown
		//IL_02c8: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ce: Expected Obj, but got Unknown
		//IL_02f9: Unknown result type (might be due to invalid IL or missing references)
		//IL_02ff: Expected Obj, but got Unknown
		//IL_034a: Unknown result type (might be due to invalid IL or missing references)
		//IL_0350: Expected Obj, but got Unknown
		//IL_03c6: Unknown result type (might be due to invalid IL or missing references)
		//IL_03cc: Expected Obj, but got Unknown
		//IL_046f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0475: Expected Obj, but got Unknown
		//IL_04a8: Unknown result type (might be due to invalid IL or missing references)
		//IL_04ae: Expected Obj, but got Unknown
		//IL_04d9: Unknown result type (might be due to invalid IL or missing references)
		//IL_04df: Expected Obj, but got Unknown
		//IL_0579: Unknown result type (might be due to invalid IL or missing references)
		//IL_057f: Expected Obj, but got Unknown
		//IL_057f: Unknown result type (might be due to invalid IL or missing references)
		//IL_0589: Expected Obj, but got Unknown
		byte[] array = Convert.FromBase64String("ChV1cGRhdGVfbWV0YWRhdGEucHJvdG8SFmNocm9tZW9zX3VwZGF0ZV9lbmdp" + "bmUiMQoGRXh0ZW50EhMKC3N0YXJ0X2Jsb2NrGAEgASgEEhIKCm51bV9ibG9j" + "a3MYAiABKAQinwEKClNpZ25hdHVyZXMSQAoKc2lnbmF0dXJlcxgBIAMoCzIs" + "LmNocm9tZW9zX3VwZGF0ZV9lbmdpbmUuU2lnbmF0dXJlcy5TaWduYXR1cmUa" + "TwoJU2lnbmF0dXJlEhMKB3ZlcnNpb24YASABKA1CAhgBEgwKBGRhdGEYAiAB" + "KAwSHwoXdW5wYWRkZWRfc2lnbmF0dXJlX3NpemUYAyABKAciKwoNUGFydGl0" + "aW9uSW5mbxIMCgRzaXplGAEgASgEEgwKBGhhc2gYAiABKAwidwoJSW1hZ2VJ" + "bmZvEg0KBWJvYXJkGAEgASgJEgsKA2tleRgCIAEoCRIPCgdjaGFubmVsGAMg" + "ASgJEg8KB3ZlcnNpb24YBCABKAkSFQoNYnVpbGRfY2hhbm5lbBgFIAEoCRIV" + "Cg1idWlsZF92ZXJzaW9uGAYgASgJIu4DChBJbnN0YWxsT3BlcmF0aW9uEjsK" + "BHR5cGUYASACKA4yLS5jaHJvbWVvc191cGRhdGVfZW5naW5lLkluc3RhbGxP" + "cGVyYXRpb24uVHlwZRITCgtkYXRhX29mZnNldBgCIAEoBBITCgtkYXRhX2xl" + "bmd0aBgDIAEoBBIzCgtzcmNfZXh0ZW50cxgEIAMoCzIeLmNocm9tZW9zX3Vw" + "ZGF0ZV9lbmdpbmUuRXh0ZW50EhIKCnNyY19sZW5ndGgYBSABKAQSMwoLZHN0" + "X2V4dGVudHMYBiADKAsyHi5jaHJvbWVvc191cGRhdGVfZW5naW5lLkV4dGVu" + "dBISCgpkc3RfbGVuZ3RoGAcgASgEEhgKEGRhdGFfc2hhMjU2X2hhc2gYCCAB" + "KAwSFwoPc3JjX3NoYTI1Nl9oYXNoGAkgASgMIq0BCgRUeXBlEgsKB1JFUExB" + "Q0UQABIOCgpSRVBMQUNFX0JaEAESDAoETU9WRRACGgIIARIOCgZCU0RJRkYQ" + "AxoCCAESDwoLU09VUkNFX0NPUFkQBBIRCg1TT1VSQ0VfQlNESUZGEAUSDgoK" + "UkVQTEFDRV9YWhAIEggKBFpFUk8QBhILCgdESVNDQVJEEAcSEQoNQlJPVExJ" + "X0JTRElGRhAKEgwKCFBVRkZESUZGEAki1wUKD1BhcnRpdGlvblVwZGF0ZRIW" + "Cg5wYXJ0aXRpb25fbmFtZRgBIAIoCRIXCg9ydW5fcG9zdGluc3RhbGwYAiAB" + "KAgSGAoQcG9zdGluc3RhbGxfcGF0aBgDIAEoCRIXCg9maWxlc3lzdGVtX3R5" + "cGUYBCABKAkSTQoXbmV3X3BhcnRpdGlvbl9zaWduYXR1cmUYBSADKAsyLC5j" + "aHJvbWVvc191cGRhdGVfZW5naW5lLlNpZ25hdHVyZXMuU2lnbmF0dXJlEkEK" + "Em9sZF9wYXJ0aXRpb25faW5mbxgGIAEoCzIlLmNocm9tZW9zX3VwZGF0ZV9l" + "bmdpbmUuUGFydGl0aW9uSW5mbxJBChJuZXdfcGFydGl0aW9uX2luZm8YByAB" + "KAsyJS5jaHJvbWVvc191cGRhdGVfZW5naW5lLlBhcnRpdGlvbkluZm8SPAoK" + "b3BlcmF0aW9ucxgIIAMoCzIoLmNocm9tZW9zX3VwZGF0ZV9lbmdpbmUuSW5z" + "dGFsbE9wZXJhdGlvbhIcChRwb3N0aW5zdGFsbF9vcHRpb25hbBgJIAEoCBI9" + "ChVoYXNoX3RyZWVfZGF0YV9leHRlbnQYCiABKAsyHi5jaHJvbWVvc191cGRh" + "dGVfZW5naW5lLkV4dGVudBI4ChBoYXNoX3RyZWVfZXh0ZW50GAsgASgLMh4u" + "Y2hyb21lb3NfdXBkYXRlX2VuZ2luZS5FeHRlbnQSGwoTaGFzaF90cmVlX2Fs" + "Z29yaXRobRgMIAEoCRIWCg5oYXNoX3RyZWVfc2FsdBgNIAEoDBI3Cg9mZWNf" + "ZGF0YV9leHRlbnQYDiABKAsyHi5jaHJvbWVvc191cGRhdGVfZW5naW5lLkV4" + "dGVudBIyCgpmZWNfZXh0ZW50GA8gASgLMh4uY2hyb21lb3NfdXBkYXRlX2Vu" + "Z2luZS5FeHRlbnQSFAoJZmVjX3Jvb3RzGBAgASgNOgEyIkwKFUR5bmFtaWNQ" + "YXJ0aXRpb25Hcm91cBIMCgRuYW1lGAEgAigJEgwKBHNpemUYAiABKAQSFwoP" + "cGFydGl0aW9uX25hbWVzGAMgAygJInMKGER5bmFtaWNQYXJ0aXRpb25NZXRh" + "ZGF0YRI9CgZncm91cHMYASADKAsyLS5jaHJvbWVvc191cGRhdGVfZW5naW5l" + "LkR5bmFtaWNQYXJ0aXRpb25Hcm91cBIYChBzbmFwc2hvdF9lbmFibGVkGAIg" + "ASgIIrEGChREZWx0YUFyY2hpdmVNYW5pZmVzdBJEChJpbnN0YWxsX29wZXJh" + "dGlvbnMYASADKAsyKC5jaHJvbWVvc191cGRhdGVfZW5naW5lLkluc3RhbGxP" + "cGVyYXRpb24SSwoZa2VybmVsX2luc3RhbGxfb3BlcmF0aW9ucxgCIAMoCzIo" + "LmNocm9tZW9zX3VwZGF0ZV9lbmdpbmUuSW5zdGFsbE9wZXJhdGlvbhIYCgpi" + "bG9ja19zaXplGAMgASgNOgQ0MDk2EhkKEXNpZ25hdHVyZXNfb2Zmc2V0GAQg" + "ASgEEhcKD3NpZ25hdHVyZXNfc2l6ZRgFIAEoBBI+Cg9vbGRfa2VybmVsX2lu" + "Zm8YBiABKAsyJS5jaHJvbWVvc191cGRhdGVfZW5naW5lLlBhcnRpdGlvbklu" + "Zm8SPgoPbmV3X2tlcm5lbF9pbmZvGAcgASgLMiUuY2hyb21lb3NfdXBkYXRl" + "X2VuZ2luZS5QYXJ0aXRpb25JbmZvEj4KD29sZF9yb290ZnNfaW5mbxgIIAEo" + "CzIlLmNocm9tZW9zX3VwZGF0ZV9lbmdpbmUuUGFydGl0aW9uSW5mbxI+Cg9u" + "ZXdfcm9vdGZzX2luZm8YCSABKAsyJS5jaHJvbWVvc191cGRhdGVfZW5naW5l" + "LlBhcnRpdGlvbkluZm8SOQoOb2xkX2ltYWdlX2luZm8YCiABKAsyIS5jaHJv" + "bWVvc191cGRhdGVfZW5naW5lLkltYWdlSW5mbxI5Cg5uZXdfaW1hZ2VfaW5m" + "bxgLIAEoCzIhLmNocm9tZW9zX3VwZGF0ZV9lbmdpbmUuSW1hZ2VJbmZvEhgK" + "DW1pbm9yX3ZlcnNpb24YDCABKA06ATASOwoKcGFydGl0aW9ucxgNIAMoCzIn" + "LmNocm9tZW9zX3VwZGF0ZV9lbmdpbmUuUGFydGl0aW9uVXBkYXRlEhUKDW1h" + "eF90aW1lc3RhbXAYDiABKAMSVAoaZHluYW1pY19wYXJ0aXRpb25fbWV0YWRh" + "dGEYDyABKAsyMC5jaHJvbWVvc191cGRhdGVfZW5naW5lLkR5bmFtaWNQYXJ0" + "aXRpb25NZXRhZGF0YUICSAM=");
		_0 = FileDescriptor.FromGeneratedCode(array, new FileDescriptor[0], new GeneratedClrTypeInfo((Type[])null, (Extension[])null, new GeneratedClrTypeInfo[9]
		{
			new GeneratedClrTypeInfo(typeof(Extent), (MessageParser)(object)Extent.Parser, new string[2] { "StartBlock", "NumBlocks" }, (string[])null, (Type[])null, (Extension[])null, (GeneratedClrTypeInfo[])null),
			new GeneratedClrTypeInfo(typeof(Signatures), (MessageParser)(object)Signatures.Parser, new string[1] { "Signatures_" }, (string[])null, (Type[])null, (Extension[])null, new GeneratedClrTypeInfo[1]
			{
				new GeneratedClrTypeInfo(typeof(Signatures.Types.Signature), (MessageParser)(object)Signatures.Types.Signature.Parser, new string[3] { "Version", "Data", "UnpaddedSignatureSize" }, (string[])null, (Type[])null, (Extension[])null, (GeneratedClrTypeInfo[])null)
			}),
			new GeneratedClrTypeInfo(typeof(PartitionInfo), (MessageParser)(object)PartitionInfo.Parser, new string[2] { "Size", "Hash" }, (string[])null, (Type[])null, (Extension[])null, (GeneratedClrTypeInfo[])null),
			new GeneratedClrTypeInfo(typeof(ImageInfo), (MessageParser)(object)ImageInfo.Parser, new string[6] { "Board", "Key", "Channel", "Version", "BuildChannel", "BuildVersion" }, (string[])null, (Type[])null, (Extension[])null, (GeneratedClrTypeInfo[])null),
			new GeneratedClrTypeInfo(typeof(InstallOperation), (MessageParser)(object)InstallOperation.Parser, new string[9] { "Type", "DataOffset", "DataLength", "SrcExtents", "SrcLength", "DstExtents", "DstLength", "DataSha256Hash", "SrcSha256Hash" }, (string[])null, new Type[1] { typeof(InstallOperation.Types.Type) }, (Extension[])null, (GeneratedClrTypeInfo[])null),
			new GeneratedClrTypeInfo(typeof(PartitionUpdate), (MessageParser)(object)PartitionUpdate.Parser, new string[16]
			{
				"PartitionName", "RunPostinstall", "PostinstallPath", "FilesystemType", "NewPartitionSignature", "OldPartitionInfo", "NewPartitionInfo", "Operations", "PostinstallOptional", "HashTreeDataExtent",
				"HashTreeExtent", "HashTreeAlgorithm", "HashTreeSalt", "FecDataExtent", "FecExtent", "FecRoots"
			}, (string[])null, (Type[])null, (Extension[])null, (GeneratedClrTypeInfo[])null),
			new GeneratedClrTypeInfo(typeof(DynamicPartitionGroup), (MessageParser)(object)DynamicPartitionGroup.Parser, new string[3] { "Name", "Size", "PartitionNames" }, (string[])null, (Type[])null, (Extension[])null, (GeneratedClrTypeInfo[])null),
			new GeneratedClrTypeInfo(typeof(DynamicPartitionMetadata), (MessageParser)(object)DynamicPartitionMetadata.Parser, new string[2] { "Groups", "SnapshotEnabled" }, (string[])null, (Type[])null, (Extension[])null, (GeneratedClrTypeInfo[])null),
			new GeneratedClrTypeInfo(typeof(DeltaArchiveManifest), (MessageParser)(object)DeltaArchiveManifest.Parser, new string[15]
			{
				"InstallOperations", "KernelInstallOperations", "BlockSize", "SignaturesOffset", "SignaturesSize", "OldKernelInfo", "NewKernelInfo", "OldRootfsInfo", "NewRootfsInfo", "OldImageInfo",
				"NewImageInfo", "MinorVersion", "Partitions", "MaxTimestamp", "DynamicPartitionMetadata"
			}, (string[])null, (Type[])null, (Extension[])null, (GeneratedClrTypeInfo[])null)
		}));
	}
}
