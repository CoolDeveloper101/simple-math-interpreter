using System;

namespace MathInterpreter
{
    public class Interpreter
    {
        public Number Visit(Node node)
        {
            switch (node.nodeType)
            {
                case NodeType.NumberNode:
                    return new Number(node.Value);
                
                case NodeType.AddNode:
                    return VisitAddNode(node);
                
                case NodeType.SubtractNode:
                    return VisitSubtractNode(node);

                case NodeType.MultiplyNode:
                    return VisitMultiplyNode(node);

                case NodeType.DivideNode:
                    return VisitDivideNode(node);

                case NodeType.PowerNode:
                    return VisitPowerNode(node);

                case NodeType.PlusNode:
                    return VisitPlusNode(node);

                case NodeType.MinusNode:
                    return VisitMinusNode(node);

                default:
                    throw new Exception("Invalid Node.");
            }
        }

        public Number VisitAddNode(Node node)
        {
            return Visit(node.nodeA) + Visit(node.nodeB);
        }

        public Number VisitSubtractNode(Node node)
        {
            return Visit(node.nodeA) - Visit(node.nodeB);
        }

        public Number VisitMultiplyNode(Node node)
        {
            return Visit(node.nodeA) * Visit(node.nodeB);
        }

        public Number VisitDivideNode(Node node)
        {
            return Visit(node.nodeA) / Visit(node.nodeB);
        }

        public Number VisitPowerNode(Node node)
        {
            // Since we defined an explicit conversion of double to Number, we cast the result to a Number.
            // We could use an implicit cast, but this improves readability as you can see what is going on.
            return (Number) Math.Pow(Visit(node.nodeA) , Visit(node.nodeB));
        }

        public Number VisitPlusNode(Node node)
        {
            return Visit(node.nodeA);
        }

        public Number VisitMinusNode(Node node)
        {
            return -Visit(node.nodeA);
        }

    }
}