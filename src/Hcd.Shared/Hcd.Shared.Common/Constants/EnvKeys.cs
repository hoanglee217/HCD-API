namespace Hcd.Shared.Common.Constants;

public static class EnvKeys
{
    /// <summary>
    /// Common config
    /// </summary>
    public const string Default = "DEFAULT";

    /// <summary>
    /// Config Identity Server
    /// </summary>
    public const string IdentityConnection = "IDENTITY_CONNECTION";
    public const string IdentityServer = "IDENTITY_SERVER";

    /// <summary>
    /// config scheduler server
    /// </summary>
    public const string SchedulerConnection = "SCHEDULER_CONNECTION";
    public const string ServerSecret = "SERVER_SECRET";
    public const string TokenExpires = "TOKEN_EXPIRES";

    /// <summary>
    /// Config for hubspot
    /// </summary>
    public const string HubSpotApiKey = "HUB_SPOT_API_KEY";
    public const string HubSpotApiUrl = "HUB_SPOT_API_URL";

    /// <summary>
    /// Config for Identity Account Callback
    /// </summary>
    public const string AccountExternalProviderCallback = "ACCOUNT_EXTERNAL_PROVIDER_CALLBACK";
    public const string AccountConnectProviderCallBack = "ACCOUNT_CONNECT_PROVIDER_CALLBACK";
    public const string AccountVerificationCallbackUri = "ACCOUNT_VERIFICATION_CALLBACK_URI";
    public const string AccountPasswordResetCallbackUri = "ACCOUNT_PASSWORD_RESET_CALLBACK_URI";
    public const string ManagementClientUrl = "MANAGEMENT_CLIENT_URL";

    /// <summary>
    /// Config for external authenticate
    /// </summary>
    public const string GoogleClientId = "GOOGLE_CLIENT_ID";
    public const string GoogleClientSecret = "GOOGLE_CLIENT_SECRET";

    /// <summary>
    /// Config for management system
    /// </summary>
    public const string ManagementConnectionDefault = "MANAGEMENT_CONNECTION_DEFAULT";
    public const string ManagementConnectionUs = "MANAGEMENT_CONNECTION_US";
    public const string ManagementServerId = "MANAGEMENT_SERVER_ID";
    public const string ManagementWebhookForIdentity = "MANAGEMENT_WEBHOOK_FOR_IDENTITY";
    public const string ManagementWebhookAuthenticate = "MANAGEMENT_WEBHOOK_AUTHENTICATE";
    public static string GetManagementConnection(string tenantCode = "DEFAULT") => $"MANAGEMENT_CONNECTION_{(tenantCode + "").ToUpper()}";

    public static string GetBookingConnection(string tenantCode = "DEFAULT") => $"BOOKING_CONNECTION_{(tenantCode + "").ToUpper()}";

    /// <summary>
    /// Config for publisher realtime
    /// </summary>
    public const string PublisherConnectionDefault = "PUBLISHER_CONNECTION_DEFAULT";
    public const string PublisherMongodbDefault = "PUBLISHER_MONGODB_DEFAULT";
    public const string PublisherRedisConnectionDefault = "PUBLISHER_REDIS_CONNECTION_DEFAULT";
    public const string PublisherRedisPortDefault = "PUBLISHER_REDIS_PORT_DEFAULT";
    public const string PublisherRedisChannel = "PUBLISHER_REDIS_CHANNEL";
    public const string PublisherRealtimeServer = "PUBLISHER_REALTIME_SERVER";
    public static string GetPublisherConnection(string tenantCode = "DEFAULT") => $"PUBLISHER_CONNECTION_{(tenantCode + "").ToUpper()}";
    public static string GetPublisherMongoDb(string tenantCode = "DEFAULT") => $"PUBLISHER_MONGODB_{(tenantCode + "").ToUpper()}";

    /// <summary>
    /// Config for es log
    /// </summary>
    public const string UserNameLog = "USER_NAME_LOG";
    public const string PasswordLog = "PASSWORD_LOG";
    public const string CloudIdLog = "CLOUD_ID_LOG";

    /// <summary>
    /// Config for SMTP
    /// </summary>
    public const string EnableMail = "ENABLE_MAIL";
    public const string SmtpHost = "SMTP_HOST";
    public const string SmtpPort = "SMTP_PORT";
    public const string SmtpUsername = "SMTP_USERNAME";
    public const string SmtpPassword = "SMTP_PASSWORD";
    public const string SmtpMailFrom = "SMTP_MAIL_FROM";
    public const string SmtpMailFromName = "SMTP_MAIL_FROM_NAME";
    public const string SmtpDisplayName = "SMTP_DISPLAY_NAME";

    /// <summary>
    /// Rewrite Option for Load balancer
    /// </summary>
    public const string RewriteLoadBalancerEnable = "REWRITE_LB_ENABLE";
    public const string RewriteLoadBalancerPath = "REWRITE_LB_PATH";
}