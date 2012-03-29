/*
 * Created by SharpDevelop.
 * User: Admin
 * Date: 30.03.2012
 * Time: 2:25
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using NUnit.Framework;
using FuzzyCalcNET;

namespace FCTest.Subsets
{
	[TestFixture]
	public class TrapezoidalTest
	{
		[Test]
		public void Trapezoidal()
		{
			FuzzyCalcNET.Subset.Trapezoidal a = new FuzzyCalcNET.Subset.Trapezoidal(0.0, 2.0, 3.5, 4.5);
			Assert.AreEqual(0.0, a.membership(0.0), "Invalid begin value");
			Assert.AreEqual(0.0, a.membership(4.5), "Invalid end value");
			Assert.AreEqual(1.0, a.membership(2.0), "Invalid begin_tol value");
			Assert.AreEqual(1.0, a.membership(3.5), "Invalid end_tol value");
			Assert.AreEqual(0.5, a.membership(1.0), "Invalid left_mid value");
			Assert.AreEqual(0.5, a.membership(4.0), "Invalid right_mid value");
			Assert.AreEqual(0.25, a.membership(4.25), "Invalid left_frac value");
			Assert.AreEqual(0.75, a.membership(1.5), "Invalid right_frac value");
			Assert.AreEqual(0.0, a.membership(-0.3), "Invalid infra value");
			Assert.AreEqual(0.0, a.membership(6.0), "Invalid ultra value");
		}
	}
}
