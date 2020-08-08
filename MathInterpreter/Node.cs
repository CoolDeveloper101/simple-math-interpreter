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
        public readonly NodeType Type;
        /// <summary>
        /// The value of the node if this.Type is a NumberNode
        /// </summary>
        public readonly double Value;
        /// <summary>
        /// The first node if the this.Type is an operation such as Type.Addnode which has two parts.
        /// </summary>
        public readonly Node NodeA;
        /// <summary>
        /// The second node if the this.Type is an operation such as Type.Addnode which has two parts.
        /// </summary>
        public readonly Node NodeB;

        /// <summary>
        /// This is used for NumberNodes as they only have the Type and the Value
        /// </summary>
        /// <param name="nodeType"></param>
        /// <param name="value"></param>
        public Node(NodeType nodeType, double value)
        {
            this.Type = nodeType;
            Value = value;
        }

        /// <summary>
        /// This constructor is used for operators since they have a Type and the values to the left and right of the Type.
        /// </summary>
        /// <param name="nodeType"></param>
        /// <param name="nodeA"></param>
        /// <param name="nodeB"></param>
        public Node(NodeType nodeType, Node nodeA, Node nodeB)
        {
            this.Type = nodeType;
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
            this.Type = nodeType;
            NodeA = nodeA;
        }

        /// <summary>
        /// This is used for empty nodes when the list of tokens is empty.
        /// </summary>
        /// <param name="nodeType"></param>
        public Node(NodeType nodeType)
        {
            this.Type = nodeType;
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
                if (node.Type == NodeType.NumberNode)
                    return Value == node.Value;
                else if (node.Type == NodeType.PlusNode || node.Type == NodeType.MinusNode || node.Type == NodeType.FactorialNode)
                    return Type.Equals(node.Type) && NodeA.Equals(node.NodeA);
                else if (node.Type == NodeType.EmptyNode)
                    return Type.Equals(node.Type);
                return Type.Equals(node.Type) && NodeA.Equals(node.NodeA) && NodeB.Equals(node.NodeB);
            }
        }

        public override int GetHashCode() => base.GetHashCode();

        /// <summary>
        /// Converts the node to its string representation.
        /// </summary>
        /// <returns>A string representation of the current node.</returns>
        public override string ToString()
        {
            return this.Type switch
            {
                NodeType.NumberNode => $"{Value}",
                NodeType.PlusNode => $"(+{NodeA})",
                NodeType.MinusNode => $"(-{NodeA})",
                NodeType.AddNode => $"({NodeA} + {NodeB})",
                NodeType.SubtractNode => $"({NodeA} - {NodeB})",
                NodeType.MultiplyNode => $"({NodeA} * {NodeB})",
                NodeType.DivideNode => $"({NodeA} / {NodeB})",
                NodeType.PowerNode => $"({NodeA} ** {NodeB})",
                NodeType.FactorialNode => $"({NodeA}!)",
                _ => "()",
            };
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
        /// Used for the operator '**'
        /// </summary>
        PowerNode,
        /// <summary>
        /// Used for the operator '!'
        /// </summary>
        FactorialNode,
        /// <summary>
        /// If the list of the tokens is empty, the parser returns a node of type Type.EmptyNode
        /// </summary>
        EmptyNode,
    }
}