/*
 * Created by SharpDevelop.
 * User: Admin
 * Date: 30.03.2012
 * Time: 3:27
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using NUnit.Framework;
using FuzzyCalcNET.Set;
using FuzzyCalcNET.Subset;

namespace FCTest.Set
{
	[TestFixture]
	public class SetTest
	{
		[Test]
		public void TestMethod()
		{
			FuzzySet a = new FuzzySet();
			Subset b = a["initial"];
		}
	}
}
