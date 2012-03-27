/*
 * Created by SharpDevelop.
 * User: sejros
 * Date: 21.03.2012
 * Time: 16:47
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using NUnit.Framework;
using FuzzyCalcNET.Domains;
using System.Collections.Generic;

namespace FCTest.Domains
{
	[TestFixture]
	public class IntegerRangeTest
	{
		IntegerRange r;
		
		[Test]
		public void Create(){
			Assert.DoesNotThrow(delegate{new IntegerRange();});
		}
		
		[Test]
		public void Iterate_default(){
			r = new IntegerRange();
			List<double> a = new List<double>();
			foreach (double num in r) {
				a.Add(num);
			}
			Assert.AreEqual(0, Math.Round(a[0], 4), "Начальное значение неверно");
			Assert.AreEqual(1, Math.Round(a[1], 4), "Шаг неверен");
			Assert.AreEqual(101 , a.Count, "Количество итераций неверно");
			Assert.AreEqual(100, Math.Round(a[a.Count-1], 4), "Конечное значение неверно");
		}
		
		[Test]
		public void Iterate(){
			r = new IntegerRange(begin: 101, end: 120);
			List<double> a = new List<double>();
			foreach (double num in r) {
				a.Add(num);
			}
			Assert.AreEqual(101, Math.Round(a[0], 4), "Начальное значение неверно");
			Assert.AreEqual(102, Math.Round(a[1], 4), "Шаг неверен");
			Assert.AreEqual(20  , a.Count, "Количество итераций неверно");
			Assert.AreEqual(120, Math.Round(a[a.Count-1], 4), "Конечное значение неверно");
		}
	}
}
