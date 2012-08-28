/*
 * Created by SharpDevelop.
 * User: Admin
 * Date: 29.03.2012
 * Time: 23:33
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace FuzzyCalcNET.TNorm
{
	/// <summary>
	/// Description of naive.
	/// </summary>
	public class naive :T_Norm
	{
		public double norm(double a, double b)
		{
			if (0.0>a || a>1.0 || 0.0>b || b>1.0) {
				throw new ArgumentException();
			}
			return a * b;
		}
		
		public double conorm(double a, double b)
		{
			if (0.0>a || a>1.0 || 0.0>b || b>1.0) {
				throw new ArgumentException();
			}
			return a + b;
		}
		
		public double neg(double a)
		{
			if (0.0>a || a>1.0) {
				throw new ArgumentException();
			}
			return 1.0 - a;
		}
	}
}
