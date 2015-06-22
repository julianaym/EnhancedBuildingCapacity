using System;

namespace EnhancedBuildingCapacity.Mod
{
    public static class Patch
    {
        private static int prefabCount;
        private static BuildingInfo prefab;
        private static BuildingAI component;

        public static void PatchEveryBuildingAI()
        {
            prefabCount = PrefabCollection<BuildingInfo>.PrefabCount();

            for (int i = 0; i < prefabCount; ++i)
            {
                prefab = PrefabCollection<BuildingInfo>.GetPrefab((uint)i);
                
                if (prefab != null)
                {
                    component = prefab.GetComponent<BuildingAI>();

                    if (component != null)
                    {
                        Type currentAiType = component.GetType();
                        Type newAiType = null;

                        if (currentAiType == typeof(ResidentialBuildingAI))
                            newAiType = typeof(MyResidentialBuildingAI);
                        else if (currentAiType == typeof(CommercialBuildingAI))
                            newAiType = typeof(MyCommercialBuildingAI);
                        else if (currentAiType == typeof(IndustrialBuildingAI))
                            newAiType = typeof(MyIndustrialBuildingAI);
                        else if (currentAiType == typeof(IndustrialExtractorAI))
                            newAiType = typeof(MyIndustrialExtractorAI);
                        else if (currentAiType == typeof(OfficeBuildingAI))
                            newAiType = typeof(MyOfficeBuildingAI);

                        if (newAiType != null)
                        {
                            BuildingAI buildingAI = (BuildingAI)prefab.gameObject.AddComponent(newAiType);

                            buildingAI.m_info = prefab;
                            prefab.m_buildingAI = buildingAI;
                            buildingAI.InitializePrefab();
                        }
                    }
                }
            }
        }
    }
}
