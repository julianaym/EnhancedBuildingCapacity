using EnhancedBuildingCapacity.Mod;
using ICities;

namespace EnhancedBuildingCapacity
{
    public class LoadingExtension : LoadingExtensionBase
    {
        public override void OnLevelLoaded(LoadMode mode)
        {
            if (mode == LoadMode.NewGame || mode == LoadMode.LoadGame)
            {
                XmlConfig.SafeLoad();

                Debug.PrintMessage("Successfully loaded mod v" + Debug.GetVersion());

                Patch.PatchEveryBuildingAI();
            }
        }
    }
}
