using BooleanExpression.Node ;

namespace BooleanExpressionTests ;

using BooleanExpression ;
using static BooleanOperators ;

public class Tests
{
    [Test]
    public void RootTest()
    {
        var be = new BooleanExpression() ; 
        Assert.That(be.ToString(), Is.EqualTo("E")) ;
    }

    [Test]
    public void AndTest()
    {
        var be = new BooleanExpression() ;
        var rootId = be.GetRootId() ; 
        be.GenerateBinaryOperatorProduction(rootId, Operator.AndOperator) ;
        
        string expected = $"E{AndOperatorToken}E" ; 
        Assert.That(be.ToString(), Is.EqualTo(expected)) ;
    }

    [Test]
    public void CollapseAndTest()
    {
        var be = new BooleanExpression() ;
        var rootId = be.GetRootId() ;
        
        be.GenerateBinaryOperatorProduction(rootId, Operator.AndOperator) ;
        be.CollapseNode(rootId) ;
        
        Assert.That(be.ToString(), Is.EqualTo("E")) ;
    }

    [Test]
    public void AndOrTest()
    {
        var be = new BooleanExpression() ;
        var rootId = be.GetRootId() ;
        
        var children = be.GenerateBinaryOperatorProduction(rootId, Operator.AndOperator) ;
        be.GenerateBinaryOperatorProduction(children.leftChild, Operator.OrOperator) ;
        
        string expected = $"E{OrOperatorToken}E{AndOperatorToken}E" ;
        Assert.That(be.ToString(), Is.EqualTo(expected)) ;
        
        be.GenerateBinaryOperatorProduction(children.rightChild, Operator.OrOperator) ;
        
        string expected2 = $"E{OrOperatorToken}E{AndOperatorToken}E{OrOperatorToken}E" ;
        Assert.That(be.ToString(), Is.EqualTo(expected2)) ;
    }

    [Test]
    public void ParenthesisTest()
    {
        var be = new BooleanExpression() ;
        var rootId = be.GetRootId() ;
        
        var child = be.GenerateParenthesisProduction(rootId) ;
        var children = be.GenerateBinaryOperatorProduction(child, Operator.OrOperator) ;
        Assert.That(be.ToString(), Is.EqualTo($"{LeftParenToken}E{OrOperatorToken}E{RightParenToken}")) ;
    }

    [Test]
    public void NotTest()
    {
        var be = new BooleanExpression() ;
        var rootId = be.GetRootId() ;
        be.GenerateUnaryOperatorProduction(rootId, Operator.NotOperator) ;
        Assert.That(be.ToString(), Is.EqualTo($"{NotOperatorToken}E")) ;
    }

    [Test]
    public void IdTest()
    {
        var be = new BooleanExpression() ;
        var rootId = be.GetRootId() ;
        be.GenerateIdProduction(rootId, "Coco") ;
        Assert.That(be.ToString(), Is.EqualTo("Coco")) ;
    }
}