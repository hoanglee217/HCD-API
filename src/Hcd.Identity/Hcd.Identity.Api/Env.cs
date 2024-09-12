using Hcd.Shared.Common.Constants;

namespace Hcd.Identity.Host;

public static class Env {
    public static readonly string AccountExternalProviderCallBack = Environment.GetEnvironmentVariable(EnvKeys.AccountExternalProviderCallback) ?? throw new Exception($"{EnvKeys.AccountExternalProviderCallback} is not set");
    public static readonly string AccountConnectProviderCallBack = Environment.GetEnvironmentVariable(EnvKeys.AccountConnectProviderCallBack) ?? throw new Exception($"{EnvKeys.AccountConnectProviderCallBack} is not set");
    public static readonly string GoogleClientId = Environment.GetEnvironmentVariable(EnvKeys.GoogleClientId) ?? throw new Exception($"{EnvKeys.GoogleClientId} is not set");
    public static readonly string GoogleClientSecret = Environment.GetEnvironmentVariable(EnvKeys.GoogleClientSecret) ?? throw new Exception($"{EnvKeys.GoogleClientSecret} is not set");
    public static readonly string IdentityServer = Environment.GetEnvironmentVariable(EnvKeys.IdentityServer) ?? throw new Exception($"{EnvKeys.IdentityServer} is not set");
    public static readonly bool RewriteEnable = Environment.GetEnvironmentVariable("REWRITE_LB_ENABLE") == "true";
    public static readonly string RewritePath = Environment.GetEnvironmentVariable("REWRITE_LB_PATH") ?? string.Empty;
}