// CS 10 Global using
global using System.Drawing;

using System;
using System.Collections.Generic;
using System.Text;

// CS 6 using static
using static System.Drawing.Color;

// CS 12 alias any type
using Name = (string first, string last);
using Grade = decimal;
using g2 = System.Decimal;
using System.Security.Cryptography.X509Certificates;

// CS10 File-Scoped Namespace
namespace LanguageFeatures.CrossVersionEvolutions
{
    public class Cs1Class
    {
        private string _a = "Test";
        public string A
        {
            get
            {
                return _a;
            }
            set
            {
                _a = value;
            }
        }
    }

    public class Cs3Class
    {
        public Cs3Class()
        {
            AutoProp = "Test"; // Auto-property with an In constructor
            var anon = new { AutoProp = "Test" }; // Anonymous type with an auto-property
        }
        public string AutoProp { get; set; }
    }

    public class Cs6Class
    {
        public string AutoProp { get; } = "Test"; // Readonly Auto-property with an initializer
        public string ExpressionBodyProp => "Test"; // Expression-bodied property
    }
    public class Cs7Class
    {
        public (string Name, int Age) Tuple { get; set; } = ("Test", 42); // Auto-property with a tuple type and an initializer
    }

    public class Cs9Class
    {
        public string AutoProp { get; init; } = "Test"; // Init-only auto-property with an initializer
    }

    public record Cs9Record(string AutoProp = "Test"); // Records

    public class Cs12Class(ILogger logger, string autoProp = "test") // Primary constructor with a default value
    {
        public string AutoProp { get; set => logger.Log(value); } = autoProp;
    }

    public class Cs11Class
    {
        public required string AutoProp { get; init; } // Required keyword
        public void UseIt()
        {
            var x = new Cs11Class { AutoProp = "Test" }; // Required property must be set during object initialization
        }
    }

    public class Cs14Class
    {
        public string? AutoProp { get; set => field = value ?? ""; }
    }

    #region helpers
    public interface ILogger
    {
        void Log(string message);
    }
    #endregion
}