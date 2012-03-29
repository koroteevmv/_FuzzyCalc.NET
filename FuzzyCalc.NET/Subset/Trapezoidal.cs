/*
 * Created by SharpDevelop.
 * User: Admin
 * Date: 30.03.2012
 * Time: 2:25
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using FuzzyCalcNET.Domains;

namespace FuzzyCalcNET.Subset
{
	/// <summary>
	/// Description of Class1.
	/// </summary>
	public class Trapezoidal :Subset
	{
		double a, b, c, d;
		public Trapezoidal(double begin, double begin_tol, double end_tol, double end)
		{
			this.Domain = new RationalRange(begin, end);
			this.Norm = new TNorm.naive();
			a = begin;
			b = begin_tol;
			c = end_tol;
			d = end;
		}
		public override double membership(double x)
		{
			if (x>=a && x<=b) {
				return (x - a)/(b - a);
			}
			else if (x>=c && x<=d) {
				return (x - d)/(c - d);
			}
			else if (x>=b && x<=c) {
				return 1.0;
			}
			else 
			{
				return 0.0;
			}	
		}
	}
}
