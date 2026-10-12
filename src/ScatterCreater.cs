public class ScatterCreater
{
	private static object _0(object PartName)
	{
		uint num = _003CPrivateImplementationDetails_003E._0((string)PartName);
		if (num <= 2510729057u)
		{
			if (num <= 1169572378)
			{
				if (num <= 234893925)
				{
					if (num != 122328799)
					{
						if (num == 234893925 && (string)PartName == "efuse")
						{
							goto IL_0342;
						}
					}
					else if ((string)PartName == "gz1")
					{
						goto IL_0342;
					}
				}
				else if (num != 559185209)
				{
					if (num != 1152794759)
					{
						if (num == 1169572378 && (string)PartName == "protect2")
						{
							goto IL_033a;
						}
					}
					else if ((string)PartName == "protect1")
					{
						goto IL_033a;
					}
				}
				else if ((string)PartName == "sec1")
				{
					goto IL_0342;
				}
			}
			else if (num <= 1754226481)
			{
				if (num != 1498807978)
				{
					if (num != 1713525568)
					{
						if (num == 1754226481 && (string)PartName == "preloader")
						{
							goto IL_033a;
						}
					}
					else if ((string)PartName == "metadata")
					{
						goto IL_033a;
					}
				}
				else if ((string)PartName == "pad")
				{
					goto IL_0342;
				}
			}
			else if (num != 1769478187)
			{
				if (num != 2113499301)
				{
					if (num == 2510729057u && (string)PartName == "nvcfg")
					{
						goto IL_033a;
					}
				}
				else if ((string)PartName == "nvdata")
				{
					goto IL_033a;
				}
			}
			else if ((string)PartName == "para")
			{
				goto IL_033a;
			}
		}
		else if (num <= 2953011528u)
		{
			if (num <= 2839044484u)
			{
				if (num != 2535490251u)
				{
					if (num != 2590058321u)
					{
						if (num == 2839044484u && (string)PartName == "proinfo")
						{
							goto IL_033a;
						}
					}
					else if ((string)PartName == "flashinfo")
					{
						goto IL_034a;
					}
				}
				else if ((string)PartName == "sgpt")
				{
					goto IL_034a;
				}
			}
			else if (num != 2899815699u)
			{
				if (num != 2918391585u)
				{
					if (num == 2953011528u && (string)PartName == "seccfg")
					{
						goto IL_033a;
					}
				}
				else if ((string)PartName == "md_udc")
				{
					goto IL_033a;
				}
			}
			else if ((string)PartName == "frp")
			{
				goto IL_033a;
			}
		}
		else if (num <= 3876229064u)
		{
			if (num != 3239582314u)
			{
				if (num != 3680496562u)
				{
					if (num == 3876229064u && (string)PartName == "boot_para")
					{
						goto IL_033a;
					}
				}
				else if ((string)PartName == "expdb")
				{
					goto IL_033a;
				}
			}
			else if ((string)PartName == "otp")
			{
				goto IL_034a;
			}
		}
		else if (num != 3917083779u)
		{
			if (num != 4002403744u)
			{
				if (num == 4005970212u && (string)PartName == "pgpt")
				{
					goto IL_033a;
				}
			}
			else if ((string)PartName == "devinfo")
			{
				goto IL_0342;
			}
		}
		else if ((string)PartName == "persist")
		{
			goto IL_033a;
		}
		return "  operation_type: UPDATE";
		IL_0342:
		return "  operation_type: INVISIBLE";
		IL_033a:
		return "  operation_type: PROTECTED";
		IL_034a:
		return "  operation_type: RESERVED";
	}
}
