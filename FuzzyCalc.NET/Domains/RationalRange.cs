/*
 * Created by SharpDevelop.
 * User: sejros
 * Date: 21.03.2012
 * Time: 12:49
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections;

namespace FuzzyCalcNET.Domains
{
	/// <summary>
	/// Description of RationalRange.
	/// </summary>

//	const accuracy = 0.0001;
	public class RationalRange: IDomain
	{
		public double begin{
			get{
				return this.B;
			}
			set{
				if (value>this.end){ throw new ArgumentException();}
				else {this.B = value;}
			}
		}
		public double end{
			get{
				return this.E;
			}
			set{
				if (value<this.begin){ throw new ArgumentException();}
				else {this.E = value;}
			}
		}
		public double step
			{get; set;}
		double B, E;
		
		public RationalRange(double begin = 0.0, double end =1.0, double step = 1.0/(double)Accuracy.Accuracy)
		{
			this.end = end;
			this.begin = begin;
			this.step = step;
		}
		
		public IEnumerator GetEnumerator()
		{
			double res = this.begin;
			yield return res;
			while (Math.Round(res, (int)Math.Log10((double)Accuracy.Accuracy))+this.step<=this.end) {
				res+=this.step;
				yield return Math.Round(res, (int)Math.Log10((double)Accuracy.Accuracy));
			}
		}
	}
}
