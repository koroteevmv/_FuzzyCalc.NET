/*
 * Created by SharpDevelop.
 * User: Admin
 * Date: 31.08.2012
 * Time: 23:18
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections;
using System.Collections.Generic;

using FuzzyCalcNET.Subset;

namespace FuzzyCalcNET.Controller
{
	/// <summary>
	/// Description of Aggregation.
	/// </summary>
	public interface IAggregation
	{
		double[] crisp_input{get;set;}
		Subset.Subset[] fuzzy_input{get;set;}
		double calculate_crisp();
		Subset.Subset calculate_fuzzy();
		
	}
	public class Average: IAggregation
	{
		public double[] crisp_input{get;set;}
		
		public Subset.Subset[] fuzzy_input{get;set;}
		
		public Average()
		{
			this.crisp_input = new double[0];
			this.fuzzy_input = new Subset.Subset[0];
		}
		
		protected double _calculate_crisp()
		{
			int count = 0;
			double sum = 0.0;
			foreach (var element in this.crisp_input) {
				sum+=element;
				count++;
			}
			return sum/count;
		}
		
		protected Subset.Subset _calculate_fuzzy()
		{
			int count = 0;
			Subset.Subset sum = new Subset.Subset();
			foreach (var element in this.fuzzy_input) {
				sum+=element;
				count++;
			}
			return sum/count;
		}				
		
		public double calculate_crisp()
		{
			if (this.crisp_input.Length==0) {
				if (this.fuzzy_input.Length==0) {
					throw new MissingFieldException();
				}	
				return this._calculate_fuzzy().centroid();
			}
			else{
				return this._calculate_crisp();
			}
		}
		
		public FuzzyCalcNET.Subset.Subset calculate_fuzzy()
		{
			if (this.crisp_input.Length==0) {
				if (this.fuzzy_input.Length==0) {
					throw new MissingFieldException();
				}	
				return this._calculate_fuzzy();
			}
			else{
				// TODO: Implement Point fuzzy subset
//				return Subset.Point(this._calculate_crisp());
				throw new NotImplementedException();
			}
		}
	}
	public class WeightedAverage: Average
	{
		public double[] weights {get; set;}
		public WeightedAverage()
		{
			this.crisp_input = new double[0];
			this.fuzzy_input = new Subset.Subset[0];
			this.weights = new double[0];
		}
		
		public double calculate_crisp()
		{
			if (this.crisp_input.Length==0){
				throw new MissingFieldException();
			}
			if (this.weights.Length==0){
				throw new MissingFieldException();
			}
			if (this.crisp_input.Length!=this.weights.Length){
				throw new ArgumentException();
			}
			double count = 0.0;
			double sum = 0.0;
			for (int i = 0; i < this.crisp_input.Length; i++) {
				sum+=this.crisp_input[i]*this.weights[i];
				count+=this.weights[i];
			}
			return sum/count;
		}
	}
	
	public interface IRuled: IAggregation
	{
		Rule[] rules {get; set;}
		void add_rule(Rule r);
	}
	public class Mamdani: IRuled
	{		
		public Rule[] rules {get; set;}
		public double[] crisp_input {get; set;}
		public FuzzyCalcNET.Subset.Subset[] fuzzy_input {get; set;}
		
		public void add_rule(Rule r)
		{
			throw new NotImplementedException();
		}
		private double _calculate_crisp()
		{
			Subset.Subset res; //  = new Interval(begin, end)*0.0;
			foreach (Rule rule in this.rules) {
				double alpha = 1.0;
				foreach (KeyValuePair<string, string> factor in rule.ant) {
					string factor_name = factor.Key;
					string factor_class= factor.Value;
				}
			}
		}
		
		public double calculate_crisp()
		{
			throw new NotImplementedException();
		}
		
		public FuzzyCalcNET.Subset.Subset calculate_fuzzy()
		{
			throw new NotImplementedException();
		}
	}
}
