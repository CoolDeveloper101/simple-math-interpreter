# Simple Math Interpreter

![](https://github.com/CoolDeveloper101/simple-math-interpreter/workflows/Build/badge.svg)

This is the new version of the math interpreter since it got extremely hard to update and add new tests to it. So this is the same interpreter with a better structure so it is easier to maintain.

## Credits
Thanks to [CodePulse](https://www.youtube.com/channel/UCUVahoidFA7F3Asfvamrm7w) for the original project.
He created the original interpreter in python and I basically converted to a c# project.
You can find the original source code [here](https://github.com/davidcallanan/py-simple-math-interpreter).
Thanks to the CodePulse for the project.

## Usage

The interpreter supports the following oprators in the given precedence-<br>
**Brackets** : ( )<br>
**Exponent** : \*\*<br>
**Division** : /<br>
**Multiplication** : \*<br>
**Addition** : +<br>
**Subtraction** : -<br>

It supports positive as well as negative numbers and also supports decimal numbers.

## Use the console.
To use the math interpreter console, follow the given steps -

1. Install the dotnet core sdk
2. Clone the repository
3. Navigate to `<repo_location>/Mathinterpreter.console/` directory in the terminal. (Where <repo_location in> is the directory where you cloned the repo.)
4. Run the command `dotnet run` in the terminal.
5. It prompts you for input. Enter any valid mathematical expression as stated above.
