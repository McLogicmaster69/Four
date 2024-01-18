using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Four.Elements
{
    public class Number : EquationElement
    {
        public float Value;

        public Number(float value, int fours) : base(ElementTypes.Number, fours)
        {
            Value = value;
            Fours = fours;
        }

        public override float Equate() => Value;

        public override string Format() => $"({Value})";
    }
}
