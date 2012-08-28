/*
 * Created by SharpDevelop.
 * User: Admin
 * Date: 01.01.2004
 * Time: 2:04
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
	public class GaussianClassifiersTest
	{		
		[Test]
		public void DefaultDomain()
		{
			FuzzySet C = new GaussianClassifier(new string[]{"low", "high"});
			Assert.AreEqual(0.33333, Math.Round(C["low"].centroid(), 5), "Invalid low centroid");
			Assert.AreEqual(0.66667, Math.Round(C["high"].centroid(), 5), "Invalid high centroid");
			Assert.AreEqual(0.38889, Math.Round(C["high"].Domain.begin, 5), "Invalid high begin");
		}
		[Test]
		public void AnotherDomain()
		{
			FuzzySet C = new GaussianClassifier(new string[]{"low", "high"}, begin: 10.0, end: 23.0);
			Assert.AreEqual(14.33333, Math.Round(C["low"].centroid(), 5), "Invalid low centroid");
			Assert.AreEqual(18.66667, Math.Round(C["high"].centroid(), 5), "Invalid high centroid");
		}
		[Test]
		public void OneClass()
		{			
			Assert.Throws(typeof(ArgumentException), delegate{FuzzySet C = new GaussianClassifier(new string[]{"low"});});
		}
		[Test]
		public void EdgeTrue()
		{
			FuzzySet C = new GaussianClassifier(new string[]{"low", "high"}, edge: true);
			Assert.AreEqual(0.0, Math.Round(C["low"].centroid(), 5), "Invalid low centroid");
			Assert.AreEqual(1.0, Math.Round(C["high"].centroid(), 5), "Invalid high centroid");
		}
		[Test]
		public void HalfCross()
		{
			FuzzySet C = new GaussianClassifier(new string[]{"low", "high"}, cross: 0.5);
			Assert.AreEqual(0.33333, Math.Round(C["low"].centroid(), 5), "Invalid low centroid");
			Assert.AreEqual(0.66667, Math.Round(C["high"].centroid(), 5), "Invalid high centroid");
			Assert.AreEqual(0.52778, Math.Round(C["high"].Domain.begin, 5), "Invalid high begin");
		}		
		[Test]
		public void DoubleCross()
		{
			FuzzySet C = new GaussianClassifier(new string[]{"low", "high"}, cross: 2.0);
			Assert.AreEqual(0.33333, Math.Round(C["low"].centroid(), 5), "Invalid low centroid");
			Assert.AreEqual(0.66667, Math.Round(C["high"].centroid(), 5), "Invalid high centroid");
			Assert.AreEqual(0.11111, Math.Round(C["high"].Domain.begin, 5), "Invalid high begin");
		}
	}
	[TestFixture]
	public class TriangleClassifiersTest
	{		
		[Test]
		public void DefaultDomain()
		{
			FuzzySet C = new TriangleClassifier(new string[]{"low", "high"});
			Assert.AreEqual(0.33333, Math.Round(C["low"].centroid(), 5), "Invalid low centroid");
			Assert.AreEqual(0.66667, Math.Round(C["high"].centroid(), 5), "Invalid high centroid");
			Assert.AreEqual(0.33333, Math.Round(C["high"].Domain.begin, 5), "Invalid high begin");
			Assert.AreEqual(1.0, Math.Round(C["high"].Domain.end, 5), "Invalid high end");
			Assert.AreEqual(0.0, Math.Round(C["low"].Domain.begin, 5), "Invalid low begin");
			Assert.AreEqual(0.66667, Math.Round(C["low"].Domain.end, 5), "Invalid low end");
		}
		[Test]
		public void AnotherDomain()
		{
			FuzzySet C = new TriangleClassifier(new string[]{"low", "high"}, begin: 10.0, end: 23.0);
			Assert.AreEqual(14.33333, Math.Round(C["low"].centroid(), 5), "Invalid low centroid");
			Assert.AreEqual(18.66667, Math.Round(C["high"].centroid(), 5), "Invalid high centroid");
		}
		[Test]
		public void OneClass()
		{			
			Assert.Throws(typeof(ArgumentException), delegate{FuzzySet C = new TriangleClassifier(new string[]{"low"});});
		}
		[Test]
		public void EdgeTrue()
		{
			FuzzySet C = new TriangleClassifier(new string[]{"low", "high"}, edge: true);
			Assert.AreEqual(0.0, Math.Round(C["low"].centroid(), 5), "Invalid low centroid");
			Assert.AreEqual(1.0, Math.Round(C["high"].centroid(), 5), "Invalid high centroid");
		}
		[Test]
		public void ZeroCross()
		{
			FuzzySet C = new TriangleClassifier(new string[]{"low", "high"}, cross: 0.0);
			Assert.AreEqual(0.33333, Math.Round(C["low"].centroid(), 5), "Invalid low centroid");
			Assert.AreEqual(0.66667, Math.Round(C["high"].centroid(), 5), "Invalid high centroid");
			Assert.AreEqual(0.5, Math.Round(C["high"].Domain.begin, 5), "Invalid high begin");
		}		
		[Test]
		public void DoubleCross()
		{
			FuzzySet C = new TriangleClassifier(new string[]{"low", "high"}, cross: 2.0);
			Assert.AreEqual(0.33333, Math.Round(C["low"].centroid(), 5), "Invalid low centroid");
			Assert.AreEqual(0.66667, Math.Round(C["high"].centroid(), 5), "Invalid high centroid");
			Assert.AreEqual(0.16667, Math.Round(C["high"].Domain.begin, 5), "Invalid high begin");
		}
	}
	[TestFixture]
	public class StandartClassifiersTest
	{
		[Test]
		public void BinaryClassifierTriangle()
		{
			FuzzySet C = new std_2_Classifier_triangle();
			Assert.AreEqual("low", C.classify(0.3), "Invalid low classification");
			Assert.AreEqual("high", C.classify(0.9), "Invalid high classification");
		}
		[Test]
		public void BinaryClassifierGaussian()
		{
			FuzzySet C = new std_2_Classifier_gaussian();
			Assert.AreEqual("low", C.classify(0.3), "Invalid low classification");
			Assert.AreEqual("high", C.classify(0.9), "Invalid high classification");
		}
		[Test]
		public void TernaryClassifierTriangle()
		{
			FuzzySet C = new std_3_Classifier_triangle();
			Assert.AreEqual("low", C.classify(0.3), "Invalid low classification");
			Assert.AreEqual("high", C.classify(0.9), "Invalid high classification");
		}
		[Test]
		public void TernaryClassifierGaussian()
		{
			FuzzySet C = new std_3_Classifier_gaussian();
			Assert.AreEqual("low", C.classify(0.3), "Invalid low classification");
			Assert.AreEqual("high", C.classify(0.9), "Invalid high classification");
		}
		[Test]
		public void PentaryClassifierTriangle()
		{
			FuzzySet C = new std_5_Classifier_triangle();
			Assert.AreEqual("low", C.classify(0.3), "Invalid low classification");
			Assert.AreEqual("very high", C.classify(0.9), "Invalid high classification");
		}
		[Test]
		public void PentaryClassifierGaussian()
		{
			FuzzySet C = new std_5_Classifier_gaussian();
			Assert.AreEqual("low", C.classify(0.3), "Invalid low classification");
			Assert.AreEqual("very high", C.classify(0.9), "Invalid high classification");
		}
	}
}
