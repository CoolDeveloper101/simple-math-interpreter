using System;
using MathInterpreter;
using Xunit;

namespace MathInterpreter.Tests
{
    public class InterpreterTests
    {
        [Theory]
        [InlineData(12.34)]
        [InlineData(51.96)]
        [InlineData(451346.06084)]
        public void TestNumbers(double number)
        {
            var expected = new Number(number);
            var input = new Node(NodeType.NumberNode, number);
            var interpreter = new Interpreter();
            var result = interpreter.Visit(input);
            Assert.Equal(expected, result);
        }

        [Fact]
        public void TestSingleOperatorsInterpretation()
        {
            var interpreter = new Interpreter();

            var input = new Node(NodeType.AddNode, new Node(NodeType.NumberNode, 45.23), new Node(NodeType.NumberNode, 5.2344));
            var result = interpreter.Visit(input);
            Assert.Equal(new Number(50.4644), result);

            input = new Node(NodeType.SubtractNode, new Node(NodeType.NumberNode, 71.0), new Node(NodeType.NumberNode, 53345.53));
            result = interpreter.Visit(input);
            Assert.Equal(new Number(-53274.53), result);

            input = new Node(NodeType.MultiplyNode, new Node(NodeType.NumberNode, 12.0), new Node(NodeType.NumberNode, 9.334));
            result = interpreter.Visit(input);
            Assert.Equal(new Number(112.008), result);

            input = new Node(NodeType.DivideNode, new Node(NodeType.NumberNode, 3.0), new Node(NodeType.NumberNode, 2));
            result = interpreter.Visit(input);
            Assert.Equal(new Number(1.5) ,result);

            input = new Node(NodeType.PowerNode, new Node(NodeType.NumberNode, 52.0), new Node(NodeType.NumberNode, 4.63));
            result = interpreter.Visit(input);
            Assert.Equal(new Number(88124259.571159), result);

            input = new Node(NodeType.FactorialNode, new Node(NodeType.NumberNode, 6.0));
            result = interpreter.Visit(input);
            Assert.Equal(new Number(720.0), result);
        }

        [Fact]
        public void TestAll()
        {
            // This is the same node as the parser test but it is the input because I'm lazy.
            var input = new Node(NodeType.AddNode,
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

            var interpreter = new Interpreter();
            var result = interpreter.Visit(input);
            Assert.Equal(new Number(6739659.562728541), result);
        }
    }
}