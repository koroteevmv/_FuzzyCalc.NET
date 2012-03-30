/*
 * Created by SharpDevelop.
 * User: Admin
 * Date: 30.03.2012
 * Time: 3:25
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections;
using System.Collections.Generic;
using FuzzyCalcNET.Subset;
using FuzzyCalcNET.Domains;

namespace FuzzyCalcNET.Set
{
	/// <summary>
	/// Description of FuzzySet.
	/// </summary>
	public class FuzzySet :Dictionary<string, Subset.Subset>
	{
		protected string name;
		protected IDomain Domain;
		
		public FuzzySet(string name = "", double begin = 0.0, double end = 1.0)
		{
			this.name = name;
			this.Domain = new RationalRange(begin, end);
		}
		public double find(double x, string term)
		{
			return this[term].membership(x);
		}
		public string classify(double x)
		{
			string res= "";
			foreach (string term in this.Keys) {
				double mem = this.find(x, term);
				if (this.ContainsKey(res) && mem > this.find(x, res)) {
					res = term;
				}
			}
			return res;
		}
	}
}
