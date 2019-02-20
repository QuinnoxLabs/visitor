using FluentValidation;
using Microsoft.Extensions.Options;
using System;
using Web.Api.Core.Helpers;
using Web.Api.Models.Request;

namespace Web.Api.Models.Validation
{
    public class GuestUserRequestValidator : AbstractValidator<GuestUserRequest>
    {
        private readonly ApiCustomValues _apiCustomValues;
        public GuestUserRequestValidator(IOptions<ApiCustomValues> apiCustomValues)
        {
            _apiCustomValues = apiCustomValues.Value;
        }
        public GuestUserRequestValidator()
        {
            RuleFor(x => x.FirstName).Length(2, 30);
            RuleFor(x => x.LastName).Length(2, 30);
            RuleFor(x => x.Email).EmailAddress();
            RuleFor(x => x.StartDate).GreaterThanOrEqualTo(_apiCustomValues.CurrentDateTime);
            RuleFor(x => x.EndDate).GreaterThanOrEqualTo(_apiCustomValues.CurrentDateTime).GreaterThanOrEqualTo(x=> x.StartDate);
            RuleFor(x => x.ClientId).NotEmpty().NotNull();
            RuleFor(x => x.Key).NotEmpty().NotNull();
        }
    }
}
