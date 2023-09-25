using LanguageFeatures.CS9;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageFeatures.CS09
{
    internal class NewExpressions
    {
        public void TargetTypeNew()
        {
            Employee e = new Employee();

            var e3 = new Employee();

            Employee e9 = new();

            Employee e9a = new() { FirstName = "Jim" };

            var valid = ValidEmployee(new());
        }

        public bool ValidEmployee(Employee emp) => emp is not null;
    }
}
