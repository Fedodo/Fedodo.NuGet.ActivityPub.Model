using Object = Fedodo.NuGet.ActivityPub.Model.CoreTypes.Object;

namespace Fedodo.NuGet.ActivityPub.Model.JsonConverters;

public class TripleSet
{
    public IEnumerable<Object>? Objects { get; set; }
    public IEnumerable<string>? StringLinks { get; set; }
    public IEnumerable<CoreTypes.Link>? Links { get; set; }
}