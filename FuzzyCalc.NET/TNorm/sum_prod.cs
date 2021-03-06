﻿/*
 * Created by SharpDevelop.
 * User: sejros
 * Date: 22.03.2012
 * Time: 13:45
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace FuzzyCalcNET.TNorm
{
	/// <summary>
	/// Description of sum_prod.
	/// </summary>
	public class sum_prod :T_Norm
	{		
		public double norm(double a, double b)
		{
			if (0.0>a || a>1.0 || 0.0>b || b>1.0) {
				throw new ArgumentException();
			}
			return Math.Min(Math.Max(a*b, 0), 1);
		}
		
		public double conorm(double a, double b)
		{
			if (0.0>a || a>1.0 || 0.0>b || b>1.0) {
				throw new ArgumentException();
			}
			return Math.Min(Math.Max(a+b-a*b, 0), 1);
		}
		
		public double neg(double a)
		{
			throw new NotImplementedException();
		}
	}
}
