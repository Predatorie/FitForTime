
namespace FitForTime.Services;
public interface ISugarWodManager
{
    Task<Result<Athletes>> GetAthletesAsync(string role, CancellationToken cancellationToken);

    Task<Result<Athletes>> GetAthletesNextAsync(string page, CancellationToken cancellationToken);

    Task<Result<Workouts>> GetWorkoutsAsync(CancellationToken cancellationToken);
}


