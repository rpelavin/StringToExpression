using System.Linq.Expressions;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;
using Evaluate = System.Func<System.Collections.Generic.IDictionary<string, object?>?, object?>;

namespace StringToExpression;

public static class StringExtensions
{
    public static Expression<Evaluate> ToExpression(this string value)
    {
        ParameterExpression parameter = Expression.Parameter(typeof(IDictionary<string, object?>));
        return Expression.Lambda<Evaluate>(
            Expression.Convert(
                ParseExpression(value).ToExpression(parameter),
                typeof(object)),
            parameter);
    }
}
