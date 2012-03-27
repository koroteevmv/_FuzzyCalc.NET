/*
 * Created by SharpDevelop.
 * User: sejros
 * Date: 22.03.2012
 * Time: 13:12
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using NUnit.Framework;
using FuzzyCalcNET.TNorm;

namespace FCTest.Tnorm
{
	[TestFixture]
	public class MinMaxTest
	{
		[Test]
		public void normal_norm()
		{
			T_Norm norm = new min_max();
			Assert.AreEqual(0.5, norm.norm(0.7, 0.5), "");
			Assert.AreEqual(0.5, norm.norm(0.5, 0.8), "");
		}	
		[Test]
		public void normal_conorm()
		{
			T_Norm norm = new min_max();
			Assert.AreEqual(0.5, norm.conorm(0.3, 0.5), "");
			Assert.AreEqual(0.5, norm.conorm(0.5, 0.4), "");
		}	
		[Test]
		public void boundries_norm()
		{
			T_Norm norm = new min_max();
			Assert.Throws<ArgumentException>(delegate{norm.norm(-0.3, 0.5);}, "");
			Assert.Throws<ArgumentException>(delegate{norm.norm(0.0, -0.4);}, "");
			Assert.Throws<ArgumentException>(delegate{norm.norm(-0.1, -0.4);}, "");
		}
		[Test]
		public void boundries_conorm()
		{
			T_Norm norm = new min_max();
			Assert.Throws<ArgumentException>(delegate{norm.conorm(1.3, 0.5);}, "");
			Assert.Throws<ArgumentException>(delegate{norm.conorm(1.0, 1.4);}, "");
			Assert.Throws<ArgumentException>(delegate{norm.conorm(1.1, 1.4);}, "");
		}
	}
	[TestFixture]
	public class SumProdTest
	{
		[Test]
		public void normal_norm()
		{
			T_Norm norm = new sum_prod();
			Assert.AreEqual(0.35, norm.norm(0.7, 0.5), "");
			Assert.AreEqual(0.4, norm.norm(0.5, 0.8), "");
		}	
		[Test]
		public void normal_conorm()
		{
			T_Norm norm = new sum_prod();
			Assert.AreEqual(0.65, norm.conorm(0.3, 0.5), "");
			Assert.AreEqual(0.7, norm.conorm(0.5, 0.4), "");
		}	
		[Test]
		public void boundries_norm()
		{
			T_Norm norm = new sum_prod();
			Assert.Throws<ArgumentException>(delegate{norm.norm(-0.3, 0.5);}, "");
			Assert.Throws<ArgumentException>(delegate{norm.norm(0.0, -0.4);}, "");
			Assert.Throws<ArgumentException>(delegate{norm.norm(-0.1, -0.4);}, "");
		}
		[Test]
		public void boundries_conorm()
		{
			T_Norm norm = new sum_prod();
			Assert.Throws<ArgumentException>(delegate{norm.conorm(1.3, 0.5);}, "first");
			Assert.Throws<ArgumentException>(delegate{norm.conorm(1.0, 1.4);}, "second");
			Assert.Throws<ArgumentException>(delegate{norm.conorm(1.1, 1.4);}, "third");
		}
	}
	[TestFixture]
	public class marginTest
	{
		[Test]
		public void normal_norm()
		{
			T_Norm norm = new margin();
			Assert.AreEqual(0.2, Math.Round(norm.norm(0.7, 0.5), 5), "1");
			Assert.AreEqual(0.3, Math.Round(norm.norm(0.5, 0.8), 5), "2");
		}	
		[Test]
		public void normal_conorm()
		{
			T_Norm norm = new margin();
			Assert.AreEqual(0.8, Math.Round(norm.conorm(0.3, 0.5), 5), "1");
			Assert.AreEqual(0.9, Math.Round(norm.conorm(0.5, 0.4), 5), "2");
		}	
		[Test]
		public void boundries_norm()
		{
			T_Norm norm = new margin();
			Assert.Throws<ArgumentException>(delegate{norm.norm(-0.3, 0.5);}, "1");
			Assert.Throws<ArgumentException>(delegate{norm.norm(0.0, -0.4);}, "2");
			Assert.Throws<ArgumentException>(delegate{norm.norm(-0.1, -0.4);}, "3");
		}
		[Test]
		public void boundries_conorm()
		{
			T_Norm norm = new margin();
			Assert.Throws<ArgumentException>(delegate{ norm.conorm(1.3, 0.5);}, "1");
			Assert.Throws<ArgumentException>(delegate{norm.conorm(1.0, 1.4);}, "2");
			Assert.Throws<ArgumentException>(delegate{norm.conorm(1.1, 1.4);}, "3");
		}
	}
	[TestFixture]
	public class drasticTest
	{
		[Test]
		public void normal_norm()
		{
			T_Norm norm = new drastic();
			Assert.AreEqual(0.0, norm.norm(0.7, 0.5), "1");
			Assert.AreEqual(0.5, norm.norm(0.5, 1.0), "2");
			Assert.AreEqual(0.5, norm.norm(1.0, 0.5), "3");
		}	
		[Test]
		public void normal_conorm()
		{
			T_Norm norm = new drastic();
			Assert.AreEqual(1.0, norm.conorm(0.3, 0.5), "1");
			Assert.AreEqual(0.5, norm.conorm(0.5, 0.0), "2");
			Assert.AreEqual(0.5, norm.conorm(0.0, 0.5), "3");
		}	
		[Test]
		public void boundries_norm()
		{
			T_Norm norm = new drastic();
			Assert.Throws<ArgumentException>(delegate{norm.norm(-0.3, 0.5);}, "1");
			Assert.Throws<ArgumentException>(delegate{norm.norm(0.0, -0.4);}, "2");
			Assert.Throws<ArgumentException>(delegate{norm.norm(-0.1, -0.4);}, "3");
		}
		[Test]
		public void boundries_conorm()
		{
			T_Norm norm = new drastic();
			Assert.Throws<ArgumentException>(delegate{norm.conorm(1.3, 0.5);}, "1");
			Assert.Throws<ArgumentException>(delegate{norm.conorm(1.0, 1.4);}, "2");
			Assert.Throws<ArgumentException>(delegate{norm.conorm(1.1, 1.4);}, "3");
		}
	}
}
