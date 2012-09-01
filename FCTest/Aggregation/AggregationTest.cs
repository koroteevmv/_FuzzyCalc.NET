/*
 * Created by SharpDevelop.
 * User: Admin
 * Date: 31.08.2012
 * Time: 23:22
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using NUnit.Framework;
using FuzzyCalcNET.Controller;

namespace FCTest.Aggregation
{
	[TestFixture]
	public class SimpleAggregationTest
	{
		[Test]
		public void Valid()
		{
			IAggregation S = new Average();
			S.crisp_input = new double[3]{1, 1, 1};
			Assert.AreEqual(1, S.calculate_crisp(), "");
			S.crisp_input = new double[3]{1, 2, 3};
			Assert.AreEqual(2, S.calculate_crisp(), "");
			S.crisp_input = new double[1]{1};
			Assert.AreEqual(1, S.calculate_crisp(), "");
		}
		[Test]
		public void EmptyInput()
		{
			IAggregation S = new Average();
			Assert.Throws(typeof(MissingFieldException), delegate{S.calculate_crisp();}, "");
		}
	}
	[TestFixture]
	public class WeightedAverageTest
	{
		[Test]
		public void Valid()
		{
			WeightedAverage S = new WeightedAverage();
			S.crisp_input = new double[3]{1, 1, 1};
			S.weights = new double[3]{1, 1, 1};
			Assert.AreEqual(1, S.calculate_crisp(), "");
			S.crisp_input = new double[3]{1, 2, 3};
			S.weights = new double[3]{1, 1, 1};
			Assert.AreEqual(2, S.calculate_crisp(), "");
			S.crisp_input = new double[1]{1};
			S.weights = new double[1]{5};
			Assert.AreEqual(1, S.calculate_crisp(), "");
			S.crisp_input = new double[3]{1, 2, 3};
			S.weights = new double[3]{2, 2, 1};
			Assert.AreEqual(1.8, S.calculate_crisp(), "");
			S.crisp_input = new double[3]{1, 2, 3};
			S.weights = new double[3]{1, 3, 1};
			Assert.AreEqual(2, S.calculate_crisp(), "");
		}
		[Test]
		public void EmptyInput()
		{
			WeightedAverage S = new WeightedAverage();
			Assert.Throws(typeof(MissingFieldException), delegate{S.calculate_crisp();}, "");
		}
		[Test]
		public void EmptyWeights()
		{
			WeightedAverage S = new WeightedAverage();
			S.crisp_input = new double[3]{1, 1, 1};
			Assert.Throws(typeof(MissingFieldException), delegate{S.calculate_crisp();}, "");
		}
		[Test]
		public void DifferentLenghts()
		{
			WeightedAverage S = new WeightedAverage();
			S.crisp_input = new double[3]{1, 1, 1};
			S.weights = new double[2]{1, 1};
			Assert.Throws(typeof(ArgumentException), delegate{S.calculate_crisp();}, "");
		}
	}
}
