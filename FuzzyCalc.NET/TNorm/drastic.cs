/*
 * Created by SharpDevelop.
 * User: sejros
 * Date: 22.03.2012
 * Time: 17:55
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace FuzzyCalcNET.TNorm
{
	/// <summary>
	/// Description of drastic.
	/// </summary>
	public class drastic :T_Norm
	{
		public double norm(double a, double b)
		{
			if (0.0>a || a>1.0 || 0.0>b || b>1.0) {
				throw new ArgumentException();
			}
			else if (a==1.0) {
				return b;
			}
			else if (b==1.0) {
				return a;
			}
			else
			{
				return 0.0;
			}
		}
		
		public double conorm(double a, double b)
		{
			if (0.0>a || a>1.0 || 0.0>b || b>1.0) {
				throw new ArgumentException();
			}
			else if (a==0.0) {
				return b;
			}
			else if (b==0.0) {
				return a;
			}
			else
			{
				return 1.0;
			}
		}
		
		public double neg(double a)
		{
			throw new NotImplementedException();
		}
	}
}
