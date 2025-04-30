using BooleanExpression.Node ;

namespace BooleanExpressionTests ;

using BooleanExpression ;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

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
        be.AddBinaryOperatorProduction(rootId, Operator.AndOperator) ;
        Assert.That(be.ToString(), Is.EqualTo("EANDE")) ;
    }

    [Test]
    public void CollapseAndTest()
    {
        var be = new BooleanExpression() ;
        var rootId = be.GetRootId() ;
        be.AddBinaryOperatorProduction(rootId, Operator.AndOperator) ;
        be.CollapseNode(rootId) ;
        Assert.That(be.ToString(), Is.EqualTo("E")) ;
    }

    [Test]
    public void AndOrTest()
    {
        var be = new BooleanExpression() ;
        var rootId = be.GetRootId() ;
        var children = be.AddBinaryOperatorProduction(rootId, Operator.AndOperator) ;
        be.AddBinaryOperatorProduction(children.leftChild, Operator.OrOperator) ;
        Assert.That(be.ToString(), Is.EqualTo("EOREANDE")) ;
        be.AddBinaryOperatorProduction(children.rightChild, Operator.OrOperator) ;
        Assert.That(be.ToString(), Is.EqualTo("EOREANDEORE")) ;
    }
}