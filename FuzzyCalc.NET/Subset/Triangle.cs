/*
 * Created by SharpDevelop.
 * User: sejros
 * Date: 21.03.2012
 * Time: 19:41
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace FuzzyCalcNET.Subset
{
	/// <summary>
	/// Description of Triangle.
	/// </summary>
	public class Triangle: Subset
	{
		double a, b, c;
		public Triangle(double begin, double mode, double end)
		{
			if (!(begin<=mode && mode<=end)) {
				throw new ArgumentException();
			}
			this.Domain = new Domains.RationalRange(begin: begin, end: end);
			this.a = begin;
			this.b = mode;
			this.c = end;
		}
		public override double membership(double x)
		{
			if (x>=this.a && x<=this.b) {
				return (x - this.a)/(this.b - this.a);
			}
			else if (x>=this.b && x<=this.c) {
				return (x - this.c)/(this.b - this.c);
			}
			else 
			{
				return 0.0;
			}			
		}
	}
}
