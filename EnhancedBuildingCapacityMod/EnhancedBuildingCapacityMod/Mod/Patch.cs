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

                if (prefab != null && prefab.GetComponent<BuildingAI>() != null)
                {
                    BuildingAI component = prefab.GetComponent<BuildingAI>();

                    Type currentAiType = component.GetType();
                    Type newAiType = null;

                    if (currentAiType == typeof(ResidentialBuildingAI))
                        newAiType = typeof(MyResidentialBuildingAI);
                    else if (currentAiType == typeof(CommercialBuildingAI))
                        newAiType = typeof(MyCommercialBuildingAI);
                    else if (currentAiType == typeof(IndustrialBuildingAI))
                        newAiType = typeof(MyIndustrialBuildingAI);
                    else if (currentAiType == typeof(OfficeBuildingAI))
                        newAiType = typeof(MyOfficeBuildingAI);

                    if (newAiType != null)
                    {
                        BuildingAI buildingAI = prefab.gameObject.AddComponent(newAiType) as BuildingAI;

                        buildingAI.m_info = prefab;
                        prefab.m_buildingAI = buildingAI;
                        buildingAI.InitializePrefab();
                    }
                }
            }
        }
    }
}
