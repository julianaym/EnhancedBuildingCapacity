using ICities;
using System.IO;
using EnhancedBuildingCapacity.Mod;
using ColossalFramework.Plugins;
using ColossalFramework.IO;
using UnityEngine;

namespace EnhancedBuildingCapacity
{
    public class LoadingExtension : LoadingExtensionBase
    {
        public override void OnLevelLoaded(LoadMode mode)
        {
            if (mode == LoadMode.NewGame || mode == LoadMode.LoadGame)
            {
                XmlConfig.Initialize();

                Debug.PrintMessage("Successfully loaded mod v" + Debug.GetVersion());

                Patch.PatchEveryBuildingAI();
            }
        }
    }
}
