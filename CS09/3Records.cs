

namespace LanguageFeatures.CS9
{
    // View the sample through sharplab - https://sharplab.io/#v2:EYLgtghglgdgNAExAagD4AEDMACdAmbABwFgAoAbzO2tx3QEYAGbAMSgCcBnAF23IHMAptwDcnYSIC+VGllxNsAGQg8+Q0eNHTS2snPaCAxgHt2CIoK7GY2ABQNmAMw48485gBsV3AJTldpHL4rMbGZJSBdAAs2NyCPLY+4TLUAG4Q7NgAHgC82DCCAO5E5Gxc3DkARABSUGCVcMo8VQDqoR6CAJ6VkiIp2QB0Zap5NRBg8ZV9OmSSQA
    public class Records
    {
        [Fact]
        public void RecordEquality()
        {
            var e1 = new EmployeePoco("Jim", "Wooley", "SA");
            // e1.Title = "Sr Delivery Principal";
            var e2 = e1 with { Title = "Sr Delivery Principal" };
            var e3 = new EmployeePoco("Jim", "Wooley", "SA");

            Console.WriteLine($"e1 equals e2: {e1 == e2}");
            Console.WriteLine($"e1 equals e3: {e1.Equals(e3)}");
            Console.WriteLine($"e1 == e3: {e1 == e3}");

            var (first, last, title) = e1;
            Console.WriteLine(first);
            Console.WriteLine(last);
        }
    }

    public class Employee
    {
        string _fName;
        string _lName;
        public string FirstName
        {
            get
            {
                return _fName;
            }
            set
            {
                _fName = value;
            }
        }
        public string LastName
        {
            get => _lName;
            set => _lName = value;
        }
        public string Title { get; set; }
    }

    public record EmployeePoco(string First, string Last, string Title);
    public record Principal : EmployeePoco
    {
        public int ForceMultiplier { get; }

        public Principal(string first, string last, string title, int forceMultiplier)
            : base(first, last, title)
        {
            ForceMultiplier = forceMultiplier;
        }
    }
    public record SrPrincipal(string First, string Last, string Title, int Multiplier)
        : EmployeePoco(First, Last, Title);
}
