namespace BooleanExpression.Node ;

public class IdNode : TerminalNode
{
    public IdNode(int value)
    {
        SymbolCode = value ; 
    }
}