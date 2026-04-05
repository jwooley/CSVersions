namespace LanguageFeatures.CS14;

internal class NullConditionalAssignment
{
    internal sealed class Customer
    {
        public string? Name { get; set; }
    }

    public void Demo(Customer? customer)
    {
        // Assignment to a nullable type was not allowed in previous versions of C#. 
        customer?.Name = "Updated";
    }

    public void DemoBefore(Customer? customer)
    {
        if (customer is not null)
        {
            customer.Name = "Updated";
        }
    }
}
