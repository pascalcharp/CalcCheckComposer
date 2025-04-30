namespace BooleanExpression.Node ;

public abstract class TerminalNode : BasicNode
{
    protected string Lexeme = string.Empty ;
    
    public override bool HasChildren()
    {
        return false ; 
    }

    public override string ToString()
    {
        return Lexeme ;
    }
}