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
            var responseMessage = await SpeedServerService.PostSpeedServerApiGetResponse(SnappedPointsRequestStorage.TestSnappedPointRequestArray);

            responseMessage.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Test]
        public async Task SpeedServerApiEmptyTrackStatusBadRequest()
        {
            var responseMessage = await SpeedServerService.PostSpeedServerApiGetResponse(null);

            responseMessage.StatusCode.Should().Be(HttpStatusCode.BadRequest);
            responseMessage.GeContentAs<string>().Should().Be("Track is empty");
        }
    }
}