namespace LanguageFeatures.CS14;

internal struct Counter(int value)
{
    public int Value { get; private set; } = value;

    // C# 14 allows user-defined compound assignment operators.
    // This means that you can define how the += operator
    // (and other compound assignment operators) behave for your types.
    public void operator +=(int amount)
    {
        Value += amount;
    }
}

internal readonly struct CounterBefore(int value)
{
    public int Value { get; } = value;

    // Before C# 14, you would have to define a regular addition operator
    // and then use it in your code to achieve similar functionality.
    public static CounterBefore operator +(CounterBefore counter, int amount)
        => new(counter.Value + amount);
}

public class _UserDefinedCompoundAssignmentOperators
{
    [Fact]
    public void Demo()
    {
        Counter counter = new(5);
        // Compound operator assignment is new in C# 14.
        counter += 3;
        Assert.Equal(8, counter.Value);
    }

    [Fact]
    public void DemoBefore()
    {
        CounterBefore counter = new(5);
        counter = counter + 3;
        Assert.Equal(8, counter.Value);
    }
}
