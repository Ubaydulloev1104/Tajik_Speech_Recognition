﻿using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace TSR_Client.Identity
{
    public class CustomProblemDetails
    {
        [JsonPropertyName("status")] public int? Status { get; set; }

        [JsonPropertyName("detail")] public string? Detail { get; set; }

        [JsonPropertyName("instance")] public string? Instance { get; set; }

        [JsonPropertyName("title")] public string? Title { get; set; }

        [JsonPropertyName("type")] public string? Type { get; set; }
        [JsonPropertyName("errors")] public Dictionary<string, List<string>>? Errors { get; set; }
    }
}
