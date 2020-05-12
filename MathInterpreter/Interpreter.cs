using System;

namespace MathInterpreter
{
    public class Interpreter
    {
        public Number Visit(Node node)
        {
            if (node.nodeType == NodeType.NumberNode)
                return new Number(node.Value);
            else if (node.nodeType == NodeType.AddNode)
                return VisitAddNode(node);
            else if (node.nodeType == NodeType.SubtractNode)
                return VisitSubtractNode(node);
            else if (node.nodeType == NodeType.MultiplyNode)
                return VisitMultiplyNode(node);
            else if (node.nodeType == NodeType.DivideNode)
                return VisitDivideNode(node);
            else if (node.nodeType == NodeType.PowerNode)
                return VisitPowerNode(node);
            else if (node.nodeType == NodeType.PlusNode)
                return VisitPlusNode(node);
            else if (node.nodeType == NodeType.MinusNode)
                return VisitMinusNode(node);

            throw new Exception("Invalid Node.");
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
            return new Number(Math.Pow(Visit(node.nodeA).Value , Visit(node.nodeB).Value));
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