using System.Collections.Generic;
using System.Text.Json.Serialization;
using AlgebrakitSDK.Models.Shared;

namespace AlgebrakitSDK.Models.Responses;

/// <summary>
/// Response for retrieving existing sessions.
/// </summary>
public class SessionRetrieveResponse : List<Session>
{
}
