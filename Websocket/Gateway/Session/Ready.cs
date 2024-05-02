using System.Text.Json;
using Newtonsoft.Json;
using wyrm_discord.Rest.Extensions;

namespace wyrm_discord.Websocket.Gateway.Session;
public class Ready {
    [JsonProperty("v")]
    public int V { get; set; }

    [JsonProperty("user_settings_proto")]
    public string? UserSettingsProto { get; set; }

    [JsonProperty("user_settings")] 
    public UserSettings? UserSettings { get; set; }

    [JsonProperty("user_guild_settings")] 
    public List<UserGuildSetting>? UserGuildSettings { get; set; }

    [JsonProperty("user")] 
    public User? User { get; set; }

    [JsonProperty("sessions")] 
    public List<Session>? Sessions { get; set; }

    [JsonProperty("session_type")] 
    public string? SessionType { get; set; }

    [JsonProperty("session_id")] 
    public string? SessionId { get; set; }

    [JsonProperty("resume_gateway_url")] 
    public string? ResumeGatewayUrl { get; set; }

    [JsonProperty("relationships")] 
    public List<object>? Relationships { get; set; }

    [JsonProperty("read_state")] 
    public List<ReadState>? ReadState { get; set; }

    [JsonProperty("private_channels")] 
    public List<object>? PrivateChannels { get; set; }

    [JsonProperty("presences")] 
    public List<object>? Presences { get; set; }

    [JsonProperty("notification_settings")] 
    public NotificationSettings? NotificationSettings { get; set; }

    [JsonProperty("notes")] 
    public Notes? Notes { get; set; }

    [JsonProperty("guilds")] 
    public List<Guild>? Guilds { get; set; }

    [JsonProperty("guild_join_requests")] 
    public List<object>? GuildJoinRequests { get; set; }

    [JsonProperty("guild_experiments")] 
    public List<List<object>>? GuildExperiments { get; set; }

    [JsonProperty("geo_ordered_rtc_regions")] 
    public List<string>? GeoOrderedRtcRegions { get; set; }

    [JsonProperty("friend_suggestion_count")] 
    public int FriendSuggestionCount { get; set; }

    [JsonProperty("experiments")] 
    public List<List<object>>? Experiments { get; set; }

    [JsonProperty("country_code")] 
    public string? CountryCode { get; set; }

    [JsonProperty("consents")] 
    public Consents? Consents { get; set; }

    [JsonProperty("connected_accounts")] 
    public List<object>? ConnectedAccounts { get; set; }

    [JsonProperty("auth_session_id_hash")] 
    public string? AuthSessionIdHash { get; set; }

    [JsonProperty("auth")] 
    public Auth? Auth { get; set; }

    [JsonProperty("api_code_version")] 
    public int ApiCodeVersion { get; set; }

    [JsonProperty("analytics_token")] 
    public string? AnalyticsToken { get; set; }

    [JsonProperty("_trace")] 
    public List<string>? Trace { get; set; }
}

public class Session {
    [JsonProperty("status")] 
    public string? Status { get; set; }

    [JsonProperty("session_id")] 
    public string? SessionId { get; set; }

    [JsonProperty("client_info")] 
    public ClientInfo? ClientInfo { get; set; }

    [JsonProperty("activities")] 
    public List<object>? Activities { get; set; }
}

public class UserSettings {
    [JsonProperty("detect_platform_accounts")] 
    public bool DetectPlatformAccounts { get; set; }
}

public class UserGuildSetting {
    [JsonProperty("version")] 
    public int Version { get; set; }
}

public class User {
    [JsonProperty("verified")]
    public bool Verified { get; set; }

    [JsonProperty("username")]
    public string? Username { get; set; }
}

public class ReadState {
    [JsonProperty("mention_count")] 
    public int MentionCount { get; set; }
}

public class NotificationSettings {
    [JsonProperty("flags")] 
    public int Flags { get; set; }
}

public class Notes {
}

public class Consents {
    [JsonProperty("personalization")] 
    public Personalization? Personalization { get; set; }
}

public class Personalization {
    [JsonProperty("consented")] 
    public bool Consented { get; set; }
}

public class Auth {
    [JsonProperty("authenticator_types")] 
    public List<object>? AuthenticatorTypes { get; set; }
}

public class ClientInfo {
    [JsonProperty("version")] 
    public int Version { get; set; }
}

