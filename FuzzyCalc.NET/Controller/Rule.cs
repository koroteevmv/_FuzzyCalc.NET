/*
 * Created by SharpDevelop.
 * User: Admin
 * Date: 31.08.2012
 * Time: 23:09
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;

namespace FuzzyCalcNET.Controller
{
	/// <summary>
	/// Description of Rule.
	/// </summary>
	public class Rule
	{
		public string name="";     // name of the rule
		public string concl="";    // conclusion
		public Dictionary<string, string> ant=new Dictionary<string, string>();
		public Rule(string name, string concl, Dictionary<string, string> ant)
		{
			this.name = name;
			this.concl = concl;
			this.ant = ant;
		}
	}
}
