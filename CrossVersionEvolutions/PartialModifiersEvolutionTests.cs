namespace LanguageFeatures.CS15;

public class PartialModifiersEvolutionTests
{
    [Fact]
    public void PartialFeatureAdvancesByLanguageVersion()
    {
        var csharp = new PartialEvolutionSample("Notifier");

        csharp.ProcessLegacy();
        Assert.Equal(0, csharp.LegacyCounter);

        Assert.Equal("HELLO", csharp.Normalize("  hello  "));

        csharp.Name = "Sample";
        csharp[0] = 21;
        Assert.Equal("Sample", csharp.Name);
        Assert.Equal(21, csharp[0]);

        var raised = false;
        csharp.Updated += (_, _) => raised = true;
        csharp.Raise();
        Assert.True(raised);
        Assert.Equal("Notifier", csharp.InstanceName);
    }

    private partial class PartialEvolutionSample
    {
        // C# 3.0: original partial method declaration rules
        // (private, void, and implementation optional).
        partial void OnProcessedLegacy();

        public int LegacyCounter { get; private set; }

        public void ProcessLegacy()
        {
            LegacyCounter++;
            OnProcessedLegacy();
            LegacyCounter--;
        }

        // C# 9.0: expanded partial methods allow accessibility and return values.
        public partial string Normalize(string input);

        // C# 13.0: partial properties and indexers declarations.
        public partial string Name { get; set; }
        public partial int this[int index] { get; set; }

        // C# 14.0: partial event and partial constructor declarations.
        public partial event EventHandler? Updated;
        public partial PartialEvolutionSample(string name);

        public string InstanceName { get; }

        public void Raise() => _updated?.Invoke(this, EventArgs.Empty);
    }

    private partial class PartialEvolutionSample
    {
        // C# 9.0 implementation side for expanded partial method.
        public partial string Normalize(string input) => input.Trim().ToUpperInvariant();

        // C# 13.0 implementation side for partial property and indexer.
        private readonly int[] _items = new int[4];
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

        // C# 14.0 implementation side for partial event/constructor.
        private EventHandler? _updated;

        public partial event EventHandler? Updated
        {
            add => _updated += value;
            remove => _updated -= value;
        }

        public partial PartialEvolutionSample(string name)
        {
            InstanceName = name;
        }
    }
}