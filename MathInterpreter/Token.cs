using System;

namespace MathInterpreter
{
    public class Token
    {
        
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
