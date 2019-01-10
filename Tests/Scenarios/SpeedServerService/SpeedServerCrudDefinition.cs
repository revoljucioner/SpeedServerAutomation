using System.Net;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using Tests.Extensions;
using Tests.TestData;

namespace Tests.Scenarios.SpeedServerService
{
    public class SpeedServerCrudDefinition: BaseDefinition
    {
        [Test]
        public async Task SpeedServerApiValidTrackStatusOk()
        {
            var httpResponseMessage = await SpeedServerService.PostSpeedServerApiGetResponse(SnappedPointsRequestStorage.TestSnappedPointRequestArray);

            httpResponseMessage.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Test]
        public async Task SpeedServerApiEmptyTrackStatusBadRequest()
        {
            var httpResponseMessage = await SpeedServerService.PostSpeedServerApiGetResponse(null);

            httpResponseMessage.StatusCode.Should().Be(HttpStatusCode.BadRequest);
            httpResponseMessage.GeContentAs<string>().Should().Be("Track is empty");
        }
    }
}