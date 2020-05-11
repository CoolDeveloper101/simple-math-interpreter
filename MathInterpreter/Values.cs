namespace MathInterpreter
{
    // This file contanins the type of output given by the interpreter.
    class Number // This class stores a number
    {
        public Number(double value)
        {
            Value = value;
        }

        public double Value { get; }

        public override string ToString() => $"{Value}";
    }
}