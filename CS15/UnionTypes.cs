namespace LanguageFeatures.CS15;
// Not yet enaabled in VS2022, but see https://devblogs.microsoft.com/dotnet/announcing-c-15-preview-1/#union-types
public interface IAnimal
{
    string Name { get; }
}

public record class Cat(string Name) : IAnimal;
public record class Dog(string Name) : IAnimal;
public record class Bird(string Name) : IAnimal;
public record class Elephant(string Name) : IAnimal;

public union Pet(Cat, Dog, Bird);

internal class UnionTypes
{
    public string DemoInterface(IAnimal animal)
    {
        return animal switch
        {
            Cat c => c.Name,
            Dog d => d.Name,
            Bird b => b.Name,
            Elephant e => e.Name,
            _ => throw new InvalidOperationException("Unknown pet type"),
            null => "No pet"
        }
    }

    public string DemoUnion(Pet pet)
    {
        return pet switch
        {
            Cat c => c.Name,
            Dog d => d.Name,
            Bird b => b.Name,
            // Note that Elephant is not part of the Pet union, so this case will throw a compile-time error. Uncommenting it will show the error.
            // Elephant e => e.Name
            
            // default case is not needed because the switch is exhaustive, but if you try to add a default case, it will also throw a compile-time error because the switch is already exhaustive. Uncommenting it will show the error.
            // _ => throw new InvalidOperationException("Unknown pet type")
            
            // Also null is not part of the Pet union, so this case will also throw a compile-time error. Uncommenting it will show the error.
            // null => "No pet"
        }
    }
}
