/*
 * Created by SharpDevelop.
 * User: Admin
 * Date: 30.03.2012
 * Time: 2:56
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using FuzzyCalcNET.TNorm;
using FuzzyCalcNET.Domains;

namespace FuzzyCalcNET.Subset
{
	/// <summary>
	/// Description of Gaussian.
	/// </summary>
	public class Gaussian :Subset
	{
		double mu, omega;
		public Gaussian(double mu, double omega)
		{
			this.mu = mu;
			this.omega = omega;
			this.Norm = new naive();
			this.Domain = new RationalRange(mu - 5*omega, mu + 5*omega);
		}
		public override double membership(double x)
		{
			return Math.Exp(-((x-mu)*(x-mu))/(2*omega*omega));
		}
		public override double centroid()
		{
			return mu;
		}
	}
}
