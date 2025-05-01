namespace BooleanExpression.Node ;

public class ENode : NonTerminalNode
{
    public override string ToString()
    {
        return "E" ; 
    }

    public override BasicNode GetCopy()
    {
        var copyNode = new ENode() ;
        foreach (var child in Children)
        {
            copyNode.Children.Add(child.GetCopy()) ;
        }
        return copyNode ;
    }
}