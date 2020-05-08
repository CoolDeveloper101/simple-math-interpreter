using System;

namespace MathInterpreter
{
    public class Node
    {
        public NodeType nodeType {get; } // The type of the node
        public double Value {get; } // The value of the node if the type is a NumberNode
        public Node nodeA {get ;}
        public Node nodeB {get; }

        public Node(NodeType _nodeType, double value)
        {
            nodeType = _nodeType;
            Value = value;
        }

        public Node(NodeType _nodeType, Node _nodeA, Node _nodeB)
        {
            nodeType = _nodeType;
            nodeA = _nodeA;
            nodeB = _nodeB;
        }

        public Node(NodeType _nodeType)
        {
            nodeType = _nodeType;
        }

        public Node(NodeType _nodeType, Node _nodeA)
        {
            nodeType = _nodeType;
            nodeA = _nodeA;
        }

        public override string ToString()
        {
            if (nodeType == NodeType.NumberNode)
                return $"{Value}";
            else if (nodeType == NodeType.AddNode)
                return $"({nodeA} + {nodeB})";
            else if (nodeType == NodeType.SubtractNode)
                return $"({nodeA} - {nodeB})";
            else if (nodeType == NodeType.MultiplyNode)
                return $"({nodeA} * {nodeB})";
            else if (nodeType == NodeType.DivideNode)
                return $"({nodeA} / {nodeB})";
            else if (nodeType == NodeType.PowerNode)
                return $"({nodeA} ** {nodeB})";
            else if (nodeType == NodeType.PlusNode)
                return $"(+{nodeA})";
            else if (nodeType == NodeType.MinusNode)
                return $"(-{nodeA})";
            return $"()";
        }
    }

    public enum NodeType
    {
        PlusNode,
        MinusNode,
        EmptyNode,
        NumberNode,
        AddNode,
        SubtractNode,
        MultiplyNode,
        DivideNode,
        PowerNode,
    }
}