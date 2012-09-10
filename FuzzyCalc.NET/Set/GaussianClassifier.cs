/*
 * Created by SharpDevelop.
 * User: Admin
 * Date: 31.03.2012
 * Time: 1:40
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using FuzzyCalcNET.Subset;

namespace FuzzyCalcNET.Set
{
	/// <summary>
	/// Description of GaussianClassifier.
	/// </summary>
	public class GaussianClassifier :FuzzySet
	{
		public GaussianClassifier(string[] names,
			                          double begin=0.0, double end=1.0,
			                          string name="", 
			                          bool edge=false, double cross=1.0)
		{
			this.Domain = new Domains.RationalRange(begin, end);
			double wide, step, p;
			if (names.Length<2) {
				throw new ArgumentException();
			}
			if (!edge) {
				wide = (end-begin)*cross / (2*(names.Length+1));
				step = (end-begin) / (names.Length + 1);
				p = begin + (end-begin) / (names.Length + 1);
			}
			else {
				wide = (end-begin)*cross / (names.Length*2 - 2);
				step = (end-begin) / (names.Length - 1);
				p = begin;
			}
//			Console.WriteLine("Gaussian classifier ctor");
//			Console.WriteLine("edge={0}, cross={1}, begin={2}, end={3}, n={4}", edge, cross, begin, end, names.Length);
//			Console.WriteLine("wide={0}, step={1}, p={2}", wide, step, p);
			foreach (string term in names) {
				this[term] = new Gaussian(p, wide/3.0);
				p+=step;
			}
		}
	}
}
