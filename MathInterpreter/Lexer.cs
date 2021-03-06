using System;
using System.Collections.Generic;

namespace MathInterpreter
{
    public class Lexer
    {
        /// <summary>
        /// The text provided in the contructor.
        /// </summary>
        public readonly string Text;
        /// <summary>
        /// The current index of Lexer.Text
        /// </summary>
        /// <remarks>
        /// Basically this property tells what character to access by indexing.
        /// </remarks>
        private int _position;
        /// <summary>
        /// The lexer takes a string as input.
        /// </summary>
        /// <param name="text"></param>
        public Lexer(string text)
        {
            Text = text + '\0'; // Assigning the Text property to the text argument provided by the user and also adding the null character to it so that we can keep a check of whether we are at the end of the file.
        }

        /// <summary>
        /// The current character at which the lexer is.
        /// </summary>
        private char Current => Text[_position];

        /// <summary>
        /// This method adds 1 to the Lexer._position variable so that the Lexer.Current method can return the next character from the property Lexer.Text.
        /// </summary>
        private void Advance() => _position++;

        /// <summary>
        /// This method is actually used to get the tokens from the string provided is the constructor.
        /// </summary>
        public List<Token> GetTokens()
        {
            List<Token> tokens = new List<Token>();

            while (Current != '\0') // Checking whether the current character is the null character which means we are at the end o fthe input.
            {
                if (char.IsWhiteSpace(Current)) // Checking if the current token is space, tab or newline
                    Advance(); // If the current token is in whitespace, we advance.

                else if (char.IsDigit(Current) || Current == '.') // We are checking if the current character is a digit.
                {
                    tokens.Add(GetNumber()); // If the current character is a digit, we call a method called GetNumber which converts the string to a NumberToken starting from the current character to the charcter which is not a digit or decimal point.
                }
                else if (Current == '+') // Checking if the current character is a '+' operator. If it is, we advance and add a Token of TokenType.PLUS
                {
                    Advance();
                    tokens.Add(new Token(TokenType.PLUS));
                }
                else if (Current == '-') // Checking if the current character is a '-' operator. If it is, we advance and add a Token of TokenType.MINUS
                {
                    Advance();
                    tokens.Add(new Token(TokenType.MINUS));
                }
                else if (Current == '*') // Checking if the current character is a '*' operator
                {
                    Advance();
                    if (Current== '*') // Checking if the next charcter is also a '*' operator which converts it into a power operator.
                    {
                        Advance();
                        tokens.Add(new Token(TokenType.POWER));
                    }
                    else // If it is and the next token is not a '*' character, we advance and add a Token of TokenType.MULTIPLY
                        tokens.Add(new Token(TokenType.MULTIPLY));
                }
                else if (Current == '/') // Checking if the current character is a '/' operator. If it is, we advance and add a Token of TokenType.DIVIDE
                {
                    Advance();
                    tokens.Add(new Token(TokenType.DIVIDE));
                }
                else if (Current == '!') // Checking if the current character is a '/' operator. If it is, we advance and add a Token of TokenType.DIVIDE
                {
                    Advance();
                    tokens.Add(new Token(TokenType.FACTORIAL));
                }
                else if (Current == '(') // Checking if the current character is a '(' operator. If it is, we advance and add a Token of TokenType.LPAREN
                {
                    Advance();
                    tokens.Add(new Token(TokenType.LPAREN));
                }
                else if (Current == ')') // Checking if the current character is a ')' operator. If it is, we advance and add a Token of TokenType.RPAREN
                {
                    Advance();
                    tokens.Add(new Token(TokenType.RPAREN));
                }
                else // This means that the current character is not a digit or an operator. So this means it is not a valid character and we raise an error. 
                {
                    var errorIndex = 0;
                    var errorPointer = "";
                    while (errorIndex <= _position) {
                        if (errorIndex < _position)
                        {
                            if (Text[errorIndex] == '\t')
                                errorPointer += "\t";
                            else
                                errorPointer += " ";
                            errorIndex += 1;
                        }
                        else if (errorIndex == _position)
                        {
                            errorPointer += "^";
                            errorIndex += 1;
                        }
                    }
                    string errorTraceback = $"Error:\n{Text}\n{errorPointer}\nIllegal character '{Current}'";
                    throw new Exception(errorTraceback);
                }
            }
            tokens.Add(new Token(TokenType.EOF));
            return tokens;
        }

        /// <summary>
        /// It is basically used to convert a part of the text input to a token.
        /// It continues till it encounters a character which is not in Lexer.DIGITS or a '.'
        /// </summary>
        /// <returns>The Lexer.GetNumber method returns a Token of type TokenType.NUMBER.</returns>
        public Token GetNumber()
        {
            int decimal_point_count = 0;
            if (Current == '.')
                decimal_point_count += 1;
            string number_str = Current.ToString(); // We initially store the number as a string.
            Advance();

            while (Current != '\0' && (char.IsDigit(Current) || Current == '.'))
            {
                if (Current == '.')
                {
                    decimal_point_count += 1;
                    if (decimal_point_count > 1)
                        break;
                }
                number_str += Current;
                Advance();
            }

            if (number_str.StartsWith('.'))
                number_str = '0' + number_str;
            if (number_str.EndsWith('.'))
                number_str += '0';

            return new Token(TokenType.NUMBER, double.Parse(number_str)); // Converting the string number to a double.
        }
    }
}