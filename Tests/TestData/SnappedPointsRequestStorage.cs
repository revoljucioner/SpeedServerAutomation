using SpeedServer.Models;
using Tests.Helpers;

namespace Tests.TestData
{
    public static class SnappedPointsRequestStorage
    {
        #region Data

        public static SnappedPointRequest[] TestSnappedPointRequestArray =>
            FileHelper.GetEntityFromJsonFile<SnappedPointRequest[]>("RequestFromLoger");

        #endregion

    }
}