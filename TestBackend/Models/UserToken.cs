﻿namespace TestBackend.Models
{
    public class UserToken
    {
        public string Token { get; set; } = string.Empty;
        public DateTime Expiration { get; set; } = DateTime.UtcNow;
    }
}
