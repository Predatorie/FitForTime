﻿namespace FitForTime.Services;

/// <summary>
/// Describes the ISugarWodAPIService interface.
/// </summary>
public interface ISugarWodAPIService
{
    /// <summary>
    /// Executes a rest query
    /// </summary>
    /// <typeparam name="T">The type to return</typeparam>
    /// <param name="query">The query</param>
    /// <param name="token">The cancellation token instance</param>
    /// <returns>Returns a result on success, an error of failure.</returns>
    Task<Result<T>> Get<T>(string query, CancellationToken token);
}

