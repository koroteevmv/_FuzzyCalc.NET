/*
 * Created by SharpDevelop.
 * User: sejros
 * Date: 21.03.2012
 * Time: 17:05
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using FuzzyCalcNET.Domains;
using System.Collections.Generic;
using FuzzyCalcNET.TNorm;

namespace FuzzyCalcNET.Subset
{	
	/// <summary>
	/// Description of Subset.
	/// </summary>
	public class Subset
	{
		public IDomain Domain;
		public object Property { get; set; }
		public Dictionary<double, double> Values;
		protected T_Norm Norm;
		
		public Subset(IDomain domain)
		{
			this.Domain = domain;
			this.Values = new Dictionary<double, double>();
			this.Norm = new naive();
		}
		public Subset(double begin=0.0, double end=1.0)
		{
			this.Domain = new RationalRange(begin: begin, end: end);
			this.Values = new Dictionary<double, double>();
			this.Norm = new naive();
		}
		public void set_value(double x, double m)
		{
			x = Math.Round(x, 8);
			m = Math.Max(Math.Min(Math.Round(m, 8), 1), 0);
			if (x>this.Domain.end || x<this.Domain.begin) {
				throw new ArgumentException();
			}
			this.Values[x]=m;
		}
		public virtual double membership(double x)
		{
			if (x>this.Domain.end || x<this.Domain.begin)
			{
				return 0.0;
			}
			else
			{
				return this.Values[x];
			}			
		}
		
		public virtual double centroid()
		{
			double sum = 0.0;
			double j = 0.0;
			foreach (double elem in this.Domain) {
				double m = this.membership(elem);
				sum += m*elem;
				j += m;
			}
			return sum/j;
		}
		
		public static Subset operator + (Subset a, Subset b)
		{
			Subset res = new Subset(domain: new RationalRange(
				begin: Math.Min(a.Domain.begin, b.Domain.begin),
				end: Math.Max(a.Domain.end, b.Domain.end)
			));
			foreach (double num in res.Domain) {
				double mem = a.Norm.conorm(a.membership(num), b.membership(num));
				res.set_value(num, mem);
			}
			res.Norm = a.Norm;
			return res;
		}
		public static Subset operator + (Subset a, double b)
		{
			Subset res = new Subset(new RationalRange(
										begin: a.Domain.begin,
										end: a.Domain.end
									));
			foreach (double num in res.Domain) {
				res.set_value(num, a.membership(num)+b);
			}
			return res;
		}
		public static Subset operator + (double a, Subset b)
		{
			return b+a;
		}
		public static Subset operator - (Subset a, double b)
		{
			return a + (0-b);
		}
		public static Subset operator - (double b, Subset a)
		{
			Subset res = new Subset(new RationalRange(
										begin: a.Domain.begin,
										end: a.Domain.end
									));
			foreach (double num in res.Domain) {
				res.set_value(num, b - a.membership(num));
			}
			return res;
		}
		public static Subset operator * (Subset a, double k)
		{
			Subset res = new Subset(new RationalRange(
										begin: a.Domain.begin,
										end: a.Domain.end
									));
			foreach (double num in res.Domain) {
				res.set_value(num, a.membership(num)*k);
			}
			return res;
		}
		public static Subset operator * (double a, Subset b)
		{
			return b*a;
		}
		public static Subset operator / (Subset a, double b)
		{
			return a * (1/b);
		}
		public static Subset operator / (double b, Subset a)
		{
			Subset res = new Subset(new RationalRange(
										begin: a.Domain.begin,
										end: a.Domain.end
									));
			foreach (double num in res.Domain) {
				res.set_value(num, b / a.membership(num));
			}
			return res;
		}
		public static Subset operator ^ (Subset a, double b)
		{
			Subset res = new Subset(new RationalRange(
										begin: a.Domain.begin,
										end: a.Domain.end
									));
			foreach (double num in res.Domain) {
				res.set_value(num, Math.Pow(a.membership(num), b));
			}
			return res;
		}
		public Subset con()
		{
			return this^2;
		}
		public Subset dil()
		{
			return this^0.5;
		}
	}
}
