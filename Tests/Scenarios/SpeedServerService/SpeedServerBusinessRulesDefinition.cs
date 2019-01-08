using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using Tests.TestData;

namespace Tests.Scenarios.SpeedServerService
{
    public class SpeedServerBusinessRulesDefinition : BaseDefinition
    {
        [Test]
        public async Task SpeedServerApiRandomTrackShouldMovePositions()
        {
            var speedModelResponse = await SpeedServerService.PostSpeedServerApiAndGetSpeedModel(SnappedPointsRequestStorage.TestSnappedPointRequestArray);
            var speedModelExpected = SpeedModelResponseStorage.TestSnappedPointResponseArray;
            speedModelResponse.Should().BeEquivalentTo(speedModelExpected);
        }
    }
}