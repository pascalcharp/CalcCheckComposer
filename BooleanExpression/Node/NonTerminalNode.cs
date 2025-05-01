namespace BooleanExpression.Node ;

public abstract class NonTerminalNode : BasicNode
{
    public  List<BasicNode> Children { get ;  }  = new([]) ;

    protected NonTerminalNode()
    {
       
    }

    protected NonTerminalNode(NonTerminalNode source) : base(source)
    {
        foreach (var node in source.Children) Children.Add(new IdNode(node));
    }

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