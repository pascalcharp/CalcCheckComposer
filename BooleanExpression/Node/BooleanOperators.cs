namespace BooleanExpression.Node ;

public enum Operator
{
    Leftparen,
    Rightparen,
    NotOperator,
    AndOperator,
    OrOperator,
    XorOperator,
    ImplicationOperator,
    ConsequenceOperator,
    EquivalentOperator,
    NotEquivalentOperator,
}

public static class BooleanOperators
{
    public const string LeftParenToken = " ( " ;
    public const string RightParenToken = " ) " ;
    public const string NotOperatorToken = " NOT " ;
    public const string AndOperatorToken = " AND " ;
    public const string OrOperatorToken = " OR " ;
    public const string XorOperatorToken = " XOR " ;
    public const string ImplicationOperatorToken = " IMPL " ;
    public const string ConsequenceOperatorToken = " CONS " ;
    public const string EquivalentOperatorToken = " EQ " ;
    public const string NotEquivalentOperatorToken = " NEQ " ;
}