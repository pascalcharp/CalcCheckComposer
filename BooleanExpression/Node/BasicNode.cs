namespace BooleanExpression.Node ;

public abstract class BasicNode
{
    
    private readonly Guid _uuid  ;

    protected BasicNode()
    {
        _uuid = Guid.NewGuid() ;
    }

    protected BasicNode(BasicNode source)
    {
        _uuid = Guid.NewGuid () ;
    }

    public Guid GetNodeId()
    {
        return _uuid ;
    }
    
    public abstract bool HasChildren() ;
    
    
}