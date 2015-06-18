using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericList
{
    //define a custom attribute for Version
    [AttributeUsage(AttributeTargets.Struct | AttributeTargets.Class | AttributeTargets.Interface |
        AttributeTargets.Enum | AttributeTargets.Method, AllowMultiple = false)]
    class VersionAttribute : Attribute
    {
        // define properties 
        public byte Major { get; private set; }
        public byte Minor { get; private set; }

        // define a constructor 
        public VersionAttribute(byte major, byte minor)
        {
            this.Major = major;
            this.Minor = minor;
        }
    }
}