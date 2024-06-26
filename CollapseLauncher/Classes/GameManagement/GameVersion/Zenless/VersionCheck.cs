using Microsoft.UI.Xaml;

namespace CollapseLauncher.GameVersioning
{
    internal sealed class GameTypeZenlessVersion : GameVersionBase
    {
        #region Properties
        #endregion

        public GameTypeZenlessVersion(UIElement parentUIElement, RegionResourceProp gameRegionProp, string gameName, string gameRegion)
            : base(parentUIElement, gameRegionProp, gameName, gameRegion)
        {
            // Try check for reinitializing game version.
            TryReinitializeGameVersion();
        }

        public override bool IsGameHasDeltaPatch() => false;

        public override DeltaPatchProperty GetDeltaPatchInfo() => null;
    }
}