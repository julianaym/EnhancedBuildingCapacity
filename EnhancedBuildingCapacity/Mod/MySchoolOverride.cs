using ColossalFramework;
using ColossalFramework.DataBinding;
using ColossalFramework.Math;
using ICities;
using System;
using UnityEngine;

namespace EnhancedBuildingCapacity.Mod
{
    public class MySchoolOverride : IThreadingExtension
    {
        public void OnBeforeSimulationTick()
        {
            BuildingInfo prefab;
            BuildingAI component;

            ItemClass.Level schoolLevel;

            if ((bool)XmlConfig.config.Schools.OverrideSchoolCapacity)
            {
                int prefebCount = PrefabCollection<BuildingInfo>.PrefabCount();

                for (int i = 0; i < prefebCount; ++i)
                {
                    prefab = PrefabCollection<BuildingInfo>.GetPrefab((uint)i);

                    if (prefab != null)
                    {
                        component = prefab.GetComponent<BuildingAI>();

                        if (component != null && component.GetType() == typeof(SchoolAI))
                        {
                            try
                            {
                                schoolLevel = (ItemClass.Level)typeof(ItemClass).GetField("m_level").GetValue(component.m_info.m_class);
                                if (schoolLevel == ItemClass.Level.Level1)
                                    typeof(SchoolAI).GetField("m_studentCount").SetValue(component, (int)XmlConfig.config.Schools.ElementarySchoolCapacity);
                                else if (schoolLevel == ItemClass.Level.Level2)
                                    typeof(SchoolAI).GetField("m_studentCount").SetValue(component, (int)XmlConfig.config.Schools.HighSchoolCapacity);
                                else
                                    typeof(SchoolAI).GetField("m_studentCount").SetValue(component, (int)XmlConfig.config.Schools.UniversityCapacity);
                            }
                            catch
                            {
                                Debug.PrintWarning("Could not set m_studentCount");
                            }
                        }
                    }
                }
            }
        }

        public void OnCreated(IThreading threading)
        { }

        public void OnReleased()
        { }

        public void OnUpdate(float realTimeDelta, float simulationTimeDelta)
        { }

        public void OnBeforeSimulationFrame()
        { }

        public void OnAfterSimulationFrame()
        { }

        public void OnAfterSimulationTick()
        { }
    }
}