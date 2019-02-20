using System;
using System.Collections.Generic;
using Web.Api.Core.Interfaces;

namespace Web.Api.Core.Dto.UseCaseResponses
{
    public class LoginResponse : UseCaseResponseMessage
    {
        public AccessToken AccessToken { get; }
        public string RefreshToken { get; }
        public IEnumerable<Error> Errors { get; }
        public Guid Key { get; }
        public LoginResponse(IEnumerable<Error> errors, bool success = false, string message = null) : base(success, message)
        {
            Errors = errors;
        }

        public LoginResponse(Guid key, AccessToken accessToken, string refreshToken, bool success = false, string message = null) : base(success, message)
        {
            Key = key;
            AccessToken = accessToken;
            RefreshToken = refreshToken;
        }
    }
}
