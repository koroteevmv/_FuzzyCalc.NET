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
	public class ClassifiersTest
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
			Assert.AreEqual("middle", C.classify(0.3), "Invalid low classification");
			Assert.AreEqual("high", C.classify(0.9), "Invalid high classification");
		}
		[Test]
		public void TernaryClassifierGaussian()
		{
			FuzzySet C = new std_3_Classifier_gaussian();
			Assert.AreEqual("middle", C.classify(0.3), "Invalid low classification");
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
