using System;
using System.Collections.Generic;
using MathInterpreter;
using Xunit;
using Xunit.Abstractions;

namespace MathInterpreter.Tests
{
    public class ParserTests
    {
        private readonly ITestOutputHelper output;

        public ParserTests(ITestOutputHelper output)
        {
            this.output = output;
        }

        [Fact]
        public void TestEmpty()
        {
            var expected = new Node
            (
                NodeType.EmptyNode
            );
            var parser = new Parser(new List<Token>(){ new Token(TokenType.EOF) });
            var tree = parser.Parse();
            Assert.Equal(expected, tree);
        }

        [Fact]
        public void TestNumbers()
        {
            var expected = new Node
            (
                NodeType.NumberNode,
                51.2
            );
            var input = new List<Token>()
            {
                new Token(TokenType.NUMBER, 51.2),
                new Token(TokenType.EOF),
            };
            var parser = new Parser(input);
            var tree = parser.Parse();
            Assert.Equal(expected, tree);
        }

        [Theory]
        [InlineData(NodeType.AddNode, TokenType.PLUS, 45.12, 12.43)]
        [InlineData(NodeType.SubtractNode, TokenType.MINUS, 1.0, 34.2)]
        [InlineData(NodeType.MultiplyNode, TokenType.MULTIPLY, 19.435, 56.71)]
        [InlineData(NodeType.DivideNode, TokenType.DIVIDE, 45.19, 22.43)]
        [InlineData(NodeType.PowerNode, TokenType.POWER, 3.12, 34.53)]
        public void TestSingeOperators(NodeType expectedType, TokenType inputType, double num1, double num2)
        {
            var expected = new Node
            (
                expectedType,
                new Node(NodeType.NumberNode, num1),
                new Node(NodeType.NumberNode, num2)
            );
            var input = new List<Token>()
            {
                new Token(TokenType.NUMBER, num1),
                new Token(inputType),
                new Token(TokenType.NUMBER, num2),
                new Token(TokenType.EOF),
            };
            var parser = new Parser(input);
            var tree = parser.Parse();
            Assert.Equal(expected, tree);
        }

        [Fact]
        public void TestFactorialOperator()
        {
            var expected = new Node(NodeType.FactorialNode,
                new Node(NodeType.NumberNode, 10.0)
            );

            var input = new List<Token>()
            {
                new Token(TokenType.NUMBER, 10.0),
                new Token(TokenType.FACTORIAL),
                new Token(TokenType.EOF)
            };

            var parser = new Parser(input);
            var tree = parser.Parse();
            Assert.Equal(expected, tree);
        }

        [Theory]
        [InlineData(NodeType.MinusNode, TokenType.MINUS, 32.56)]
        [InlineData(NodeType.PlusNode, TokenType.PLUS, 23.01)]
        public void TestUnaryOperators(NodeType expectedType, TokenType inputType, double value)
        {
            var expected = new Node(expectedType, new Node(NodeType.NumberNode, value));
            var input = new List<Token>()
            {
                new Token(inputType),
                new Token(TokenType.NUMBER, value),
                new Token(TokenType.EOF),
            };
            var parser = new Parser(input);
            var tree = parser.Parse();
            Assert.Equal(expected, tree);
        }

        [Fact]
        public void TestAll()
        {
            // This is a quite complicated and it should be the output if someone entererd the mathematical expression (1 - 34.21 * (-21.713)) + (((45.21 / 34.163) ** 56.12) - (5!))
            var expected = new Node(NodeType.AddNode,
                new Node(NodeType.SubtractNode,
                    new Node(NodeType.NumberNode, 1.0),
                    new Node(NodeType.MultiplyNode,
                        new Node(NodeType.NumberNode, 34.21),
                        new Node(NodeType.MinusNode,
                            new Node(NodeType.NumberNode, 21.713)
                        )
                    )
                ),
                new Node(NodeType.SubtractNode,
                    new Node(NodeType.PowerNode,
                        new Node(NodeType.DivideNode,
                            new Node(NodeType.NumberNode, 45.21),
                            new Node(NodeType.NumberNode, 34.163)
                        ),
                        new Node(NodeType.NumberNode, 56.12)
                    ),
                    new Node(NodeType.FactorialNode,
                        new Node(NodeType.NumberNode, 5.0)
                    )
                )
            );
            var input = new List<Token>()
            {
                new Token(TokenType.LPAREN),
                new Token(TokenType.NUMBER, 1.0),
                new Token(TokenType.MINUS),
                new Token(TokenType.NUMBER, 34.21),
                new Token(TokenType.MULTIPLY),
                new Token(TokenType.MINUS),
                new Token(TokenType.NUMBER, 21.713),
                new Token(TokenType.RPAREN),
                new Token(TokenType.PLUS),
                new Token(TokenType.LPAREN),
                new Token(TokenType.LPAREN),
                new Token(TokenType.LPAREN),
                new Token(TokenType.NUMBER, 45.21),
                new Token(TokenType.DIVIDE),
                new Token(TokenType.NUMBER, 34.163),
                new Token(TokenType.RPAREN),
                new Token(TokenType.POWER),
                new Token(TokenType.NUMBER, 56.12),
                new Token(TokenType.MINUS),
                new Token(TokenType.NUMBER, 5.0),
                new Token(TokenType.FACTORIAL),
                new Token(TokenType.RPAREN),
                new Token(TokenType.RPAREN),
                new Token(TokenType.EOF),
            };
            var parser = new Parser(input);
            var tree = parser.Parse();
            Assert.Equal(expected, tree);
        }

    }
}