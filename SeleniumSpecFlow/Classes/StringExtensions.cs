//This code is from TechTalk.SpecFlow/StringExtensions.cs
//The pre-release version of specflow 3 had these as public and we started using them in our testing.
//They were set to internal in Specflow commit #1408

using System;

namespace SeleniumSpecFlow.Classes
{
	public static class StringExtensions
	{
		public static bool IsNullOrEmpty(this string value)
		{
			return string.IsNullOrEmpty(value);
		}

		public static bool IsNotNullOrEmpty(this string value)
		{
			return !string.IsNullOrEmpty(value);
		}

		public static bool IsNullOrWhiteSpace(this string value)
		{
			if (value == null) return true;

			for (int i = 0; i < value.Length; i++)
			{
				if (!char.IsWhiteSpace(value[i])) return false;
			}

			return true;
		}

		public static bool IsNotNullOrWhiteSpace(this string value)
		{
			return !value.IsNullOrWhiteSpace();
		}

		public static string StripWhitespaces(this string value)
		{
			return value.Replace(" ", "").Replace("\n", "").Replace("\r", "");
		}

		/// <summary>
		/// Returns empty string if the value is null, othervise the original value.
		/// </summary>
		/// <param name="value">The value to convert.</param>
		/// <returns>Empty string or the orinal value.</returns>
		public static string AsEmpty(this string value)
		{
			return string.IsNullOrEmpty(value) ? string.Empty : value;
		}

		/// <summary>
		/// Returns null if the value is empty, othervise the original value.
		/// </summary>
		/// <param name="value">The value to convert.</param>
		/// <returns>Null or the orinal value.</returns>
		public static string AsNull(this string value)
		{
			return string.IsNullOrEmpty(value) ? null : value;
		}
	}
}
