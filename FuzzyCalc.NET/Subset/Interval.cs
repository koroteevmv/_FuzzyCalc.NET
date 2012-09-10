/*
 * Created by SharpDevelop.
 * User: Admin
 * Date: 08.09.2012
 * Time: 1:23
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using FuzzyCalcNET.Domains;

namespace FuzzyCalcNET.Subset
{
	/// <summary>
	/// Description of Interval.
	/// </summary>
	public class Interval : Subset
	{
		public Interval(double begin, double end)
		{
			if (end<begin) {
				throw new ArgumentException();
			}
			this.Domain = new RationalRange(begin, end);
		}
		public Interval(IDomain domain)
		{
			this.Domain = domain;
		}
		public override double membership(double x)
		{
			if (x>=this.Domain.begin && x<=this.Domain.end) {
				return 1.0;
			}
			else {
				return 0.0;
			}
		}
		public override double centroid()
		{
			return (this.Domain.begin + this.Domain.end)/2;
		}
	}
}
