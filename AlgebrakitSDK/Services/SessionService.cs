using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using AlgebrakitSDK.Models.Requests;
using AlgebrakitSDK.Models.Responses;

namespace AlgebrakitSDK.Services;

/// <summary>
/// Service for managing exercise sessions.
/// </summary>
public class SessionService
{
    private readonly HttpClient _httpClient;
    private readonly string _apiKey;

    /// <summary>
    /// Initializes a new instance of the <see cref="SessionService"/> class.
    /// </summary>
    /// <param name="httpClient">The HTTP client to use for API requests.</param>
    /// <param name="apiKey">The API key for authentication.</param>
    public SessionService(HttpClient httpClient, string apiKey)
    {
        _httpClient = httpClient;
        _apiKey = apiKey;

        // Add the API key to the default request headers
        _httpClient.DefaultRequestHeaders.Add("X-API-KEY", _apiKey);
    }

    /// <summary>
    /// Creates new exercise sessions.
    /// </summary>
    /// <param name="request">The request containing session details.</param>
    /// <returns>The response containing an array of created session details.</returns>
    public async Task<CreateSessionResponse> CreateSessionAsync(CreateSessionRequest request)
    {
        var jsonContent = JsonSerializer.Serialize(request);
        var httpContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");

        var response = await _httpClient.PostAsync("/session/create", httpContent);
        response.EnsureSuccessStatusCode();

        var responseContent = await response.Content.ReadAsStringAsync();
        var deserializedResponse = JsonSerializer.Deserialize<CreateSessionResponse>(responseContent);
        if (deserializedResponse == null)
        {
            throw new InvalidOperationException("Failed to deserialize CreateSessionResponse.");
        }
        return deserializedResponse;
    }

    /// <summary>
    /// Retrieves scores for a specific session.
    /// </summary>
    /// <param name="request">The request containing session ID and lock option.</param>
    /// <returns>The response containing session scores.</returns>
    public async Task<SessionScoreResponse> GetSessionScoreAsync(SessionScoreRequest request)
    {
        var jsonContent = JsonSerializer.Serialize(request);
        var httpContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");

        var response = await _httpClient.PostAsync("/session/score", httpContent);
        response.EnsureSuccessStatusCode();

        var responseContent = await response.Content.ReadAsStringAsync();
        var deserializedResponse = JsonSerializer.Deserialize<SessionScoreResponse>(responseContent);
        if (deserializedResponse == null)
        {
            throw new InvalidOperationException("Failed to deserialize SessionScoreResponse.");
        }
        return deserializedResponse;
    }

    /// <summary>
    /// Locks or unlocks exercise sessions.
    /// </summary>
    /// <param name="request">The request containing session IDs and the action to perform.</param>
    /// <returns>The response for the lock or unlock action.</returns>
    public async Task<SessionLockResponse> LockOrUnlockSessionAsync(SessionLockRequest request)
    {
        var jsonContent = JsonSerializer.Serialize(request);
        var httpContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");

        var response = await _httpClient.PostAsync("/sessions/lock", httpContent);
        response.EnsureSuccessStatusCode();

        var responseContent = await response.Content.ReadAsStringAsync();
        var deserializedResponse = JsonSerializer.Deserialize<SessionLockResponse>(responseContent);
        if (deserializedResponse == null)
        {
            throw new InvalidOperationException("Failed to deserialize SessionLockResponse.");
        }
        return deserializedResponse;
    }

    /// <summary>
    /// Retrieves information for a specific session.
    /// </summary>
    /// <param name="request">The request containing session ID.</param>
    /// <returns>The response containing session information.</returns>
    public async Task<SessionInfoResponse> GetSessionInfoAsync(SessionInfoRequest request)
    {
        var jsonContent = JsonSerializer.Serialize(request);
        var httpContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");

        var response = await _httpClient.PostAsync("/session/info", httpContent);
        response.EnsureSuccessStatusCode();

        var responseContent = await response.Content.ReadAsStringAsync();
        var deserializedResponse = JsonSerializer.Deserialize<SessionInfoResponse>(responseContent);
        if (deserializedResponse == null)
        {
            throw new InvalidOperationException("Failed to deserialize SessionInfoResponse.");
        }
        return deserializedResponse;
    }

    /// <summary>
    /// Retrieves existing sessions by their IDs.
    /// </summary>
    /// <param name="request">The request containing session IDs.</param>
    /// <returns>The response containing session data for the requested IDs.</returns>
    public async Task<SessionRetrieveResponse> RetrieveSessionsAsync(SessionRetrieveRequest request)
    {
        var jsonContent = JsonSerializer.Serialize(request);
        var httpContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");

        var response = await _httpClient.PostAsync("/session/retrieve", httpContent);
        response.EnsureSuccessStatusCode();

        var responseContent = await response.Content.ReadAsStringAsync();
        var deserializedResponse = JsonSerializer.Deserialize<SessionRetrieveResponse>(responseContent);
        if (deserializedResponse == null)
        {
            throw new InvalidOperationException("Failed to deserialize SessionRetrieveResponse.");
        }
        return deserializedResponse;
    }

    /// <summary>
    /// Validates an exercise.
    /// </summary>
    /// <param name="request">The request containing exercise details.</param>
    /// <returns>The response containing validation results.</returns>
    public async Task<ExerciseValidateResponse> ValidateExerciseAsync(ExerciseValidateRequest request)
    {
        var jsonContent = JsonSerializer.Serialize(request);
        var httpContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");

        var response = await _httpClient.PostAsync("/exercise/validate", httpContent);
        response.EnsureSuccessStatusCode();

        var responseContent = await response.Content.ReadAsStringAsync();
        var deserializedResponse = JsonSerializer.Deserialize<ExerciseValidateResponse>(responseContent);
        if (deserializedResponse == null)
        {
            throw new InvalidOperationException("Failed to deserialize ExerciseValidateResponse.");
        }
        return deserializedResponse;
    }

    /// <summary>
    /// Retrieves published information about an exercise.
    /// </summary>
    /// <param name="request">The request containing the exercise ID.</param>
    /// <returns>The response containing published info about the exercise.</returns>
    public async Task<ExerciseInfoResponse> GetExerciseInfoAsync(ExerciseInfoRequest request)
    {
        var jsonContent = JsonSerializer.Serialize(request);
        var httpContent = new StringContent(jsonContent, Encoding.UTF8, "application/json");

        var response = await _httpClient.PostAsync("/exercise/published-info", httpContent);
        response.EnsureSuccessStatusCode();

        var responseContent = await response.Content.ReadAsStringAsync();
        var deserializedResponse = JsonSerializer.Deserialize<ExerciseInfoResponse>(responseContent);
        if (deserializedResponse == null)
        {
            throw new InvalidOperationException("Failed to deserialize ExerciseInfoResponse.");
        }
        return deserializedResponse;
    }
}