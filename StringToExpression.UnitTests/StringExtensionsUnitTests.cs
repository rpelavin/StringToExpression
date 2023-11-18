using System.Linq.Expressions;
using Xunit;
using Evaluate = System.Func<System.Collections.Generic.IDictionary<string, object?>?, object?>;

namespace StringToExpression.UnitTests;

public class StringExtensionsUnitTests
{
    [Fact]
    public void ToExpressionHandlesBooleanLiteral()
    {
        // Arrange & Act
        Expression<Evaluate> expression = "true".ToExpression();

        // Assert
        Assert.Equal(true, expression.Compile()(null));
    }

    [Fact]
    public void ToExpressionHandlesNumericLiteral()
    {
        // Arrange & Act
        Expression<Evaluate> expression = "123".ToExpression();

        // Assert
        Assert.Equal(123, expression.Compile()(null));
    }

    [Fact]
    public void ToExpressionHandlesStringLiteral()
    {
        // Arrange & Act
        Expression<Evaluate> expression = "\"fake_string_value\"".ToExpression();

        // Assert
        Assert.Equal("fake_string_value", expression.Compile()(null));
    }

    [Fact]
    public void ToExpressionHandlesBooleanVariable()
    {
        // Arrange & Act
        Expression<Evaluate> expression = "Variable".ToExpression();

        // Assert
        Dictionary<string, object?> variables = new()
        {
            { "Variable", true }
        };

        Assert.Equal(true, expression.Compile()(variables));
    }

    [Fact]
    public void ToExpressionHandlesNumbericVariable()
    {
        // Arrange & Act
        Expression<Evaluate> expression = "Variable".ToExpression();

        // Assert
        Dictionary<string, object?> variables = new()
        {
            { "Variable", 123 }
        };

        Assert.Equal(123, expression.Compile()(variables));
    }

    [Fact]
    public void ToExpressionHandlesStringVariable()
    {
        // Arrange & Act
        Expression<Evaluate> expression = "Variable".ToExpression();

        // Assert
        Dictionary<string, object?> variables = new()
        {
            { "Variable", "fake_string_value" }
        };

        Assert.Equal("fake_string_value", expression.Compile()(variables));
    }

    [Fact]
    public void ToExpressionHandlesAdd()
    {
        // Arrange & Act
        Expression<Evaluate> expression = "1 + 2".ToExpression();

        // Assert
        Assert.Equal(3, expression.Compile()(null));
    }
}
