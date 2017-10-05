using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace codewars_sumStringsAsNumber
{
	[TestClass]
	public class Kata
	{
		[TestMethod]
		public void Input_1_1_ShouldReturn_2()
		{
			AssertShouldBeReturn("1", "1", "2");
		}

		[TestMethod]
		public void Input_2_2_ShouldReturn_4()
		{
			AssertShouldBeReturn("2", "2", "4");
		}

		[TestMethod]
		public void jsutHaveOneInput_1_shouldReturn_1()
		{
			AssertShouldBeReturn("", "2", "2");
		}

	    [TestMethod]
	    public void Input_77_3_ShouldReturn_80()
	    {
	        AssertShouldBeReturn("77", "3", "80");
	    }

	    [TestMethod]
	    public void Input_77_23_ShouldReturn_100()
	    {
	        AssertShouldBeReturn("77", "23", "100");
	    }

	    [TestMethod]
	    public void Input_7777_23_ShouldReturn_7800()
	    {
	        AssertShouldBeReturn("7777", "23", "7800");
	    }

        private static void AssertShouldBeReturn(string strInt1, string strInt2, string expect)
		{
			string accum = (new SumStringsAsNumbers()).sumStrings(strInt1, strInt2);
			Assert.AreEqual(expect, accum);
		}
	}

	public class SumStringsAsNumbers
	{
		public string sumStrings(string a, string b)
		{
			if (a == String.Empty || b == String.Empty)
			{
				return $"{a + b}";
			}

		    var strIntReverse1 = a.Reverse().ToList();
		    var strIntReverse2 = b.Reverse().ToList();
		    var resultStrInt = "";
		    var addTag = false;
		    for (var i = 0; i < Math.Max(a.Length, b.Length); i++)
		    {
		        addTag = CaculateAndReturnAddTag(strIntReverse1, strIntReverse2, addTag, i, ref resultStrInt);
            }

		    if (addTag)
		    {
		        resultStrInt = $"1{resultStrInt}";
		    }

		    return resultStrInt;
		}

	    private static bool CaculateAndReturnAddTag(List<char> strIntReverse1, List<char> strIntReverse2, bool addTag, int i, ref string resultStrInt)
	    {
	        var digit1 = Digit1(strIntReverse1, i);
	        var digit2 = Digit1(strIntReverse2, i);

            var digitsSum = DigitsSum(digit1, digit2, addTag, ref resultStrInt);
	        addTag = AddDigit(digitsSum);
	        return addTag;
	    }

	    private static char Digit1(List<char> strIntReverse1, int i)
	    {
	        var digit1 = '0';
	        if (i < strIntReverse1.Count)
	        {
	            digit1 = strIntReverse1[i];
	        }
	        return digit1;
	    }

	    private static int DigitsSum(char digit1, char digit2, bool addTag, ref string resultStrInt)
	    {
	        var digitsSum = int.Parse(digit1.ToString()) + int.Parse(digit2.ToString());
	        digitsSum = addTag ? digitsSum + 1 : digitsSum;
            resultStrInt = $"{digitsSum % 10}{resultStrInt}";
	        return digitsSum;
	    }

	    private static bool AddDigit(int digitsSum)
	    {
	        if (digitsSum > 9)
	        {
	            return true;
	        }
	        return false;
	    }
	}
}
