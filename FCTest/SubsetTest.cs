/*
 * Created by SharpDevelop.
 * User: sejros
 * Date: 21.03.2012
 * Time: 17:14
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using NUnit.Framework;
using FuzzyCalcNET.Subset;
using FuzzyCalcNET.Domains;
using System.Collections;
using System.Collections.Generic;

namespace FCTest.Subsets
{
	[TestFixture]
	public class SubsetTest
	{
		Subset A;
		[Test]
		public void Create()
		{
			Assert.DoesNotThrow(delegate{A = new Subset();});			
		}
		[Test]
		public void Add_Values()
		{
			A = new Subset();
			Assert.DoesNotThrow(delegate{A.set_value(0.0, 0.0);});
			Assert.DoesNotThrow(delegate{A.set_value(1.0, 1.0);});
			Assert.Throws<ArgumentException>(delegate{A.set_value(3.0, 0.0);});
			Assert.DoesNotThrow(delegate{A.set_value(0.5, 2.0);});
		}
		[Test]
		public void Return_Values()
		{
			A = new Subset();
			A.set_value(0.0, 0.0);
			A.set_value(0.5, 1.0);
			A.set_value(1.0, 0.0);
			Assert.AreEqual(0.0, A.membership(0.0), "Incorrect membership value");
			Assert.AreEqual(1.0, A.membership(0.5), "Incorrect membership value");
			Assert.AreEqual(0.0, A.membership(1.0), "Incorrect membership value");
			Assert.Throws<KeyNotFoundException>(delegate{A.membership(0.2);});
			Assert.Throws<ArgumentException>(delegate{A.membership(1.2);});
		}
	}
	
	[TestFixture]
	public class TriangleTest
	{
		Triangle A;
		[Test]
		public void Create()
		{
			Assert.DoesNotThrow(delegate{A = new Triangle(0.0, 4.0, 6.0);});
		}
		[Test]
		public void Create_incrorrect()
		{
			Assert.Throws<ArgumentException>(delegate{A = new Triangle(0.0, 4.0, 3.0);});
		}
		[Test]
		public void Membership()
		{
			A = new Triangle(0.0, 4.0, 6.0);
			Assert.AreEqual(0.0, A.membership(0.0), "Incorrect membership value at the beginning");
			Assert.AreEqual(1.0, A.membership(4.0), "Incorrect membership value at mode");
			Assert.AreEqual(0.0, A.membership(6.0), "Incorrect membership value at ending");
			Assert.AreEqual(0.0, A.membership(-1.0), "Incorrect membership value before the domaun");
			Assert.AreEqual(0.0, A.membership(10.0), "Incorrect membership value after the domain");
			Assert.AreEqual(0.25, A.membership(1.0), "Incorrect membership value left side");
			Assert.AreEqual(0.5, A.membership(5.0), "Incorrect membership value right side");
		}
		[Test]
		public void Centroid()
		{
			A = new Triangle(0.0, 0.2, 0.4);
			Assert.AreEqual(0.2, Math.Round(A.centroid(), 5), "Invalid symmetric centroid");
			A = new Triangle(0, 2, 4);
			Assert.AreEqual(2, Math.Round(A.centroid(), 5), "Invalid symmetric centroid with integer params");
			A = new Triangle(0, 2, 7);
			Assert.AreEqual(3, Math.Round(A.centroid(), 5), "Invalid asymmetric centroid");
		}
		[Test]
		public void MultiplyByNumber_Correct()
		{
			Subset a = new Triangle(0.0, 2.0, 3.0);
			double k = 0.5;
			Subset b = a * k;
			Assert.AreEqual(0.0, Math.Round(b.membership(0.0), 5), "Invalid begin membership");
			Assert.AreEqual(0.0, Math.Round(b.membership(3.0), 5), "Invalid end membership");
			Assert.AreEqual(k, Math.Round(b.membership(2.0), 5), "Invalid mode membership");
			Assert.AreEqual(k/2, Math.Round(b.membership(1.0), 5), "Invalid rational membership 1");
			Assert.AreEqual(k/2, Math.Round(b.membership(2.5), 5), "Invalid rational membership 2");
		}
		[Test]
		public void DivideByNumber_Correct()
		{
			Subset a = new Triangle(0.0, 2.0, 3.0);
			double k = 2.0;
			Subset b = a / k;
			Assert.AreEqual(0.0, Math.Round(b.membership(0.0), 5), "Invalid begin membership");
			Assert.AreEqual(0.0, Math.Round(b.membership(3.0), 5), "Invalid end membership");
			Assert.AreEqual(1/k, Math.Round(b.membership(2.0), 5), "Invalid mode membership");
			Assert.AreEqual(1/(2*k), Math.Round(b.membership(1.0), 5), "Invalid rational membership 1");
			Assert.AreEqual(1/(2*k), Math.Round(b.membership(2.5), 5), "Invalid rational membership 2");
		}
		[Test]
		public void SubtractANumber_Correct()
		{
			Subset a = new Triangle(0.0, 2.0, 3.0);
			double k = -0.3;
			Subset b = a - k;
			Assert.AreEqual(0.3, Math.Round(b.membership(0.0), 5), "Invalid begin membership");
			Assert.AreEqual(0.3, Math.Round(b.membership(3.0), 5), "Invalid end membership");
			Assert.AreEqual(1.0, Math.Round(b.membership(2.0), 5), "Invalid mode membership");
			Assert.AreEqual(0.5-k, Math.Round(b.membership(1.0), 5), "Invalid rational membership 1");
			Assert.AreEqual(0.5-k, Math.Round(b.membership(2.5), 5), "Invalid rational membership 2");
		}
		[Test]
		public void MultiplyByNumber_InvertedOrder()
		{
			Subset a = new Triangle(0.0, 2.0, 3.0);
			double k = 0.5;
			Subset b = k * a;
			Assert.AreEqual(0.0, Math.Round(b.membership(0.0), 5), "Invalid begin membership");
			Assert.AreEqual(0.0, Math.Round(b.membership(3.0), 5), "Invalid end membership");
			Assert.AreEqual(k, Math.Round(b.membership(2.0), 5), "Invalid mode membership");
			Assert.AreEqual(k/2, Math.Round(b.membership(1.0), 5), "Invalid rational membership 1");
			Assert.AreEqual(k/2, Math.Round(b.membership(2.5), 5), "Invalid rational membership 2");
		}
		[Test]
		public void MultiplyByNumber_Overflow()
		{
			Subset a = new Triangle(0.0, 2.0, 3.0);
			double k = 1.5;
			Subset b = a * k;
			Assert.AreEqual(0.0, Math.Round(b.membership(0.0), 5), "Invalid begin membership");
			Assert.AreEqual(0.0, Math.Round(b.membership(3.0), 5), "Invalid end membership");
			Assert.AreEqual(1.0, Math.Round(b.membership(2.0), 5), "Invalid mode membership");
			Assert.AreEqual(k/2, Math.Round(b.membership(1.0), 5), "Invalid rational membership 1");
			Assert.AreEqual(k/2, Math.Round(b.membership(2.5), 5), "Invalid rational membership 2");
		}
		[Test]
		public void MultiplyByNumber_TooBig()
		{
			Subset a = new Triangle(0.0, 2.0, 3.0);
			double k = 10.0;
			Subset b = a * k;
			Assert.AreEqual(0.0, Math.Round(b.membership(0.0), 5), "Invalid begin membership");
			Assert.AreEqual(0.0, Math.Round(b.membership(3.0), 5), "Invalid end membership");
			Assert.AreEqual(1.0, Math.Round(b.membership(2.0), 5), "Invalid mode membership");
			Assert.AreEqual(1.0, Math.Round(b.membership(1.0), 5), "Invalid rational membership 1");
			Assert.AreEqual(1.0, Math.Round(b.membership(2.5), 5), "Invalid rational membership 2");
		}
		[Test]
		public void MultiplyByNumber_Negative()
		{
			Subset a = new Triangle(0.0, 2.0, 3.0);
			double k = -0.8;
			Subset b = a * k;
			Assert.AreEqual(0.0, Math.Round(b.membership(0.0), 5), "Invalid begin membership");
			Assert.AreEqual(0.0, Math.Round(b.membership(3.0), 5), "Invalid end membership");
			Assert.AreEqual(0.0, Math.Round(b.membership(2.0), 5), "Invalid mode membership");
			Assert.AreEqual(0.0, Math.Round(b.membership(1.0), 5), "Invalid rational membership 1");
			Assert.AreEqual(0.0, Math.Round(b.membership(2.5), 5), "Invalid rational membership 2");
		}
		[Test]
		public void AddANumber_Correct()
		{
			Subset a = new Triangle(0.0, 2.0, 3.0);
			double k = 0.3;
			Subset b = a + k;
			Assert.AreEqual(k, Math.Round(b.membership(0.0), 5), "Invalid begin membership");
			Assert.AreEqual(k, Math.Round(b.membership(3.0), 5), "Invalid end membership");
			Assert.AreEqual(1.0, Math.Round(b.membership(2.0), 5), "Invalid mode membership");
			Assert.AreEqual(0.5+k, Math.Round(b.membership(1.0), 5), "Invalid rational membership 1");
			Assert.AreEqual(0.5+k, Math.Round(b.membership(2.5), 5), "Invalid rational membership 2");
		}
		[Test]
		public void AddANumber_Overflow()
		{
			Subset a = new Triangle(0.0, 2.0, 3.0);
			double k = 0.9;
			Subset b = a + k;
			Assert.AreEqual(k, Math.Round(b.membership(0.0), 5), "Invalid begin membership");
			Assert.AreEqual(k, Math.Round(b.membership(3.0), 5), "Invalid end membership");
			Assert.AreEqual(1.0, Math.Round(b.membership(2.0), 5), "Invalid mode membership");
			Assert.AreEqual(1.0, Math.Round(b.membership(1.0), 5), "Invalid rational membership 1");
			Assert.AreEqual(1.0, Math.Round(b.membership(2.5), 5), "Invalid rational membership 2");
		}
		[Test]
		public void AddANumber_TooBig()
		{
			Subset a = new Triangle(0.0, 2.0, 3.0);
			double k = 1.3;
			Subset b = a + k;
			Assert.AreEqual(1.0, Math.Round(b.membership(0.0), 5), "Invalid begin membership");
			Assert.AreEqual(1.0, Math.Round(b.membership(3.0), 5), "Invalid end membership");
			Assert.AreEqual(1.0, Math.Round(b.membership(2.0), 5), "Invalid mode membership");
			Assert.AreEqual(1.0, Math.Round(b.membership(1.0), 5), "Invalid rational membership 1");
			Assert.AreEqual(1.0, Math.Round(b.membership(2.5), 5), "Invalid rational membership 2");
		}
		[Test]
		public void AddANumber_Negative()
		{
			Subset a = new Triangle(0.0, 2.0, 3.0);
			double k = -0.3;
			Subset b = a + k;
			Assert.AreEqual(0.0, Math.Round(b.membership(0.0), 5), "Invalid begin membership");
			Assert.AreEqual(0.0, Math.Round(b.membership(3.0), 5), "Invalid end membership");
			Assert.AreEqual(1.0+k, Math.Round(b.membership(2.0), 5), "Invalid mode membership");
			Assert.AreEqual(0.5+k, Math.Round(b.membership(1.0), 5), "Invalid rational membership 1");
			Assert.AreEqual(0.5+k, Math.Round(b.membership(2.5), 5), "Invalid rational membership 2");
		}
		[Test]
		public void AddANumber_TooSmall()
		{
			Subset a = new Triangle(0.0, 2.0, 3.0);
			double k = -1.3;
			Subset b = a + k;
			Assert.AreEqual(0.0, Math.Round(b.membership(0.0), 5), "Invalid begin membership");
			Assert.AreEqual(0.0, Math.Round(b.membership(3.0), 5), "Invalid end membership");
			Assert.AreEqual(0.0, Math.Round(b.membership(2.0), 5), "Invalid mode membership");
			Assert.AreEqual(0.0, Math.Round(b.membership(1.0), 5), "Invalid rational membership 1");
			Assert.AreEqual(0.0, Math.Round(b.membership(2.5), 5), "Invalid rational membership 2");
		}
		[Test]
		public void AddANumber_InvertedOrder()
		{
			Subset a = new Triangle(0.0, 2.0, 3.0);
			double k = 0.3;
			Subset b = k + a;
			Assert.AreEqual(k, Math.Round(b.membership(0.0), 5), "Invalid begin membership");
			Assert.AreEqual(k, Math.Round(b.membership(3.0), 5), "Invalid end membership");
			Assert.AreEqual(1.0, Math.Round(b.membership(2.0), 5), "Invalid mode membership");
			Assert.AreEqual(0.5+k, Math.Round(b.membership(1.0), 5), "Invalid rational membership 1");
			Assert.AreEqual(0.5+k, Math.Round(b.membership(2.5), 5), "Invalid rational membership 2");
		}
	}	
}
