using System;

namespace MathInterpreter
{
    public class Token
    {
        public TokenType tokenType { get; }
        public double Value { get; }

        public Token(TokenType _tokenType) // This is for binary operators such as +,-,* and / and also for parenthesis as they do not have a value.
        {
            tokenType = _tokenType;
        }

        public Token(TokenType _tokenType, double value) // This is for numbers and there value is stored in the Value property.
        {
            tokenType = _tokenType;
            Value = value;
        }

        public override string ToString()
        {
            if (tokenType == TokenType.NUMBER)
                return $"{tokenType}: {Value}";
            return $"{tokenType}";
        }

        public override bool Equals(object obj)
        {
            //Check for null and compare run-time types.
            if ((obj == null) || ! this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else {
                Token tok = (Token) obj;
                return (tokenType == tok.tokenType) && (Value == tok.Value);
            }
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

    }

    public enum TokenType
    {
        NUMBER, // The number token type
        PLUS, // The '+' operator will have the type TokenType.PLUS
        MINUS, // The '-' operator will have the type TokenType.MINUS
        MULTIPLY, // The '*' operator will have the type TokenType.MULTIPLY
        DIVIDE, // The '/' operator will have the type TokenType.DIVIDE
        POWER, // The '**' operator will have the type TokenType.POWER
        LPAREN, // The '(' operator will have the type TokenType.LPAREN
        RPAREN, // The ')' operator will have the type TokenType.RPAREN
        EOF,
    }

}
