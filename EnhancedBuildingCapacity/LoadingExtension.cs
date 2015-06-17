using ColossalFramework.IO;
using EnhancedBuildingCapacity.Mod;
using ICities;
using System.IO;

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
                Debug.PrintMessage("The config file can be found at: " + Path.Combine(DataLocation.applicationBase, "EnhancedBuildingCapacityConfig.xml"));

                Patch.PatchEveryBuildingAI();
            }
        }
    }
}
