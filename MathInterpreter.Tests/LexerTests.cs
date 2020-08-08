using System;
using Xunit;
using MathInterpreter;
using System.Collections.Generic;

namespace MathInterpreter.Tests
{
    public class LexerTests
    {

        [Fact]
        public void TestEmpty()
        {
            var expexctedTokens = new List<Token>() { new Token(TokenType.EOF)};
            var lexer = new Lexer("");
            var tokens = lexer.GetTokens();
            Assert.Equal(expexctedTokens, tokens);
        }

        [Fact]
        public void TestWhiteSpace()
        {
            var expexctedTokens = new List<Token>() { new Token(TokenType.EOF) };
            var lexer = new Lexer(" \t\n  \t\t\n\n");
            var tokens = lexer.GetTokens();
            Assert.Equal(expexctedTokens, tokens);
        }

        [Fact]
        public void TestNumbers()
        {
            var expexctedTokens = new List<Token>()
            {
                new Token(TokenType.NUMBER, 123.0),
                new Token(TokenType.NUMBER, 123.456),
                new Token(TokenType.NUMBER, 123.0),
                new Token(TokenType.NUMBER, 0.456),
                new Token(TokenType.NUMBER, 0.0),
                new Token(TokenType.EOF),
            };

            var lexer = new Lexer("123 123.456 123. .456 .");
            var tokens = lexer.GetTokens();
            Assert.Equal(expexctedTokens, tokens);
        }

        [Fact]
        public void TestOperators()
        {
            var expexctedTokens = new List<Token>()
            {
                new Token(TokenType.PLUS),
			    new Token(TokenType.MINUS),
			    new Token(TokenType.MULTIPLY),
			    new Token(TokenType.DIVIDE),
                new Token(TokenType.POWER),
                new Token(TokenType.FACTORIAL),
                new Token(TokenType.EOF),
            };
            var lexer = new Lexer("+-*/**!");
            var tokens = lexer.GetTokens();

            Assert.Equal(expexctedTokens, tokens);
        }

        [Fact]
        public void TestParens()
        {
            var expexctedTokens = new List<Token>()
            {
                new Token(TokenType.LPAREN),
			    new Token(TokenType.RPAREN),
                new Token(TokenType.EOF),
            };
            var lexer = new Lexer("()");
            var tokens = lexer.GetTokens();
            Assert.Equal(expexctedTokens, tokens);
        }

        [Fact]
        public void TestAll()
        {
            var expexctedTokens = new List<Token>()
            {
                new Token(TokenType.NUMBER, 27.0),
                new Token(TokenType.PLUS),
                new Token(TokenType.LPAREN),
                new Token(TokenType.NUMBER, 43.0),
                new Token(TokenType.DIVIDE),
                new Token(TokenType.NUMBER, 36.0),
                new Token(TokenType.MINUS),
                new Token(TokenType.NUMBER, 48.0),
			    new Token(TokenType.RPAREN),
			    new Token(TokenType.MULTIPLY),
			    new Token(TokenType.NUMBER, 51.0),
                new Token(TokenType.POWER),
			    new Token(TokenType.NUMBER, 2.0),
                new Token(TokenType.PLUS),
                new Token(TokenType.NUMBER, 5.0),
                new Token(TokenType.FACTORIAL),
                new Token(TokenType.EOF),
            };
            var lexer = new Lexer("27 + (43 / 36 - 48) * 51 ** 2 + 5!");
            var tokens = lexer.GetTokens();

            Assert.Equal(expexctedTokens, tokens);
        }
    }
}
