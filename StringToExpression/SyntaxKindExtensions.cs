using Microsoft.CodeAnalysis.CSharp;
using System.Linq.Expressions;

namespace StringToExpression;

internal static class SyntaxKindExtensions
{
    public static ExpressionType ToExpressionType(this SyntaxKind syntaxKind)
    {
        return syntaxKind switch
        {
            SyntaxKind.AddExpression => ExpressionType.Add,
            SyntaxKind.SubtractExpression => ExpressionType.Subtract,
            SyntaxKind.MultiplyExpression => ExpressionType.Multiply,
            SyntaxKind.DivideExpression => ExpressionType.Divide,
            SyntaxKind.ModuloExpression => ExpressionType.Modulo,
            SyntaxKind.LeftShiftExpression => ExpressionType.LeftShift,
            SyntaxKind.RightShiftExpression => ExpressionType.RightShift,
            SyntaxKind.LogicalOrExpression => ExpressionType.Or,
            SyntaxKind.LogicalAndExpression => ExpressionType.And,
            SyntaxKind.BitwiseOrExpression => ExpressionType.Or,
            SyntaxKind.BitwiseAndExpression => ExpressionType.And,
            SyntaxKind.ExclusiveOrExpression => ExpressionType.ExclusiveOr,
            SyntaxKind.EqualsExpression => ExpressionType.Equal,
            SyntaxKind.NotEqualsExpression => ExpressionType.NotEqual,
            SyntaxKind.LessThanExpression => ExpressionType.LessThan,
            SyntaxKind.LessThanOrEqualExpression => ExpressionType.LessThanOrEqual,
            SyntaxKind.GreaterThanExpression => ExpressionType.GreaterThan,
            SyntaxKind.GreaterThanOrEqualExpression => ExpressionType.GreaterThanOrEqual,
            SyntaxKind.IsExpression => ExpressionType.TypeIs,
            SyntaxKind.AsExpression => ExpressionType.TypeAs,
            SyntaxKind.CoalesceExpression => ExpressionType.Coalesce,
            SyntaxKind.SimpleMemberAccessExpression => ExpressionType.MemberAccess,
            SyntaxKind.PointerMemberAccessExpression => ExpressionType.MemberAccess,
            SyntaxKind.ConditionalAccessExpression => ExpressionType.MemberAccess,
            SyntaxKind.UnsignedRightShiftExpression => ExpressionType.RightShift,
            _ => throw new NotImplementedException(syntaxKind.ToString())
        };
    }
}
