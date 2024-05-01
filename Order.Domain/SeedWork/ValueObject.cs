using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Order.Domain.SeedWork
{
    public abstract class ValueObject //value objelerin id si olmadığı için karşılaştırmaları problem yaratıyor. bu yüzden aşağıdaki methodlar var.
    {
        protected static bool EqualOperator(ValueObject left, ValueObject right) //eşit mi
        {
            if (ReferenceEquals(left, null) ^ ReferenceEquals(right, null)) //XOR left yada right herhangi biri null ise true döner
            {
                return false;
            }
            return ReferenceEquals(left, null) || left.Equals(right);
        }

        protected static bool NotEqualOperator(ValueObject left, ValueObject right) //eşit değil mi
        {
            return !EqualOperator(left, right);
        }

        protected abstract IEnumerable<object> GetEqualityComponents();//objelerin içindeki propertyler aynı mı değil mi?

        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType() != GetType())
            {
                return false;
            }
            var other = (ValueObject)obj;
            return GetEqualityComponents().SequenceEqual(other.GetEqualityComponents());
        }

        public override int GetHashCode() //hash kodunun generate edilip edilmediğinin
        {
            return GetEqualityComponents()
                .Select(x => x != null ? x.GetHashCode() : 0)
                .Aggregate((x,y) => x ^ y);
        }

        public ValueObject GetCopy() //bu objenin bir kopyası oluşturulacaksa MemberwiseClone ile oluştur.
        {
            return MemberwiseClone() as ValueObject;
        }
    }
}
