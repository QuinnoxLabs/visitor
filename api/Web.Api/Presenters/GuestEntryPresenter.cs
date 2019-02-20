using System.Net;
using Web.Api.Core.Dto.UseCaseResponses;
using Web.Api.Core.Interfaces;
using Web.Api.Serialization;

namespace Web.Api.Presenters
{
    public sealed class GuestEntryPresenter : IOutputPort<GuestEntryResponse>
    {
        public JsonContentResult ContentResult { get; }

        public GuestEntryPresenter()
        {
            ContentResult = new JsonContentResult();
        }

        public void Handle(GuestEntryResponse response)
        {
            ContentResult.StatusCode = (int)(response.Success ? HttpStatusCode.OK : HttpStatusCode.BadRequest);
            ContentResult.Content = JsonSerializer.SerializeObject(response);
        }
    }
}
