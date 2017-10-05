using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace codewars_sumStringsAsNumber
{
	[TestClass]
	public class Kata
	{
		[TestMethod]
		public void Input_1_1_ShouldReturn_2()
		{
			AssertShouldBeReturn("2", "1", "1");
		}

		[TestMethod]
		public void Input_2_2_ShouldReturn_4()
		{
			AssertShouldBeReturn("4", "2", "2");
		}

		[TestMethod]
		public void jsutHaveOneInput_1_shouldReturn_1()
		{
			AssertShouldBeReturn("2", "", "2");
		}

		private static void AssertShouldBeReturn(string expect, string strInt1, string strInt2)
		{
			string accum = (new SumStringsAsNumbers()).Accum(strInt1, strInt2);
			Assert.AreEqual(expect, accum);
		}
	}

	public class SumStringsAsNumbers
	{
		public string Accum(string strInt1, string strInt2)
		{
			if (strInt1 == String.Empty || strInt2 == String.Empty)
			{
				return $"{strInt1 + strInt2}";
			}

			return $"{int.Parse(strInt1) + int.Parse(strInt2)}";
		}
	}
}
