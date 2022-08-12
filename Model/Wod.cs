namespace FitForTime.Model;

public class Workouts
{
    public List<WorkoutsDatum> Data { get; set; }

    public WorkoutsLinks Links { get; set; }
}

public class WorkoutsDatum
{
    public string Type { get; set; }

    public string Id { get; set; }

    public Attribs Attributes { get; set; }

    public DatumLinks Links { get; set; }
}

public partial class Attribs
{
    public DateTimeOffset CreatedAt { get; set; }

    public long ScheduledDateInt { get; set; }

    public DateTimeOffset ScheduledDate { get; set; }

    public Track Track { get; set; }

    public double DisplayOrder { get; set; }

    public string Title { get; set; }

    public string Description { get; set; }

    public string ScoreType { get; set; }

    public DateTimeOffset PublishAt { get; set; }

    public bool IsPublished { get; set; }

    public List<string> MovementIds { get; set; }
}

public class Track
{
    public string Id { get; set; }

    public string Type { get; set; }

    public AttributesFor AttributesFor { get; set; }
}

public class AttributesFor
{
    public DateTimeOffset CreatedAt { get; set; }

    public string Name { get; set; }

    public string Type { get; set; }
}

public partial class DatumLinks
{
    public Uri UiResults { get; set; }
}

public class WorkoutsLinks
{
    public Uri Self { get; set; }

    public Uri UiCalendar { get; set; }
}