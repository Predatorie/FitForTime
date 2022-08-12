﻿namespace FitForTime.Services;

internal class SugarWodApiService : ISugarWodAPIService
{
    private readonly IHttpClientFactory httpClientFactory;

    public SugarWodApiService(IHttpClientFactory factory)
    {
        httpClientFactory = factory;
    }

    public async Task<Result<T>> Get<T>(string query, CancellationToken token)
    {
        try
        {
            // create our registered client
            var client = httpClientFactory.CreateClient("SugarWOD");
            // execute the get using out policies
            var response = await client.GetAsync(query, token);
            if (response.IsSuccessStatusCode)
            {
                var model = await response.Content.ReadFromJsonAsync<T>(cancellationToken: token);
                return Result.Ok(model);
            }

            if (token.IsCancellationRequested) token.ThrowIfCancellationRequested();

            var message = $"{response.StatusCode}";
            return Result.Fail<T>($"{message}");
        }
        catch (JsonException j)
        {
            return Result.Fail<T>(j.Message);
        }
        catch (OperationCanceledException o)
        {
            return Result.Fail<T>(o.Message);
        }
        catch (Exception e)
        {
            return Result.Fail<T>(e.Message);
        }
    }
}

