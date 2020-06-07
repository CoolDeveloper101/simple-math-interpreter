# Simple Math Interpreter

[![Build Status](https://github.com/CoolDeveloper101/simple-math-interpreter/workflows/Build/badge.svg)](https://github.com/CoolDeveloper101/simple-math-interpreter/actions)

This is the new version of the math interpreter since it got extremely hard to update and add new tests to it. So this is the same interpreter with a better structure so it is easier to maintain. You can find the original project [here](https://gitlab.com/CoolDeveloper101/math-interpreter).

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

**Note**: Some of you might be wondering why there is not underroot operator.
After much consideration, I decided that it was really unnecessary.
Well you can just use this property -
number<sup>1/x</sup> is equal to x<sup>th</sup> root of the number.

For example:

4<sup>1/2</sup> is equal to square root of 4 which is 2<br>
27<sup>1/3</sup> is equal to cube root of 27 which is 3<br>
and so on...

So, to perform the under root operation in the calualator for any number, lets say 144-
`>>> 144 ** (1/2)`
The parentheses are important as the power operator is upper in the operator hierarchy. If the don't include them the result would become-
`>>> (144 ** 1) / 2`

## Use the console.
To use the math interpreter console, follow the given steps -

1. Install the dotnet core sdk
2. Clone the repository
3. Navigate to `<repo_location>/Mathinterpreter.console/` directory in the terminal. (Where <repo_location> is the directory where you cloned the repo.)
4. Run the command `dotnet run` in the terminal.
5. It prompts you for input. Enter any valid mathematical expression as stated above.

## Integrating with other applications.
Since the core application is a dotnet standard class library, it is easily portable. Just add a refernce to the MathInterpreter.MathInterpreter.csproj file in your project.

## Contributions

[Conbtributing](https://github.com/CoolDeveloper101/simple-math-interpreter/blob/master/CONTRIBUTING.md)