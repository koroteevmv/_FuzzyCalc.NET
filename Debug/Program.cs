/*
 * Created by SharpDevelop.
 * User: Admin
 * Date: 31.12.2003
 * Time: 23:09
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using FuzzyCalcNET.Set;
using FuzzyCalcNET.Subset;

namespace Debug
{
	class Program
	{
		public static void Main(string[] args)
		{
			FuzzySet a = new std_3_Classifier_triangle();
			Console.WriteLine("{0}, {1}", a["high"].Domain.begin, a["high"].Domain.end);
			
			Console.ReadKey();
		}
	}
}