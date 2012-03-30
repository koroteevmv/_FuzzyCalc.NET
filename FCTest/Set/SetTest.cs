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
		FuzzySet a;
		public void create_classifier()
		{
			a = new FuzzySet();
			a["low"] = new Triangle(0.0, 0.0, 0.5);
			a["middle"] = new Triangle(0.0, 0.5, 0.5);
			a["high"] = new Triangle(0.5, 1.0, 1.0);			
		}
		[Test]
		public void Classify_Test()
		{
			create_classifier();
			Assert.AreEqual("middle", a.classify(0.3), "Invalid classification 1");
			Assert.AreEqual("low", a.classify(0.0), "Invalid classification 2");
			Assert.AreEqual("middle", a.classify(0.7), "Invalid classification 3");
			Assert.AreEqual("high", a.classify(0.8), "Invalid classification 4");
			Assert.AreEqual("high", a.classify(1.0), "Invalid classification 5");
		}
		[Test]
		public void find_Test()
		{
			create_classifier();
			Assert.AreEqual(0.4, a.find(0.3, "low"), "Invalid find 1");
		}
	}
}
