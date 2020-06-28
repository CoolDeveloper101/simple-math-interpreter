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
        public readonly NodeType NodeType;
        /// <summary>
        /// The value of the node if this.NodeType is a NumberNode
        /// </summary>
        public readonly double Value;
        /// <summary>
        /// The first node if the this.NodeType is an operation such as NodeType.Addnode which has two parts.
        /// </summary>
        public readonly Node NodeA;
        /// <summary>
        /// The second node if the this.NodeType is an operation such as NodeType.Addnode which has two parts.
        /// </summary>
        public readonly Node NodeB;

        /// <summary>
        /// This is used for NumberNodes as they only have the NodeType and the Value
        /// </summary>
        /// <param name="nodeType"></param>
        /// <param name="value"></param>
        public Node(NodeType nodeType, double value)
        {
            this.NodeType = nodeType;
            Value = value;
        }

        /// <summary>
        /// This constructor is used for operators since they have a NodeType and the values to the left and right of the NodeType.
        /// </summary>
        /// <param name="nodeType"></param>
        /// <param name="nodeA"></param>
        /// <param name="nodeB"></param>
        public Node(NodeType nodeType, Node nodeA, Node nodeB)
        {
            this.NodeType = nodeType;
            NodeA = nodeA;
            NodeB = nodeB;
        }

        /// <summary>
        /// This is used for unary operators that have only one input to their right side.
        /// </summary>
        /// <param name="nodeType"></param>
        /// <param name="nodeA"></param>
        public Node(NodeType nodeType, Node nodeA)
        {
            this.NodeType = nodeType;
            NodeA = nodeA;
        }

        /// <summary>
        /// This is used for empty nodes when the list of tokens is empty.
        /// </summary>
        /// <param name="nodeType"></param>
        public Node(NodeType nodeType)
        {
            this.NodeType = nodeType;
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
                if (node.NodeType == NodeType.NumberNode)
                    return Value == node.Value;
                else if (node.NodeType == NodeType.PlusNode || node.NodeType == NodeType.MinusNode)
                    return NodeType.Equals(node.NodeType) && NodeA.Equals(node.NodeA);
                else if (node.NodeType == NodeType.EmptyNode)
                    return NodeType.Equals(node.NodeType);
                return NodeType.Equals(node.NodeType) && NodeA.Equals(node.NodeA) && NodeB.Equals(node.NodeB);
            }
        }

        public override int GetHashCode() => base.GetHashCode();

        /// <summary>
        /// Converts the node to its string representation.
        /// </summary>
        /// <returns>A string representation of the current node.</returns>
        public override string ToString()
        {
            switch (this.NodeType)
            {
                case NodeType.NumberNode: return $"{Value}";
                case NodeType.PlusNode: return $"(+{NodeA})";
                case NodeType.MinusNode: return $"(-{NodeA})";
                case NodeType.AddNode: return $"({NodeA} + {NodeB})";
                case NodeType.SubtractNode: return $"({NodeA} - {NodeB})";
                case NodeType.MultiplyNode: return $"({NodeA} * {NodeB})";
                case NodeType.DivideNode: return $"({NodeA} / {NodeB})";
                case NodeType.PowerNode: return $"({NodeA} ** {NodeB})";
                default: return "()";
            }
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