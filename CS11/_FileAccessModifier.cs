using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace LanguageFeatures.CS11
{
    public partial class FileAccessModifier
    {
        public void Test()
        {
            this.Test2();
            //new Restricted().CantTouchThis();
        }
    }
}
