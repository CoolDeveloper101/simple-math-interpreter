using System;

namespace MathInterpreter
{
    /// <summary>
    /// The output given by the parser.
    /// </summary>
    public class Node
    {
        /// <summary>
        /// The type of the node
        /// </summary>
        public NodeType nodeType {get; }
        /// <summary>
        /// The value of the node if this.nodeType is a NumberNode
        /// </summary>
        public double Value {get; }
        /// <summary>
        /// The first node if the this.nodeType is an operation such as NodeType.Addnode which has two parts.
        /// </summary>
        public Node nodeA {get; }
        /// <summary>
        /// The second node if the this.nodeType is an operation such as NodeType.Addnode which has two parts.
        /// </summary>
        public Node nodeB {get; }

        /// <summary>
        /// This is used for NumberNodes as they only have the nodeType and the Value
        /// </summary>
        /// <param name="_nodeType"></param>
        /// <param name="value"></param>
        public Node(NodeType _nodeType, double value)
        {
            nodeType = _nodeType;
            Value = value;
        }

        /// <summary>
        /// This constructor is used for operators since they have a nodeType and the values to the left and right of the nodeType.
        /// </summary>
        /// <param name="_nodeType"></param>
        /// <param name="_nodeA"></param>
        /// <param name="_nodeB"></param>
        public Node(NodeType _nodeType, Node _nodeA, Node _nodeB)
        {
            nodeType = _nodeType;
            nodeA = _nodeA;
            nodeB = _nodeB;
        }

        /// <summary>
        /// This is used for unary operators that have only one input to their right side.
        /// </summary>
        /// <param name="_nodeType"></param>
        /// <param name="_nodeA"></param>
        public Node(NodeType _nodeType, Node _nodeA)
        {
            nodeType = _nodeType;
            nodeA = _nodeA;
        }

        /// <summary>
        /// This is used for empty nodes when the list of tokens is empty.
        /// </summary>
        /// <param name="_nodeType"></param>
        public Node(NodeType _nodeType)
        {
            nodeType = _nodeType;
        }

        /// <summary>
        /// It is used to check if the current object is equal to another object.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>It returns true if the objects are equal else false.</returns>
        public override bool Equals(object obj)
        {
            //Check for null and compare run-time types.
            if ((obj == null) || ! this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else {
                Node node = (Node) obj;
                if (node.nodeType == NodeType.NumberNode)
                    return Value == node.Value;
                else if (node.nodeType == NodeType.PlusNode || node.nodeType == NodeType.MinusNode)
                    return nodeType.Equals(node.nodeType) && nodeA.Equals(node.nodeA);
                else if (node.nodeType == NodeType.EmptyNode)
                    return nodeType.Equals(node.nodeType);
                return nodeType.Equals(node.nodeType) && nodeA.Equals(node.nodeA) && nodeB.Equals(node.nodeB);
            }
        }

        public override int GetHashCode() => base.GetHashCode();

        /// <summary>
        /// Converts the node to its string representation.
        /// </summary>
        /// <returns>A string representation of the current node.</returns>
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

    /// <summary>
    /// These are the types of nodes that can be parsed by the parser.
    /// </summary>
    public enum NodeType
    {
        /// <summary>
        /// Used for numbers.
        /// </summary>
        NumberNode,
        /// <summary>
        /// Used for the unary operator '+'
        /// </summary>
        PlusNode,
        /// <summary>
        /// Used for the unary operator '-'
        /// </summary>
        MinusNode,
        /// <summary>
        /// Used for the binary operator '+'
        /// </summary>
        AddNode,
        /// <summary>
        /// Used for the binary operator '-'
        /// </summary>
        SubtractNode,
        /// <summary>
        /// Used for the binary operator '*'
        /// </summary>
        MultiplyNode,
        /// <summary>
        /// Used for the binary operator '/'
        /// </summary>
        DivideNode,
        /// <summary>
        /// Used for the binary operator '*'
        /// </summary>
        PowerNode,
        /// <summary>
        /// If the list of the tokens is empty, the parser returns a node of type NodeType.EmptyNode
        /// </summary>
        EmptyNode,
    }
}