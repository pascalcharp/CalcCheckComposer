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
    private static readonly Dictionary<Operator, string> OperatorSymbolCode = new Dictionary<Operator, string>()
    {
        { Operator.Leftparen, "(" },
        { Operator.Rightparen, ")" },
        { Operator.NotOperator, "NOT" },
        { Operator.AndOperator, "AND" },
        { Operator.OrOperator, "OR" },
        { Operator.XorOperator, "XOR" },
        { Operator.ImplicationOperator, "IMPL" },
        { Operator.ConsequenceOperator, "CONS" },
        { Operator.EquivalentOperator, "EQ" },
        { Operator.NotEquivalentOperator, "NEQ" },
    } ; 
    
   private Operator _op ;

   public OpNode(Operator op)
   {
       _op = op;
       Lexeme = OperatorSymbolCode[op] ;
   }

  
}