using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageFeatures.CS11
{
    public class NonGenericAttribute : Attribute
    {
        public NonGenericAttribute(Type t) => ParamType = t;

        public Type ParamType { get; }
    }

    [AttributeUsage(AttributeTargets.Method)]
    public class GenericAttribute<T> : Attribute { }


    internal class _GenericAttributes
    {
        [NonGeneric(typeof(string))]
        public string OldWay() => string.Empty;


        [GenericAttribute<string>()]
        public string Method() => string.Empty;
    }
}
