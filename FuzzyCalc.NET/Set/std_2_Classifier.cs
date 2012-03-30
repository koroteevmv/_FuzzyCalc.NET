/*
 * Created by SharpDevelop.
 * User: Admin
 * Date: 31.03.2012
 * Time: 1:43
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace FuzzyCalcNET.Set
{
	/// <summary>
	/// Description of std_2_Classifier.
	/// </summary>
	public class std_2_Classifier_triangle :TriangleClassifier
	{
		public std_2_Classifier_triangle(double begin = 0.0, double end = 1.0, string name = "")
			:base(names: new string[]{"I", "II"}, begin: begin, end: end, name: name)
		{
		}
	}
	public class std_2_Classifier_gaussian :GaussianClassifier
	{
		public std_2_Classifier_gaussian(double begin = 0.0, double end = 1.0, string name = "")
			:base(names: new string[]{"I", "II"}, begin: begin, end: end, name: name)
		{
		}
	}
	
	public class std_3_Classifier_triangle :TriangleClassifier
	{
		public std_3_Classifier_triangle(double begin = 0.0, double end = 1.0, string name = "")
			:base(names: new string[]{"I", "II", "III"}, begin: begin, end: end, name: name)
		{
		}
	}
	public class std_3_Classifier_gaussian :GaussianClassifier
	{
		public std_3_Classifier_gaussian(double begin = 0.0, double end = 1.0, string name = "")
			:base(names: new string[]{"I", "II", "III"}, begin: begin, end: end, name: name)
		{
		}
	}
}
