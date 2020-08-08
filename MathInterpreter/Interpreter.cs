using System;

namespace MathInterpreter
{
    public class Interpreter
    {
        public Number Visit(Node node)
        {
            return node.Type switch
            {
                NodeType.NumberNode => new Number(node.Value),
                NodeType.AddNode => VisitAddNode(node),
                NodeType.SubtractNode => VisitSubtractNode(node),
                NodeType.MultiplyNode => VisitMultiplyNode(node),
                NodeType.DivideNode => VisitDivideNode(node),
                NodeType.PowerNode => VisitPowerNode(node),
                NodeType.FactorialNode => VisitFactorialNode(node),
                NodeType.PlusNode => VisitPlusNode(node),
                NodeType.MinusNode => VisitMinusNode(node),
                _ => throw new Exception("Invalid Node."),
            };
        }

        public Number VisitAddNode(Node node)
        {
            return Visit(node.NodeA) + Visit(node.NodeB);
        }

        public Number VisitSubtractNode(Node node)
        {
            return Visit(node.NodeA) - Visit(node.NodeB);
        }

        public Number VisitMultiplyNode(Node node)
        {
            return Visit(node.NodeA) * Visit(node.NodeB);
        }

        public Number VisitDivideNode(Node node)
        {
            return Visit(node.NodeA) / Visit(node.NodeB);
        }

        public Number VisitPowerNode(Node node)
        {
            // Since we defined an explicit conversion of double to Number, we cast the result to a Number.
            // We could use an implicit cast, but this improves readability as you can see what is going on.
            return (Number) Math.Pow(Visit(node.NodeA) , Visit(node.NodeB));
        }

        public Number VisitFactorialNode(Node node)
        {
            var nodeA = Visit(node.NodeA).Value;
            // The factorial operator, unlike the other operators, can only handle whole numbers.
            // That is why we check if it meets the nodeA meets criteria and throws an exception if it doesn't.
            if (nodeA != (int)nodeA || nodeA < 0.0)
            {
                throw new Exception("Invalid value for the factorial operator.");
            }
            // Since we defined an explicit conversion of double to Number, we cast the result to a Number.
            // We could use an implicit cast, but this improves readability as you can see what is going on.
            return (Number)Factorial(nodeA);
        }

        public Number VisitPlusNode(Node node)
        {
            return Visit(node.NodeA);
        }

        public Number VisitMinusNode(Node node)
        {
            return -Visit(node.NodeA);
        }

        private double Factorial(double n)
        {
            if (n == 0)
                return 1;
            return n * Factorial(n - 1);
        }
    }
}