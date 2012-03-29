/*
 * Created by SharpDevelop.
 * User: Admin
 * Date: 30.03.2012
 * Time: 2:55
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using NUnit.Framework;
using FuzzyCalcNET.Subset;

namespace FCTest.Subsets
{
	[TestFixture]
	public class GaussianTest
	{
		[Test]
		public void Gaussian_Boundaries()
		{
			Subset a = new Gaussian(3.0, 2.0);
			Assert.AreEqual(-7.0, a.Domain.begin, "Invalid begin point");
			Assert.AreEqual(13.0, a.Domain.end, "Invalid end point");
		}
		[Test]
		public void Gaussian_Membership()
		{
			Subset a = new Gaussian(3.0, 2.0);
			Assert.AreEqual(1.0, a.membership(3.0), "Invalid mode point");
			Assert.AreEqual(Math.Exp(-0.5), a.membership(1.0), "Invalid left point");
			Assert.AreEqual(Math.Exp(-2), a.membership(7.0), "Invalid left point");
		}
	}
}
