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
            //IAddress address = new();
        }

        public bool ValidEmployee(Employee emp) => emp is not null;
    }
}
