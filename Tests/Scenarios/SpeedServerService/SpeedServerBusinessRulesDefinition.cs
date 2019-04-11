using System.Net;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using Tests.Extensions;
using Tests.TestData;

namespace Tests.Scenarios.SpeedServerService
{
    public class SpeedServerBusinessRulesDefinition : BaseDefinition
    {
        [Test]
        public async Task SpeedServerApiValidTrackShouldMovePositions()
        {
            var speedModelResponse = await SpeedServerService.PostSpeedServerApiAndGetSpeedModel(SnappedPointsRequestStorage.TestSnappedPointRequestArray);
            var speedModelExpected = SpeedModelResponseStorage.TestSnappedPointResponseArray;
            speedModelResponse.Should().BeEquivalentTo(speedModelExpected);
        }

        [Test]
        public async Task SpeedServerApiPointsWithEmptyLocationStatusBadRequest()
        {
            var snappedPointsArrayRequest = SnappedPointsRequestStorage.TestSnappedPointRequestArray;
            snappedPointsArrayRequest[0].Location = null;

            var responseMessage = await SpeedServerService.PostSpeedServerApiGetResponse(snappedPointsArrayRequest);

            responseMessage.StatusCode.Should().Be(HttpStatusCode.BadRequest);
            responseMessage.GetContentAs<string>().Should().Be("Location cannot be null");
        }
    }
}