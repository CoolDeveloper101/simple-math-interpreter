using System;
using System.Collections.Generic;

namespace MathInterpreter
{
    public class Parser
    {
        public List<Token> Tokens {get; set;} // The list of tokens provided by the lexer.
        public int Index {get; set;} // The index of the current token in the list of tokens.
        public string Expression { get; }

        public Parser(List<Token> tokens, string expression)
        {
            tokens.Add(new Token(TokenType.EOF));
            Tokens = tokens;
            Index = 0;
            Expression = expression;
        }

        public void Advance() // To increment the index of the current token from Parser.Tokens by 1
        {
            Index += 1;
        }

        public Token Current() // To return the token at index Parser.Index from Parser.Tokens
        {
            return Tokens[Index];
        }

        public Node Parse()
        {
            if (Current().tokenType == TokenType.EOF) // Checking if the list of tokens is empty. If it is empty, Parse returns an EmptyNode.
                return new Node(NodeType.EmptyNode);

            Node result = Expr();

            if (Current().tokenType != TokenType.EOF)
            {
                throw new Exception("Invalid Syntax");
            }

            return result;
        }

        public Node Expr()
        {
            Node result = Term();

            while (Current().tokenType != TokenType.EOF && (Current().tokenType == TokenType.PLUS || Current().tokenType == TokenType.MINUS))
            {
                if (Current().tokenType == TokenType.PLUS)
                {
                    Advance();
                    result = new Node(NodeType.AddNode, result, Term());
                }
                else if (Current().tokenType == TokenType.MINUS)
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

            while (Current().tokenType != TokenType.EOF && (Current().tokenType == TokenType.MULTIPLY || Current().tokenType == TokenType.DIVIDE))
            {
                if (Current().tokenType == TokenType.MULTIPLY)
                {
                    Advance();
                    result = new Node(NodeType.MultiplyNode, result, Exponent());
                }
                else if (Current().tokenType == TokenType.DIVIDE)
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

            while (Current().tokenType != TokenType.EOF && (Current().tokenType == TokenType.POWER))
            {
                if (Current().tokenType == TokenType.POWER)
                {
                    Advance();
                    result = new Node(NodeType.PowerNode, result, Factor());
                }
            }

            return result;
        }

        public Node Factor()
        {
            Token current = Current();
            if (current.tokenType == TokenType.LPAREN)
            {
                Advance();
                Node result = Expr();

                if (Current().tokenType != TokenType.RPAREN)
                {
                    throw new Exception($"Invalid expression '{Expression}'");
                }

                Advance();
                return result;

            }
            else if (current.tokenType == TokenType.NUMBER)
            {
                Advance();
                return new Node(NodeType.NumberNode, current.Value);
            }
            else if (current.tokenType == TokenType.PLUS)
            {
                Advance();
                return new Node(NodeType.PlusNode, Factor());
            }
            else if (current.tokenType == TokenType.MINUS)
            {
                Advance();
                return new Node(NodeType.MinusNode, Factor());
            }

            throw new Exception($"Invalid expression '{Expression}'");
        }
    }
}
