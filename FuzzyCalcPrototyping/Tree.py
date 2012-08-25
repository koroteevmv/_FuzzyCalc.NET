import sys, clr
sys.path.append("C:\\Users\\sejros\\Documents\\GitHub\\FuzzyCalc.NET\\FuzzyCalc.NET\\bin\\Release")
clr.AddReference("FuzzyCalcNET")
from FuzzyCalcNET import *
from Aggregation import *
       
class Tree(Domains.IDomain):
    '''
    Представляет собой носитель нечеткого множества в виде иерархической
    структуры (дерева), в которой оценка данного узла зависит определенным
    образом от оценок его потомков.
    Конструктор данного класса создает как само дерево, так и его потомков.
    Листовой элемент дерева - это тот, для которого не создано ни одного потомка.
    Синтаксис:
        >>> A=Tree('tree')
        >>> A.add(Tree('branch 1'))
        >>> A.add(Tree('branch 2'))
        >>> A.add(Tree('branch 3'))
        >>> A['branch 1'].add(Tree('branch 1 1'))
        >>> A['branch 1'].add(Tree('branch 1 2'))
        >>> A['branch 1'].add(Tree('branch 1 3'))
        >>> A['branch 1']['branch 1 2'].add(Tree('leaf 1 2 1'))
        >>> A['branch 1']['branch 1 2'].add(Tree('leaf 1 2 2'))
        >>> A['branch 1']['branch 1 2'].add(Tree('leaf 1 2 3'))
        >>> A.char()
        branch 1 3 - None (1.0)
        leaf 1 2 1 - None (1.0)
        leaf 1 2 3 - None (1.0)
        leaf 1 2 2 - None (1.0)
        branch 1 2 - None (1.0)
        branch 1 1 - None (1.0)
        branch 1 - None (1.0)
        branch 2 - None (1.0)
        branch 3 - None (1.0)
        tree - None (1.0)
        >>>A=Tree('name', estim=2.5, weight=0.23, clas=std_3_Classifier(), tnorm=sum_prod)

    Параметры:
        name
            задает имя узла, по которому к нему можно будет обращаться
        estim
            степень принадлежности данного узла
        clas
            классификатор, используемый для оценки уровня данного параметра
        tnorm
            задает используемые при интеграции t-нормы и кономры. Подробнее см.
            FuzzyDomain.t_norm
        agg
            метод аггрегации частных показателей в интегральный.
            См. FuzzyDomain.AggregationMethod
    Переменные класса:
        childs
        name
        estimation
        weight
        classifier
        tnorm
    '''
    # XXX отделить МАИ от иерархического носителя
    # XXX реализовать в интерфейсе Subset иерархический носитель. Без изъебов типа весов и классификаторов. Но с A.value()
    childs={}
    name=''
    estimation=None
    classifier=None
    agg=simple
    tnorm=TNorm.min_max()

    def __init__(self, name='', estim=None, agg=simple(), clas=None, tnorm=TNorm.min_max()):
        self.name=name
        self.estimation=estim
        self.childs={}
        self.agg=agg
        self.classifier=clas
        self.tnorm=tnorm
    def __str__(self):
        '''
        Для быстрого вывода основной информации о дереве, поддереве или листе,
        можно использовать процедуру преобразования к строковому типу.
        Синтаксис:
            >>> T=Tree('tree')
            >>> T.add(Tree('branch 1', 2))
            >>> T.add(Tree('branch 2', 3))
            >>> print T
            tree - 2.5 (1.0)
            >>> print T['branch 1']
            branch 1 - 2 (1.0)

        Данный синтаксис можно комбинировать с синтаксисом __iter__ для вывода
        более полной информации о всех узлах дерева:
            >>> for i in T:
            ...     print i
            ...

        '''
        return self.name+' - '+ str(self.get_estim())
    def __iter__(self):
        '''
        Для быстрого перебора всех дочерних элементов дерева можно использовать
        объект данного класса как итератор. Порядок, в котором возвращаются
        узлы дерева соответствует алгоритму postorder traversal, то есть
        сначала перечисляются все дочерние узлы, затем родительский узел. и так
        для каждого узла, начиная с вершины.
        Синтаксис:
            >>> T=Tree('tree')
            >>> T.add(Tree('branch 1', 2))
            >>> T.add(Tree('branch 2', 3))
            >>> for i in T:
            ...     print i.name
            ...
            branch 1
            branch 2
            tree
        '''
        for leaf in self.childs.values():
            for i in leaf:
                yield i
        yield self
    def add(self, addition):
        '''
        Описание
        Синтаксис:
            >>>
        Параметры:
            Параметр
                описание
        '''
        self.childs[addition.name]=addition
    def get_estim(self):
        if self.estimation or self.estimation==0.0:
            return self.estimation
        else:
            if self.childs==[]:
                return None
            return self.agg._calculate(self)
    def set_estim(self, e):
        self.estimation=e
    def __getitem__(self, param):
        '''
        Для быстрого доступа к любому из дочерних узлов дерева (не обязательно
        прямых потомков) по названию можно использовать следующий синтаксис:
            >>> T=Tree('tree')
            >>> T.add(Tree('branch 1', 2))
            >>> T.add(Tree('branch 2', 3))
            >>> T.char()
            branch 1 - 2 (1.0)
            branch 2 - 3 (1.0)
            tree - 2.5 (1.0)
            >>> print T['branch 1']
            branch 1 - 2 (1.0)
        '''
##        print 'im here!'
        return self.childs[param]
        pass