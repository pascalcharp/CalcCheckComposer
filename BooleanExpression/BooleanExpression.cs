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

    private void AuxCollapseNode(BasicNode node)
    {
        if (!node.HasChildren()) return ;

        var nt = node as NonTerminalNode ?? throw new Exception("A childless node has children") ;
        foreach (var child in nt.Children)
        {
            AuxCollapseNode(child) ;
            _nodes.Remove(child.GetNodeId()) ;
        }
    }

    public void CollapseNode(Guid nodeId)
    {
        var node = GetNodeFromId(nodeId) as NonTerminalNode ?? throw new Exception("Node is not non-terminal") ;
        if (!node.HasChildren()) throw new Exception("Node can not be collapsed") ;
        AuxCollapseNode(node) ;
    }

    public void AddVariableProduction(Guid nodeId, int value)
    {
        var node = GetNodeFromId(nodeId) as NonTerminalNode ?? throw new Exception("Node is not a non-terminal node") ;
        if (node.HasChildren()) throw new Exception("Node cannot be expanded.") ;

        var newNode = new IdNode(value) ;

        node.AddChildren([newNode]) ;
        _nodes.Add(newNode.GetNodeId(), newNode) ;
    }

    public void AddBinaryOperatorProduction(Guid nodeId, Operator op)
    {
        var node = GetNodeFromId(nodeId) as NonTerminalNode ?? throw new Exception("Node is not a non-terminal node") ;
        if (node.HasChildren()) throw new Exception("Node cannot be expanded.") ;

        var lhsNode = new ENode() ;
        var rhsNode = new ENode() ;

        node.AddChildren([lhsNode, new OpNode(op), rhsNode]) ;
        _nodes.Add(lhsNode.GetNodeId(), lhsNode) ;
        _nodes.Add(rhsNode.GetNodeId(), rhsNode) ;
    }

    public void AddUnaryOperatorProduction(Guid nodeId, Operator op)
    {
        var node = GetNodeFromId(nodeId) as NonTerminalNode ?? throw new Exception("Node is not a non-terminal node") ;
        if (node.HasChildren()) throw new Exception("Node cannot be expanded.") ;
        var lhsNode = new ENode() ;
        
        node.AddChildren([new OpNode(op), lhsNode]) ;
        _nodes.Add(lhsNode.GetNodeId(), lhsNode) ;
    }

    public void AddParenthesisProduction(Guid nodeId)
    {
        var node = GetNodeFromId(nodeId) as NonTerminalNode ?? throw new Exception("Node is not a non-terminal node") ;
        if (node.HasChildren()) throw new Exception("Node cannot be expanded.") ;

        var newNode = new ENode() ;

        node.AddChildren([new OpNode(Operator.Leftparen), newNode, new OpNode(Operator.Rightparen)]) ;
        _nodes.Add(newNode.GetNodeId(), newNode) ;
    }
}