

namespace Herdsman.Models
{
    public struct Score
    {
        public int Value;

        public override string ToString()
        {
            return Value.ToString();
        }

        public static Score operator +(Score a, int b)=> new Score { Value = a.Value + b };
    }
}
