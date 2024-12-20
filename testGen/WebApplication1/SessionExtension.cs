﻿using System.Text.Json;

namespace WebApplication1
{
    public static class SessionExtensions
    {
        public static void Set<T>(this ISession session, string key, T value)
        {
            JsonSerializerOptions options = new()
            {
                ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles
            };
            session.SetString(key, JsonSerializer.Serialize(value, options));
        }
        public static T Get<T>(this ISession session, string key)
        {
            var value = session.GetString(key);
            return value == null ? default : JsonSerializer.Deserialize<T>(value);
        }
    }
}
