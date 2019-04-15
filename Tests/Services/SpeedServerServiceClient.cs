using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using SpeedServer.Models;

namespace Tests.Services
{
    public class SpeedServerServiceClient : BaseService
    {
        protected override string Endpoint => "api/SpeedServer";

        public async Task<HttpResponseMessage> PostSpeedServerApiGetResponse(IEnumerable<SnappedPointRequest> snappedPointsRequestArray)
        {
            return await Post(snappedPointsRequestArray);
        }

        public async Task<SpeedModel> PostSpeedServerApiAndGetSpeedModel(IEnumerable<SnappedPointRequest> snappedPointsRequestArray)
        {
            return await Post<SpeedModel>(snappedPointsRequestArray);
        }
    }
}
