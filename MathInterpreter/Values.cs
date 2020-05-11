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

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}