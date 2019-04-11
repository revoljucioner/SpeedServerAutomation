using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SpeedServer.Models;
using Tests.Extensions;

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
