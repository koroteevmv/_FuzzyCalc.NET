import sys
sys.path.append("C:\\Users\\sejros\\Documents\\GitHub\\FuzzyCalc.NET\\FuzzyCalc.NET\\bin\\Release")
##import IronPython
import clr;
clr.AddReference("FuzzyCalcNET")
from FuzzyCalcNET import *


from Aggregation import *
from Rule import *
from Tree import *


A=Tree('tree')

raw_input()