namespace MathInterpreter
{
    public class Token
    {
        /// <summary>
        /// The type of the token.
        /// </summary>
        public readonly TokenType Type;
        /// <summary>
        /// The value of the token if its type is TokenType.NUMBER
        /// </summary>
        public readonly double Value;

        /// <summary>
        /// This is for binary operators such as +,-,* and / and also for parenthesis as they do not have a value.
        /// </summary>
        /// <param name="tokenType"></param>
        public Token(TokenType tokenType)
        {
            Type = tokenType;
        }

        /// <summary>
        /// This is for numbers and there value is stored in the Value property.
        /// </summary>
        /// <param name="tokenType"></param>
        /// <param name="value"></param>
        public Token(TokenType tokenType, double value)
        {
            Type = tokenType;
            Value = value;
        }

        /// <summary>
        /// Returns a string representation of the token.
        /// </summary>
        public override string ToString()
        {
            if (Type == TokenType.NUMBER)
                return $"{Type}: {Value}";
            return $"{Type}";
        }

        /// <summary>
        /// Used to check if an object is equal to the current tokens.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>The a boolean after checking whether an object is equal or not.</returns>
        public override bool Equals(object obj)
        {
            //Check for null and compare run-time types.
            if ((obj == null) || ! this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else {
                Token tok = (Token) obj;
                return (Type == tok.Type) && (Value == tok.Value);
            }
        }

        public override int GetHashCode() => base.GetHashCode();

    }

    /// <summary>
    /// This enum specifies the types of values that the lexer can handle.
    /// </summary>
    public enum TokenType
    {
        /// <summary>
        /// The number token type. This is the token type used for numbers.
        /// </summary>
        NUMBER,
        /// <summary>
        /// The '+' operator will have the type TokenType.PLUS
        /// </summary>
        PLUS,
        /// <summary>
        /// The '-' operator will have the type TokenType.MINUS
        /// </summary>
        MINUS,
        /// <summary>
        /// The '*' operator will have the type TokenType.MULTIPLY
        /// </summary>
        MULTIPLY,
        /// <summary>
        /// The '/' operator will have the type TokenType.DIVIDE
        /// </summary>
        DIVIDE,
        /// <summary>
        /// The '**' operator will have the type TokenType.POWER
        /// </summary>
        POWER,
        /// <summary>
        /// The '(' operator will have the type TokenType.LPAREN
        /// </summary>
        LPAREN,
        /// <summary>
        /// The ')' operator will have the type TokenType.RPAREN
        /// </summary>
        RPAREN,
        /// <summary>
        /// This is not actually an operator. This will be used by the parser to ckeck whether it is at the of the list of tokens provided by lexer.
        /// </summary>
        EOF,
    }

}
