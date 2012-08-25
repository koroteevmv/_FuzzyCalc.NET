import sys, clr
sys.path.append("C:\\Users\\sejros\\Documents\\GitHub\\FuzzyCalc.NET\\FuzzyCalc.NET\\bin\\Release")
clr.AddReference("FuzzyCalcNET")
from FuzzyCalcNET import *


class Rule:
    '''
    Описание
    Синтаксис:
        >>>
    '''
    ant={}
    concl=''
    name=''
    alpha=''
    def __init__(self, ant={}, concl='',  name=''):
        self.concl=concl
        self.name=name
        self.ant=ant
    def __str__(self):
        res=str(self.name)+': '
        for (name, value) in self.ant.iteritems():
            res+=str(name)+'='+value+' '
        res+=' -> '+str(self.concl) + '(' + str(self.alpha)+')'
        return res