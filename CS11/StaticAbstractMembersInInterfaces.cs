using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageFeatures.CS11;

public class StaticAbstractMembersInInterfaces
{
    [Fact]
    public async Task CanLoadFromFactory()
    {
        var myThing = await MyBusinessObject.Load(123);
        Assert.Equal(123, myThing.Id);
        Assert.Equal("Works", myThing.Name);
    }
}

public class MyBusinessObject : IBusinessFactory<MyBusinessObject>
{
    private MyBusinessObject()
    {
        Id = 0;
        Name = "Don't expose Constructor";
    }

    public int Id { get; init; }
    public string Name { get; set; }

    public static async Task<MyBusinessObject> Load(int id)
    {
        var instance = await Task.FromResult(new MyBusinessObject { Id = id, Name = "Works" }); ;
        return instance;
    }
}

public interface IBusinessFactory<T>
{
    static abstract Task<T> Load(int Id);
}