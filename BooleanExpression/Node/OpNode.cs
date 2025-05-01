namespace BooleanExpression.Node ;

using static BooleanOperators ; 


public class OpNode : TerminalNode
{
    private static readonly Dictionary<Operator, string> OperatorSymbolCode = new Dictionary<Operator, string>()
    {
        { Operator.Leftparen, LeftParenToken },
        { Operator.Rightparen, RightParenToken },
        { Operator.NotOperator, NotOperatorToken },
        { Operator.AndOperator, AndOperatorToken },
        { Operator.OrOperator, OrOperatorToken },
        { Operator.XorOperator, XorOperatorToken },
        { Operator.ImplicationOperator, ImplicationOperatorToken },
        { Operator.ConsequenceOperator, ConsequenceOperatorToken},
        { Operator.EquivalentOperator, EquivalentOperatorToken },
        { Operator.NotEquivalentOperator, NotEquivalentOperatorToken },
    } ; 
    
   private Operator _op ;

   public OpNode(Operator op)
   {
       _op = op;
       Lexeme = OperatorSymbolCode[op] ;
   }

  
}