using System;
using MathInterpreter;

namespace MathInterpreter.console
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Simple Math Interpreter");
            Console.ResetColor();
            while (true)
            {
                try
                {
                    Console.Write(">>> ");
                    string expression = Console.ReadLine();
                    var lexer = new Lexer(expression);
                    var tokens = lexer.GetTokens();
                    var parser = new Parser(tokens);
                    var tree = parser.Parse();
                    if (tree.nodeType != NodeType.EmptyNode)
                    {
                        var interpreter = new Interpreter();
                        var result = interpreter.Visit(tree);
                        Console.WriteLine(result);
                    }
                }
                catch (Exception e)
                {
                    Console.Error.WriteLine(e);
                }
            }
        }
    }
}
