namespace BooleanExpression.Node ;

public class IdNode : TerminalNode
{
    public IdNode(string value)
    {
        Lexeme = value ; 
    }

    public void SubstituteLexeme(string value)
    {
        Lexeme = value ;
    }

    public override BasicNode GetCopy()
    {
        return new IdNode(Lexeme) ;
    }
}