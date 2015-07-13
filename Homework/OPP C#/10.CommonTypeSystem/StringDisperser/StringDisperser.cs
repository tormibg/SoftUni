using System;
using System.Collections;
using System.Runtime.CompilerServices;
using System.Text;

namespace StringDisperser
{
    public class StringDisperser : ICloneable, IComparable<StringDisperser>, IEnumerable
    {
        public StringDisperser(params string[] strings)
        {
            this.StringsArr = strings;
            this.Strings = string.Join("", strings);
        }

        public string[] StringsArr { get; set; }
        public string Strings { get; set; }

        public override bool Equals(object obj)
        {
            StringDisperser newStringDisperser = obj as StringDisperser;

            return this.Strings == newStringDisperser.Strings;
        }

        public override int GetHashCode()
        {
            return this.Strings.GetHashCode();
        }

        public object Clone()
        {
            return new StringDisperser(new string[] {this.Strings});
        }

        public int CompareTo(StringDisperser other)
        {
            if (other == null)
            {
                throw new ArgumentException("StringDisperser is null");
            }
            return string.Compare(this.Strings, other.Strings, StringComparison.Ordinal);
        }

        public override string ToString()
        {
            return this.Strings;
        }

        public static bool operator ==(StringDisperser s1, StringDisperser s2)
        {
            return s1.Equals(s2);
        }

        public static bool operator !=(StringDisperser s1, StringDisperser s2)
        {
            return !s1.Equals(s2);
        }

        public IEnumerator GetEnumerator()
        {
          // I  return this.Strings.GetEnumerator();

          // II
            foreach (char s in this.Strings)
            {
                yield return s;
            }
        }
    }
}