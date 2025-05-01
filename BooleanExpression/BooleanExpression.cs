using System.Text ;
using BooleanExpression.Node ;

namespace BooleanExpression ;

public class BooleanExpression
{
    private readonly Dictionary<Guid, BasicNode> _nodes = new Dictionary<Guid, BasicNode>() ;
    private NonTerminalNode _rootNode ;

    public BooleanExpression()
    {
        _rootNode = new ENode() ;
        _nodes.Add(_rootNode.GetNodeId(), _rootNode) ;
    }

    public Guid GetRootId()
    {
        return _rootNode.GetNodeId();
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
        nt.ClearChildren() ;
    }

    public void CollapseNode(Guid nodeId)
    {
        var node = GetNodeFromId(nodeId) as NonTerminalNode ?? throw new Exception("Node is not non-terminal") ;
        if (!node.HasChildren()) throw new Exception("Node can not be collapsed") ;
        AuxCollapseNode(node) ;
    }

    public Guid GenerateIdProduction(Guid nodeId, string value)
    {
        var node = GetNodeFromId(nodeId) as NonTerminalNode ?? throw new Exception("Node is not a non-terminal node") ;
        if (node.HasChildren()) throw new Exception("Node cannot be expanded.") ;

        var newNode = new IdNode(value) ;

        node.AddChildren([newNode]) ;
        _nodes.Add(newNode.GetNodeId(), newNode) ;
        
        return newNode.GetNodeId() ;
    }

    public (Guid leftChild, Guid rightChild) GenerateBinaryOperatorProduction(Guid nodeId, Operator op)
    {
        var node = GetNodeFromId(nodeId) as NonTerminalNode ?? throw new Exception("Node is not a non-terminal node") ;
        if (node.HasChildren()) throw new Exception("Node cannot be expanded.") ;

        var lhsNode = new ENode() ;
        var rhsNode = new ENode() ;

        node.AddChildren([lhsNode, new OpNode(op), rhsNode]) ;
        _nodes.Add(lhsNode.GetNodeId(), lhsNode) ;
        _nodes.Add(rhsNode.GetNodeId(), rhsNode) ;
        
        return (lhsNode.GetNodeId(), rhsNode.GetNodeId()) ;
    }

    public Guid GenerateUnaryOperatorProduction(Guid nodeId, Operator op)
    {
        var node = GetNodeFromId(nodeId) as NonTerminalNode ?? throw new Exception("Node is not a non-terminal node") ;
        if (node.HasChildren()) throw new Exception("Node cannot be expanded.") ;
        var lhsNode = new ENode() ;
        
        node.AddChildren([new OpNode(op), lhsNode]) ;
        _nodes.Add(lhsNode.GetNodeId(), lhsNode) ;
        
        return lhsNode.GetNodeId() ;
    }

    public Guid GenerateParenthesisProduction(Guid nodeId)
    {
        var node = GetNodeFromId(nodeId) as NonTerminalNode ?? throw new Exception("Node is not a non-terminal node") ;
        if (node.HasChildren()) throw new Exception("Node cannot be expanded.") ;

        var newNode = new ENode() ;

        node.AddChildren([new OpNode(Operator.Leftparen), newNode, new OpNode(Operator.Rightparen)]) ;
        _nodes.Add(newNode.GetNodeId(), newNode) ;
        
        return newNode.GetNodeId() ;
    }

    private void AuxBuildOutputStringBuilder(StringBuilder builder, BasicNode node)
    {
        if (!node.HasChildren()) builder.Append(node) ;
        else
        {
            var ntn = node as NonTerminalNode ?? throw new Exception("Node is not a non-terminal node") ;
            foreach (var c in ntn.Children) AuxBuildOutputStringBuilder(builder, c);
        }
    }

    public void ModifyIdName(Guid nodeId, string name)
    {
        var node = GetNodeFromId(nodeId) as IdNode ?? throw new Exception("Node is not an id node") ;
        node.SubstituteLexeme(name) ;
    }

    public override string ToString()
    {
        StringBuilder builder = new StringBuilder() ;
        
        AuxBuildOutputStringBuilder(builder, _rootNode) ;
        return builder.ToString() ;
        
    }
    
    
}