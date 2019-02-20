using FluentValidation;
using Microsoft.Extensions.Options;
using System;
using Web.Api.Core.Helpers;
using Web.Api.Models.Request;

namespace Web.Api.Models.Validation
{
    public class GuestEntryRequestValidator : AbstractValidator<GuestEntryRequest>
    {
        private readonly ApiCustomValues _apiCustomValues;
        public GuestEntryRequestValidator(IOptions<ApiCustomValues> apiCustomValues)
        {
            _apiCustomValues = apiCustomValues.Value;
        }

        public GuestEntryRequestValidator()
        {
            RuleFor(x => x.GuestId).NotEmpty().NotNull();
            RuleFor(x => x.FirstName).Length(2, 30);
            RuleFor(x => x.LastName).Length(2, 30);
            RuleFor(x => x.Email).EmailAddress();
            RuleFor(x => x.StartDate).GetType().Equals(typeof(DateTime));
            RuleFor(x => x.EndDate).GreaterThanOrEqualTo(_apiCustomValues.CurrentDateTime).GreaterThanOrEqualTo(x=> x.StartDate);
            RuleFor(x => x.ClientId).NotEmpty().NotNull();
        }
    }
}
