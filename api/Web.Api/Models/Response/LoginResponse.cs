

using System;
using Web.Api.Core.Dto;

namespace Web.Api.Models.Response
{
    public class LoginResponse
    {
        public AccessToken AccessToken { get; }
        public string RefreshToken { get; }
        public Guid Key { get; }

        public LoginResponse(AccessToken accessToken, string refreshToken, Guid key)
        {
            AccessToken = accessToken;
            RefreshToken = refreshToken;
            Key = key;
        }
    }
}
