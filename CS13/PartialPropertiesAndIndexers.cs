namespace LanguageFeatures.CS13;

public partial class PartialMembersDemo
{
    public partial string Name { get; set; }
    public partial int this[int index] { get; set; }
}

public class PartialMembersDemoBefore
{
    private readonly int[] _items = new int[8];
    private string _name = string.Empty;

    public string Name
    {
        get => _name;
        set => _name = value;
    }

    public int this[int index]
    {
        get => _items[index];
        set => _items[index] = value;
    }
}

public partial class PartialMembersDemo
{
    private readonly int[] _items = new int[8];
    private string _name = string.Empty;

    public partial string Name
    {
        get => _name;
        set => _name = value;
    }

    public partial int this[int index]
    {
        get => _items[index];
        set => _items[index] = value;
    }
}
