/*
 * Created by SharpDevelop.
 * User: sejros
 * Date: 22.03.2012
 * Time: 12:17
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace FuzzyCalcNET.TNorm
{
	/// <summary>
	/// Description of min_max.
	/// </summary>
	public class min_max :T_Norm
	{		
		public double norm(double a, double b)
		{
			if (0.0>a || a>1.0 || 0.0>b || b>1.0) {
				throw new ArgumentException();
			}
			return Math.Max(Math.Min(Math.Min(a, b), 1), 0);
		}
		
		public double conorm(double a, double b)
		{
			if (0.0>a || a>1.0 || 0.0>b || b>1.0) {
				throw new ArgumentException();
			}
			return Math.Min(Math.Max(Math.Max(a, b), 0), 1);
		}
		
		public double neg(double a)
		{
			throw new NotImplementedException();
		}
	}
}
