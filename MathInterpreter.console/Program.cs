using System;
using MathInterpreter;

namespace MathInterpreter.console
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0 || (args.Length == 1 && args[0] == "repl"))
                Repl();
            else if (args.Length > 0 && args[0] == "repl")
                Console.Error.WriteLine($"Unrecognzable option '{string.Join(' ', args[1..])}' after repl");
            else if (args.Length >= 1 && args[0] == "-e")
            {
                if (args.Length == 2)
                {
                    try
                    {
                        string expression = args[1];
                        var lexer = new Lexer(expression);
                        var tokens = lexer.GetTokens();
                        var parser = new Parser(tokens, expression);
                        var tree = parser.Parse();
                        if (tree.Type != NodeType.EmptyNode)
                        {
                            var interpreter = new Interpreter();
                            var result = interpreter.Visit(tree);
                            Console.WriteLine(result);
                        }
                    }
                    catch (Exception e)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Error.WriteLine(e.Message);
                        Console.ResetColor();
                    }
                }
                else
                    Console.Error.WriteLine("Fatal: Option '-e' takes one argument");
            }
            else
                Console.Error.WriteLine("Fatal: Command not recognized.");
        }

        static void Repl()
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
                    var parser = new Parser(tokens, expression);
                    var tree = parser.Parse();
                    if (tree.Type != NodeType.EmptyNode)
                    {
                        var interpreter = new Interpreter();
                        var result = interpreter.Visit(tree);
                        Console.WriteLine(result);
                    }
                }
                catch (Exception e)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Error.WriteLine(e.Message);
                    Console.ResetColor();
                }
            }
        }
    }
}
