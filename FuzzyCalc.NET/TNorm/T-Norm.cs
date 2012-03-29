/*
 * Created by SharpDevelop.
 * User: sejros
 * Date: 22.03.2012
 * Time: 12:15
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace FuzzyCalcNET.TNorm
{
	/// <summary>
	/// Description of T_Norm.
	/// </summary>
	public interface T_Norm
	{
		double norm(double a, double b);
		double conorm(double a, double b);
		double neg(double a);
	}
}
