using System;

namespace EnhancedBuildingCapacity.Mod
{
    public static class Patch
    {
        private static int prefabCount;
        private static BuildingInfo prefab;

        public static void PatchEveryBuildingAI()
        {
            prefabCount = PrefabCollection<BuildingInfo>.PrefabCount();

            for (int i = 0; i < prefabCount; ++i)
            {
                prefab = PrefabCollection<BuildingInfo>.GetPrefab((uint)i);

                BuildingAI component = prefab.GetComponent<BuildingAI>();

                if (prefab != null && component != null)
                {
                    Type currentAiType = component.GetType();
                    Type newAiType = null;

                    if (currentAiType == typeof(ResidentialBuildingAI) || currentAiType == typeof(MyResidentialBuildingAI))
                        newAiType = typeof(MyResidentialBuildingAI);
                    else if (currentAiType == typeof(CommercialBuildingAI) || currentAiType == typeof(MyCommercialBuildingAI))
                        newAiType = typeof(MyCommercialBuildingAI);
                    else if (currentAiType == typeof(IndustrialBuildingAI) || currentAiType == typeof(MyIndustrialBuildingAI))
                        newAiType = typeof(MyIndustrialBuildingAI);
                    else if (currentAiType == typeof(IndustrialExtractorAI) || currentAiType == typeof(MyIndustrialExtractorAI))
                        newAiType = typeof(MyIndustrialExtractorAI);
                    else if (currentAiType == typeof(OfficeBuildingAI) || currentAiType == typeof(MyOfficeBuildingAI))
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
