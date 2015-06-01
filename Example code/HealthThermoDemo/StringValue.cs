using System;

namespace HealthThermo
{
    public class StringValue : IEquatable<StringValue>
    {
        public string Text { get; private set; }
        public object Data { get; private set; }

        public StringValue(string val)
        {
            Text = val;
        }

        public StringValue(string val, object data)
        {
            Text = val;
            Data = data;
        }

        public bool Equals(StringValue other)
        {
            if (this.Text == other.Text)
                return true;
            else
                return false;
        }

        public override bool Equals(Object obj)
        {
            if (obj == null) return base.Equals(obj);

            if (!(obj is StringValue))
                throw new InvalidCastException("The 'obj' argument is not a StringValue object.");
            else
                return Equals(obj as StringValue);
        }

        public static bool operator ==(StringValue val1, StringValue val2)
        {
            return val1.Equals(val2);
        }

        public static bool operator !=(StringValue val1, StringValue val2)
        {
            return (!val1.Equals(val2));
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }

}
