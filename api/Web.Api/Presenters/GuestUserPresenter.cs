using System.Net;
using Web.Api.Core.Dto.UseCaseResponses;
using Web.Api.Core.Interfaces;
using Web.Api.Serialization;

namespace Web.Api.Presenters
{
    public sealed class GuestUserPresenter : IOutputPort<GuestUserResponse>
    {
        public JsonContentResult ContentResult { get; }

        public GuestUserPresenter()
        {
            ContentResult = new JsonContentResult();
        }

        public void Handle(GuestUserResponse response)
        {
            ContentResult.StatusCode = (int)(response.Success ? HttpStatusCode.OK : HttpStatusCode.BadRequest);
            ContentResult.Content = JsonSerializer.SerializeObject(response);
        }
    }
}
