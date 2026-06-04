namespace LanguageFeatures.CS15;
// Not yet enaabled in VS2022, but see https://devblogs.microsoft.com/dotnet/announcing-c-15-preview-1/#union-types

public interface IAnimal
{
    string Name { get; }
}

public record Cat(string Name) : IAnimal;
public record Dog(string Name) : IAnimal;
public record Bird(string Name) : IAnimal;
public record Elephant(string Name) : IAnimal;
// Note that Fish does not implement IAnimal, so it cannot be used in the DemoInterface method, but it can be used in the Pet union and the DemoUnion method.
public record Fish(string Name);

public union Pet(Cat, Dog, Bird, Fish);

public class UnionTypes
{
    [Fact]
    public void Test()
    {
        var cat = new Cat("Whiskers");
        var dog = new Dog("Fido");
        var bird = new Bird("Tweety");
        var elephant = new Elephant("Dumbo");
        var fish = new Fish("Nemo");
        Assert.Equal("Whiskers", DemoInterface(cat));
        Assert.Equal("Fido", DemoInterface(dog));
        Assert.Equal("Tweety", DemoInterface(bird));
        Assert.Equal("Dumbo", DemoInterface(elephant));
        // The following line will throw a compile-time error because Fish does not implement IAnimal. Uncommenting it will show the error.
        // Assert.Equal("Nemo", DemoInterface(fish));
        Assert.Equal("Whiskers", DemoUnion(cat));
        Assert.Equal("Fido", DemoUnion(dog));
        Assert.Equal("Tweety", DemoUnion(bird));
        Assert.Equal("Nemo", DemoUnion(fish));
        // The following line will throw a compile-time error because Elephant is not part of the Pet union. Uncommenting it will show the error.
        // Assert.Equal("Dumbo", DemoUnion(elephant));
    }

    public string DemoInterface(IAnimal animal)
    {
        return animal switch
        {
            Cat c => c.Name,
            Dog d => d.Name,
            Bird b => b.Name,
            Elephant e => e.Name,
            Fish f => f.Name,
            null => "No pet",
            _ => throw new InvalidOperationException("Unknown pet type")
        };
    }

    public string DemoUnion(Pet pet)
    {
        return pet switch
        {
            Cat c => c.Name,
            Dog d => d.Name,
            Bird b => b.Name,
            Fish f => f.Name,
            // Note that Elephant is not part of the Pet union, so this case will throw a compile-time error. Uncommenting it will show the error.
            // Elephant e => e.Name
            
            // default case is not needed because the switch is exhaustive, but if you try to add a default case, it will also throw a compile-time error because the switch is already exhaustive. Uncommenting it will show the error.
            // _ => throw new InvalidOperationException("Unknown pet type")
            
            // Also null is not part of the Pet union, so this case will also throw a compile-time error. Uncommenting it will show the error.
            // null => "No pet"
        };
    }
}
