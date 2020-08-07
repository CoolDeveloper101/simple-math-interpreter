using System;
using System.Collections.Generic;

namespace MathInterpreter
{
    public class Parser
    {
        /// <summary>
        /// The list of tokens provided by the lexer.
        /// </summary>
        public readonly List<Token> Tokens;
        /// <summary>
        /// The index of the current token in the list of tokens.
        /// </summary>
        public int Index {get; set;}
        private readonly string Expression;

        public Parser(List<Token> tokens, string expression="")
        {
            Tokens = tokens;
            Index = 0;
            Expression = expression;
        }

        /// <summary>
        /// The current Token at which the parser is.
        /// </summary>
        public Token Current => Tokens[Index];

        /// <summary>
        /// To increment the index of the current token from Parser.Tokens by 1
        /// </summary>
        public void Advance() => Index += 1;

        /// <summary>
        /// This is the actual method which is used to convert a method to a list of tokens to a Node.
        /// </summary>
        /// <returns></returns>
        public Node Parse()
        {
            if (!Tokens.Contains(new Token(TokenType.EOF)))
                throw new Exception("The list is not valid. It does not contain an EOF token.");

            else if (Current.Type == TokenType.EOF) // Checking if the list of tokens is empty. If it is empty, Parse returns an EmptyNode.
                return new Node(NodeType.EmptyNode);

            Node result = Expr();

            if (Current.Type != TokenType.EOF)
            {
                if (Expression != "")
                    throw new Exception($"Invalid expression '{Expression}'");
                throw new Exception($"The expression you have entered is not valid.");
            }

            return result;
        }

        public Node Expr()
        {
            Node result = Term();

            while (Current.Type != TokenType.EOF && (Current.Type == TokenType.PLUS || Current.Type == TokenType.MINUS))
            {
                if (Current.Type == TokenType.PLUS)
                {
                    Advance();
                    result = new Node(NodeType.AddNode, result, Term());
                }
                else if (Current.Type == TokenType.MINUS)
                {
                    Advance();
                    result = new Node(NodeType.SubtractNode, result, Term());
                }
            }

            return result;
        }

        public Node Term()
        {
            Node result = Exponent();

            while (Current.Type != TokenType.EOF && (Current.Type == TokenType.MULTIPLY || Current.Type == TokenType.DIVIDE))
            {
                if (Current.Type == TokenType.MULTIPLY)
                {
                    Advance();
                    result = new Node(NodeType.MultiplyNode, result, Exponent());
                }
                else if (Current.Type == TokenType.DIVIDE)
                {
                    Advance();
                    result = new Node(NodeType.DivideNode, result, Exponent());
                }
            }
            return result;
        }

        public Node Exponent()
        {
            Node result = Factor();

            while (Current.Type != TokenType.EOF && (Current.Type == TokenType.POWER || Current.Type == TokenType.FACTORIAL))
            {
                if (Current.Type == TokenType.POWER)
                {
                    Advance();
                    result = new Node(NodeType.PowerNode, result, Factor());
                }
                else if (Current.Type == TokenType.FACTORIAL)
                {
                    Advance();
                    result = new Node(NodeType.FactorialNode, result);
                }
            }

            return result;
        }

        public Node Factor()
        {
            Token current = Current;
            if (current.Type == TokenType.LPAREN)
            {
                Advance();
                Node result = Expr();

                if (Current.Type != TokenType.RPAREN)
                {
                    if (Expression != "")
                        throw new Exception($"Invalid expression '{Expression}'");
                    throw new Exception($"The expression you have entered is not valid.");
                }

                Advance();
                return result;

            }
            else if (current.Type == TokenType.NUMBER)
            {
                Advance();
                return new Node(NodeType.NumberNode, current.Value);
            }
            else if (current.Type == TokenType.PLUS)
            {
                Advance();
                return new Node(NodeType.PlusNode, Factor());
            }
            else if (current.Type == TokenType.MINUS)
            {
                Advance();
                return new Node(NodeType.MinusNode, Factor());
            }
            if (Expression != "")
                throw new Exception($"Invalid expression '{Expression}'");
            throw new Exception($"The expression you have entered is not valid.");
        }
    }
}
