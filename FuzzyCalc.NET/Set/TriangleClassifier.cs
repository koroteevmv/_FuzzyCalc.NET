/*
 * Created by SharpDevelop.
 * User: Admin
 * Date: 31.03.2012
 * Time: 1:15
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using FuzzyCalcNET.Subset;

namespace FuzzyCalcNET.Set
{
	/// <summary>
	/// Description of TriangleClassifier.
	/// </summary>
	public class TriangleClassifier :FuzzySet
	{
		public TriangleClassifier(string[] names,
			                          double begin=0.0, double end=1.0,
			                          string name="", 
			                          bool edge=true, double cross=1.0)
		{
			this.Domain = new Domains.RationalRange(begin, end);
			double wide, step, p;
			this.Clear();
			if (names.Length<2) {
				throw new ArgumentException();
			}
			if (!edge) {
				wide = (end-begin)*cross / (2*(names.Length+1));
				step = (end-begin) / (names.Length + 1);
				p = begin+wide;
			}
			else {
				wide = (end-begin)*cross / (names.Length*2 - 2);
				step = (end-begin) / (names.Length - 1);
				p = begin;
			}
			Console.WriteLine("Triangle classifier ctor");
			Console.WriteLine("edge={0}, cross={1}, begin={2}, end={3}, n={4}", edge, cross, begin, end, names.Length);
			Console.WriteLine("wide={0}, step={1}, p={2}", wide, step, p);
			foreach (string term in names) {
				this[term] = new Triangle(p-wide, p, p+wide);
				Console.WriteLine("term={0}, {1}, {2}, {3}", term, p-wide, p, p+wide);
				p+=step;
			}
		}
	}
}
