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

                Debug.PrintMessage(XmlConfig.config.Residential_LowDensity[Configuration.Building.Levels.Level1].Capacity);
                Debug.PrintMessage(XmlConfig.config.Residential_LowDensity[Configuration.Building.Levels.Level1].ElectricityConsumption);
                Debug.PrintMessage(XmlConfig.config.Residential_LowDensity[Configuration.Building.Levels.Level1].GarbageAccumulation);
                Debug.PrintMessage(XmlConfig.config.Residential_LowDensity[Configuration.Building.Levels.Level1].IncomeAccumulation);
                Debug.PrintMessage(XmlConfig.config.Residential_LowDensity[Configuration.Building.Levels.Level1].SewageAccumulation);
                Debug.PrintMessage(XmlConfig.config.Residential_LowDensity[Configuration.Building.Levels.Level1].WaterConsumption);


                Patch.PatchEveryBuildingAI();
            }
        }
    }
}
