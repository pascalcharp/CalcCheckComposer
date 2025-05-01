namespace BooleanExpression.Node ;

public abstract class BasicNode
{
    
    private readonly Guid _uuid  ;

    protected BasicNode()
    {
        _uuid = Guid.NewGuid() ;
    }

    public abstract BasicNode GetCopy() ; 
    
    public Guid GetNodeId()
    {
        return _uuid ;
    }
    
    public abstract bool HasChildren() ;
    
    
}