using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TotalCopy.library
{
    class array
    {
        public static void InsertIntoArray(Array target,
      object value, int index)
        {
            if (index < target.GetLowerBound(0) ||
                index > target.GetUpperBound(0))
            {
                throw (new ArgumentOutOfRangeException("index", index,
                  "Array index out of bounds."));
            }
            else
            {
                Array.Copy(target, index, target, index + 1,
                           target.Length - index - 1);
            }

            target.SetValue(value, index);
        }

        public static void RemoveFromArray(Array target, int index)
        {
            if (index < target.GetLowerBound(0) ||
                index > target.GetUpperBound(0))
            {
                throw (new ArgumentOutOfRangeException("index", index,
                  "Array index out of bounds."));
            }
            else if (index < target.GetUpperBound(0))
            {
                Array.Copy(target, index + 1, target, index,
                           target.Length - index - 1);
            }

            target.SetValue(null, target.GetUpperBound(0));
        }
    }
}
