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

namespace FuzzyCalcNET.Set
{
	/// <summary>
	/// Description of FuzzySet.
	/// </summary>
	public class FuzzySet :Dictionary<string, Subset.Subset>
	{
		public FuzzySet()
		{
			this["initial"] = new Triangle(0.0, 1.0, 2.0);
		}
	}
}
