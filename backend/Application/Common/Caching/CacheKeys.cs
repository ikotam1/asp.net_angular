using System;

namespace Application.Common.Caching;

public static class CacheKeys
{
    public static string RefreshToken(string token) => $"refresh_token:{token}";
}