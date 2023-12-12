using System.Text.Json;

namespace ElectRight.Infrastructure.App.Candidate.Models;

public interface IImmutableCopy<T>
{
    public T? DeepCopy()
    {
        var json = JsonSerializer.Serialize(this);
        return JsonSerializer.Deserialize<T>(json);
    }
    public T ShallowCopy()
    {
        return (T)this.MemberwiseClone();
    }
}