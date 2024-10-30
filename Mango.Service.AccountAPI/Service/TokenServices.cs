using Mango.Service.AccountAPI.Models;
using Mango.Service.AccountAPI.Service.Interfaces;
using StackExchange.Redis;
using System.Text.Json;

namespace Mango.Service.AccountAPI.Service;

public class TokenServices(IConnectionMultiplexer redis) : ITokenService
{
    private readonly IDatabase _database = redis.GetDatabase();
    public async Task<bool> DeleteTokenAsync(string key)
    {
        return await _database.KeyDeleteAsync(key);
    }

    public async Task<PasswordResetToken?> GetTokenAsync(string key)
    {
        var data = await _database.StringGetAsync(key);
        return data.IsNullOrEmpty ? null : JsonSerializer.Deserialize<PasswordResetToken>(data!);
    }

    public async Task<PasswordResetToken?> SetTokenAsync(PasswordResetToken token)
    {
        var created = await _database.StringSetAsync(token.Email.ToString(), JsonSerializer.Serialize(token), TimeSpan.FromDays(30));
        if (!created) return null;
        return await GetTokenAsync(token.Id.ToString());
    }
}
