using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer.ValueObjects
{
    public abstract class SimpleStringValueObject<T> : IEquatable<T>
        where T : SimpleStringValueObject<T>
    {
        private readonly string value;

        public SimpleStringValueObject(string value)
        {
            this.value = value;
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as T);
        }

        public override int GetHashCode()
        {
            return this.value.GetHashCode();
        }

        public bool Equals(T other)
        {
            if (Object.ReferenceEquals(other, null)) return false;

            if (Object.ReferenceEquals(this, other)) return true;

            return object.Equals(this.value, other.value);
        }

        public static bool operator ==(SimpleStringValueObject<T> x, SimpleStringValueObject<T> y)
        {
            if (System.Object.ReferenceEquals(x, y))
            {
                return true;
            }

            if (((object)x == null) || ((object)y == null))
            {
                return false;
            }

            return x.Equals(y);
        }

        public static bool operator !=(SimpleStringValueObject<T> x, SimpleStringValueObject<T> y)
        {
            return !(x == y);

        }

        public static implicit operator string(SimpleStringValueObject<T> stringValue)
        {
            if (stringValue == null)
                return null;
            return stringValue.value;
        }

        public override string ToString()
        {
            return this.value.ToString();
        }

    }
}
