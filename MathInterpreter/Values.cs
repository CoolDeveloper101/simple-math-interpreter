namespace MathInterpreter
{
    // This file contanins the type of output given by the interpreter.
    public class Number // This class stores a number
    {
        public Number(double value)
        {
            Value = value;
        }

        public double Value { get; }

        public override string ToString() => $"{Value}";

        public override bool Equals(object obj)
        {
            //Check for null and compare run-time types.
            if ((obj == null) || ! this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else {
                Number num = (Number) obj;
                return Value.Equals(num.Value);
            }
        }

        public override int GetHashCode() => base.GetHashCode();

        public static Number operator +(Number number) => number;

        public static Number operator -(Number number) => new Number(-number.Value);

        public static Number operator +(Number number1, Number number2)
            => new Number(number1.Value + number2.Value);
        
        public static Number operator -(Number number1, Number number2)
            => number1 + (-number2);

        public static Number operator *(Number number1, Number number2)
            => new Number(number1.Value * number2.Value);

        public static Number operator /(Number number1, Number number2)
            => new Number(number1.Value / number2.Value);

        public static implicit operator double(Number number) => number.Value;

        public static explicit operator Number(double value) => new Number(value);
    }
}