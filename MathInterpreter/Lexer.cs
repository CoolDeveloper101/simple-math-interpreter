using System;
using System.Collections.Generic;

namespace MathInterpreter
{
    class Lexer
    {
        public string Text { get; set; } // The text the user has provided.
        public int Index {get; set;} // The index of the string.
        public const string WHITESPACE = " \t\n"; // Defining what kind of characters to skip
        public const string DIGITS = "0123456789";

        public Lexer(string text)
        {
            Text = text + "\0"; // Assigning the Text property to the text argument provided by the user and also adding the null character to it so that we can keep a check of whether we are at the end of the file.
        }

        public void Advance() // This method adds 1 to the index variable so that the Current method can return the next character from the property Text.
        {
            Index += 1;
        }

        public string Current() // This returns the character which is at the Index variable.
        {
            return $"{Text[Index]}";
        }

        public List<Token> GetTokens()
        {
            List<Token> tokens = new List<Token>();

            while (Current() != "\0") // Checking whether the current character is the null character which means we are at the end o fthe input.
            {
                if (WHITESPACE.Contains(Current())) // Checking if the current token is space, tab or newline
                    Advance(); // If the current token is in whitespace, we advance.

                else if (DIGITS.Contains(Current()) || Current() == ".") // We are checking if the current character is a digit.
                {
                    tokens.Add(GetNumber()); // If the current character is a digit, we call a method called GetNumber which converts the string to a NumberToken starting from the current character to the charcter which is not a digit or decimal point.
                }
                else if (Current() == "+") // Checking if the current character is a '+' operator. If it is, we advance and add a Token of TokenType.PLUS
                {
                    Advance();
                    tokens.Add(new Token(TokenType.PLUS));
                }
                else if (Current() == "-") // Checking if the current character is a '-' operator. If it is, we advance and add a Token of TokenType.MINUS
                {
                    Advance();
                    tokens.Add(new Token(TokenType.MINUS));
                }
                else if (Current() == "*") // Checking if the current character is a '*' operator
                {
                    Advance();
                    if (Current() == "*") // Checking if the next charcter is also a '*' operator which converts it into a power operator.
                    {
                        Advance();
                        tokens.Add(new Token(TokenType.POWER));
                    }
                    else // If it is and the next token is not a '*' character, we advance and add a Token of TokenType.MULTIPLY
                        tokens.Add(new Token(TokenType.MULTIPLY));
                }
                else if (Current() == "/") // Checking if the current character is a '/' operator. If it is, we advance and add a Token of TokenType.DIVIDE
                {
                    Advance();
                    tokens.Add(new Token(TokenType.DIVIDE));
                }
                else if (Current() == "(") // Checking if the current character is a '(' operator. If it is, we advance and add a Token of TokenType.LPAREN
                {
                    Advance();
                    tokens.Add(new Token(TokenType.LPAREN));
                }
                else if (Current() == ")") // Checking if the current character is a ')' operator. If it is, we advance and add a Token of TokenType.RPAREN
                {
                    Advance();
                    tokens.Add(new Token(TokenType.RPAREN));
                }
                else // This means that the current character is not a digit or an operator. So we raise an error that it is not a valid character. 
                {
                    throw new Exception($"Illegal character {Current()}");
                }
            }
            return tokens;
        }

        public Token GetNumber() // The GetNumber method returns a Token of type TokenType.NUMBER . It converts the string to number token.
        {
            int decimal_point_count = 0;
            if (Current() == ".")
                decimal_point_count += 1;
            string number_str = Current(); // We initially store the number as a string.
            Advance();

            while (Current() != "\0" && (DIGITS.Contains(Current()) || Current() == "."))
            {
                if (Current() == ".")
                {
                    decimal_point_count += 1;
                    if (decimal_point_count > 1)
                        break;
                }
                number_str += Current();
                Advance();
            }

            if (number_str.StartsWith("."))
                number_str = "0" + number_str;
            if (number_str.EndsWith("."))
                number_str += "0";

            return new Token(TokenType.NUMBER, Convert.ToDouble(number_str)); // Converting the string number to a double.
        }
    }
}