namespace FitForTime.Services;

public interface ISugarWodAPIService
{
    Task<Result<T>> Get<T>(string query, CancellationToken token);
}

