namespace BooleanExpression.Node ;

public abstract class NonTerminalNode : BasicNode
{
    private  List<BasicNode> Children { get ;  } = new() ;

    public void AddChildren(List<BasicNode> newChildren)
    {
        Children.AddRange(newChildren) ;
    }

    public void ClearChildren()
    {
        Children.Clear() ;
    }

    public override bool HasChildren()
    {
        return Children.Count != 0 ;
    }
}