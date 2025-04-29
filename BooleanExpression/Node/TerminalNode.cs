namespace BooleanExpression.Node ;

public abstract class TerminalNode : BasicNode
{
    protected int SymbolCode ;
    
    public override bool HasChildren()
    {
        return false ; 
    }
}