namespace FitForTime.Model;

public class Athletes
{
    [JsonPropertyName("coaches")]
    public Datum[] Data { get; set; }

    [JsonPropertyName("links")]
    public AthletesLinks Links { get; set; }
}

public class Datum
{
    [JsonPropertyName("type")]
    public string Type { get; set; }

    [JsonPropertyName("id")]
    public string Id { get; set; }

    [JsonPropertyName("attributes")]
    public Attributes Attributes { get; set; }

    [JsonPropertyName("links")]
    public DatumLinks Links { get; set; }
}

public partial class Attributes
{
    [JsonPropertyName("created_at")]
    public DateTimeOffset Created { get; set; }

    [JsonPropertyName("first_name")]
    public string FirstName { get; set; }

    [JsonPropertyName("last_name")]
    public string LastName { get; set; }

    [JsonPropertyName("email")]
    public string Email { get; set; }

    [JsonPropertyName("gender")]
    public string Gender { get; set; }

    [JsonPropertyName("profile_image_url")]
    public Uri ProfileImageUrl { get; set; }

    [JsonPropertyName("last_login")]
    public DateTimeOffset LastLogin { get; set; }
}

public partial class DatumLinks
{
    [JsonPropertyName("ui_athlete")]
    public Uri UiAthlete { get; set; }

    [JsonPropertyName("remove_from_affiliate")]
    public Uri RemoveFromAffiliate { get; set; }
}

public class AthletesLinks
{
    [JsonPropertyName("self")]
    public Uri Self { get; set; }

    [JsonPropertyName("next")]
    public Uri Next { get; set; }
}
