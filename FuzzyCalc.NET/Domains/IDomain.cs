/*
 * Created by SharpDevelop.
 * User: sejros
 * Date: 21.03.2012
 * Time: 12:46
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections;

namespace FuzzyCalcNET.Domains
{
	enum Accuracy: ulong
	{
		Accuracy = 1000
	}
	/// <summary>
	/// Description of Domains.
	/// </summary>
	public interface IDomain: IEnumerable
	{
		double begin{get; set;}
		double end{get; set;}
	}
}
