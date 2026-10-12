using System;

namespace SLA_Challenge;

public static class StringExtensions
{
	public static string GetCenter(this string input, string startString, string endString)
	{
		int num = input.IndexOf(startString);
		if (num == -1)
		{
			return null;
		}
		num += startString.Length;
		int num2 = input.IndexOf(endString, num);
		if (num2 == -1)
		{
			return null;
		}
		return input.Substring(num, num2 - num);
	}

	public static bool IsNullOrEmpty(this string input)
	{
		return string.IsNullOrEmpty(input);
	}

	public static bool IsNotNullOrEmpty(this string input)
	{
		return !string.IsNullOrEmpty(input);
	}

	public static string[] Split(this string input, string separator)
	{
		return input.Split(separator.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
	}
}
