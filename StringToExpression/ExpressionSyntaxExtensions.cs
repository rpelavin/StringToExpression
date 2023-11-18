using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Linq.Expressions;

namespace StringToExpression;

internal static class ExpressionSyntaxExtensions
{
    public static Expression ToExpression(
        this ExpressionSyntax expressionSyntax,
        ParameterExpression parameterExpression)
    {
        return expressionSyntax switch
        {
            BinaryExpressionSyntax syntax => Expression.MakeBinary(
                syntax.Kind().ToExpressionType(),
                syntax.Left.ToExpression(parameterExpression),
                syntax.Right.ToExpression(parameterExpression)),
            IdentifierNameSyntax syntax => Expression.MakeIndex(
                parameterExpression,
                typeof(IDictionary<string, object?>).GetProperty("Item"),
                new[] { Expression.Constant(syntax.Identifier.ValueText) }),
            LiteralExpressionSyntax syntax => Expression.Constant(syntax.Token.Value),
            _ => throw new NotImplementedException(expressionSyntax.GetType().Name)
        };
    }
}
