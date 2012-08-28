/*
 * Created by SharpDevelop.
 * User: sejros
 * Date: 21.03.2012
 * Time: 12:57
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using NUnit.Framework;
using FuzzyCalcNET.Domains;
using System.Collections.Generic;
using FuzzyCalcNET.Subset;

namespace FCTest.Domains
{
	[TestFixture]
	public class RationalRangeTest
	{		
		RationalRange r;
		
		[Test]
		public void Create(){
			Assert.DoesNotThrow(delegate{new RationalRange();});
		}
		[Test]
		public void DefaultValues(){
			IDomain D = new RationalRange();
			Assert.AreEqual(0.0, D.begin, "Wrong default begin value");
			Assert.AreEqual(1.0, D.end, "Wrong default end value");
		}
		[Test]
		public void ConstructedValues(){
			IDomain D = new RationalRange(10.2, 24.2);
			Assert.AreEqual(10.2, D.begin, "Wrong begin value");
			Assert.AreEqual(24.2, D.end, "Wrong end value");
		}
		[Test]
		public void SetterValues(){
			IDomain D = new RationalRange();
			D.end = 23.6;
			D.begin = 15.6;
			Assert.AreEqual(15.6, D.begin, "Wrong begin value");
			Assert.AreEqual(23.6, D.end, "Wrong end value");
		}
		[Test]
		public void BoundariesOverlap(){
			IDomain D = new RationalRange();
			Assert.AreEqual(0.0, D.begin, "Wrong begin value");
			Assert.AreEqual(1.0, D.end, "Wrong end value");
			Assert.Throws(typeof(ArgumentException), delegate{D.begin=2.0;}, "Overlap possible");
			Assert.Throws(typeof(ArgumentException), delegate{D.end=-2.0;}, "Overlap possible");
		}
		
		[Test]
		public void Iterate_default(){
			r = new RationalRange();
			List<double> a = new List<double>();
			foreach (double num in r) {
				a.Add(num);
			}
			Assert.AreEqual(0.0, a[0], "Начальное значение неверно");
			Assert.AreEqual(1.0, a[a.Count-1], "Конечное значение неверно");
		}
		
		[Test]
		public void Iterate(){
			r = new RationalRange(begin: 10.1, end: 12.3, step: 0.2);
			List<double> a = new List<double>();
			foreach (double num in r) {
				a.Add(num);
			}
			Assert.AreEqual(10.1, a[0], "Начальное значение неверно");
			Assert.AreEqual(10.3, a[1], "Шаг неверен");
			Assert.AreEqual(12  , a.Count, "Количество итераций неверно");
			Assert.AreEqual(12,3, a[a.Count-1], "Конечное значение неверно");
		}
		[Test]
		public void SmallRangeIterate()
		{
			Subset s = new Triangle(0.0, 2.0, 3.0);
			List<double> a = new List<double>();
			foreach (double num in s.Domain) {
				a.Add(num);
			}
			Assert.AreEqual(0.0, a[0], "Начальное значение неверно");
			Assert.AreEqual(3.0, a[a.Count-1], "Конечное значение неверно");
		}
	}
}
