/*
 * Created by SharpDevelop.
 * User: sejros
 * Date: 21.03.2012
 * Time: 16:46
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;

namespace FuzzyCalcNET.Domains
{
	/// <summary>
	/// Description of IntegerRange.
	/// </summary>
	public class IntegerRange: RationalRange
	{
		public IntegerRange(int begin = 0, int end = 100)
		{
			this.begin = begin;
			this.end = end;
			this.step = 1.0;
		}
	}
}
