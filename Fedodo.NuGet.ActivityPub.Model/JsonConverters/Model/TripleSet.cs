using Fedodo.NuGet.ActivityPub.Model.CoreTypes;

namespace Fedodo.NuGet.ActivityPub.Model.JsonConverters.Model;

/// <summary>
///     This class is a Model to represent valid JSON syntax which can not be implemented in C# with an other type.
///     It enables you to store Objects of type T, StringLinks and Activity Pub Links in one object.
/// </summary>
/// <typeparam name="T">The type of the Objects collection.</typeparam>
public class TripleSet<T>
{
    public IEnumerable<T>? Objects { get; set; }
    public IEnumerable<string>? StringLinks { get; set; }
    public IEnumerable<Link>? Links { get; set; }
}