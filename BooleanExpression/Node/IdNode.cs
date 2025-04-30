namespace BooleanExpression.Node ;

public class IdNode : TerminalNode
{
    public IdNode(string value)
    {
        Lexeme = value ; 
    }

    
}