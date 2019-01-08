using SpeedServer.Models;
using Tests.Helpers;

namespace Tests.TestData
{
    public static class SpeedModelResponseStorage
    {
        #region Data

        public static SpeedModel TestSnappedPointResponseArray =
            FileHelper.GetEntityFromJsonFile<SpeedModel>("ResponseToLoger");

        #endregion

    }
}