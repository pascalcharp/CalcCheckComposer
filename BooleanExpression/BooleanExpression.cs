using BooleanExpression.Node ;

namespace BooleanExpression ;

public class BooleanExpression
{
    private Dictionary<Guid, BasicNode> _nodes = new Dictionary<Guid, BasicNode>() ;
    private NonTerminalNode _rootNode ;

    public BooleanExpression()
    {
        _rootNode = new ENode() ;
        _nodes.Add(_rootNode.GetNodeId(), _rootNode) ;
    }

    private BasicNode GetNodeFromId(Guid nodeId)
    {
        return _nodes[nodeId] ;
    }

    public void ExpandNode(Guid nodeId, Operator operatorValue)
    {
        var node = GetNodeFromId(nodeId) ;
        if (node.HasChildren()) throw new Exception( "Node cannot be expanded." ) ;
        
        
    }
    
    
}