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
			FuzzySet a = new FuzzySet();
			a["low"] = new Triangle(0.0, 0.0, 0.5);
			a["mid"] = new Triangle(0.0, 0.5, 1.0);
			a["high"]= new Triangle(0.5, 1.0, 1.0);
			
			a.classify(0.0);
			a.classify(0.3);
			a.classify(0.7);
			
			Console.ReadKey();
		}
	}
}