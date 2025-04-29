namespace BooleanExpression.Node ;

public enum Operator
{
    Leftparen,
    Rightparen,
    NotOperator,
    AndOperator,
    OrOperator,
    XorOperator,
    ImplicationOperator,
    ConsequenceOperator,
    EquivalentOperator,
    NotEquivalentOperator,
}


public class OpNode : TerminalNode
{
    private static readonly Dictionary<Operator, int> OperatorSymbolCode = new Dictionary<Operator, int>()
    {
        { Operator.Leftparen, 1 },
        { Operator.Rightparen, 2 },
        { Operator.NotOperator, 1 },
        { Operator.AndOperator, 1 },
        { Operator.OrOperator, 1 },
        { Operator.XorOperator, 1 },
        { Operator.ImplicationOperator, 1 },
        { Operator.ConsequenceOperator, 1 },
        { Operator.EquivalentOperator, 1 },
        { Operator.NotEquivalentOperator, 1 },
    } ; 
    
   private Operator _op ;

   public OpNode(Operator op)
   {
       _op = op;
       SymbolCode = OperatorSymbolCode[op] ;
   }
}