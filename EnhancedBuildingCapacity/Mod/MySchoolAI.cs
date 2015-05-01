using ColossalFramework;
using ColossalFramework.DataBinding;
using ColossalFramework.Math;
using System;
using UnityEngine;

namespace EnhancedBuildingCapacity.Mod
{
    public class MySchoolAI : SchoolAI
    {
        private bool _loadedConfig = false;

        private void SetStudentCount()
        {
            if (!_loadedConfig)
            {
                if (GetEducationLevel1())
                    base.m_studentCount = (int)XmlConfig.config.Schools.ElementarySchoolCapacity;
                else if (GetEducationLevel2())
                    base.m_studentCount = (int)XmlConfig.config.Schools.HighSchoolCapacity;
                else
                    base.m_studentCount = (int)XmlConfig.config.Schools.UniversityCapacity;

                _loadedConfig = true;
            }
        }

        public new void GetStudentCount(ushort buildingID, ref Building data, out int count, out int capacity, out int global)
        {
            SetStudentCount();
            base.GetStudentCount(buildingID, ref data, out count, out capacity, out global);
        }

        public override void CreateBuilding(ushort buildingID, ref Building data)
        {
            SetStudentCount();
            base.CreateBuilding(buildingID, ref data);
        }

        public override void BuildingLoaded(ushort buildingID, ref Building data, uint version)
        {
            SetStudentCount();
            base.BuildingLoaded(buildingID, ref data, version);
        }

        protected override void ProduceGoods(ushort buildingID, ref Building buildingData, ref Building.Frame frameData, int productionRate, ref Citizen.BehaviourData behaviour, int aliveWorkerCount, int totalWorkerCount, int workPlaceCount, int aliveVisitorCount, int totalVisitorCount, int visitPlaceCount)
        {
            SetStudentCount();
            base.ProduceGoods(buildingID, ref buildingData, ref frameData, productionRate, ref behaviour, aliveWorkerCount, totalWorkerCount, workPlaceCount, aliveVisitorCount, totalVisitorCount, visitPlaceCount);
        }

        public override string GetLocalizedTooltip()
        {
            SetStudentCount();
            return base.GetLocalizedTooltip();
        }
    }
}

/*
        MySchoolAI() : base()
        {
            if (base.GetEducationLevel1())
                base.m_studentCount = (int)XmlConfig.config.EducationalServices.ElementarySchoolCapacity;
            else if (base.GetEducationLevel2())
                base.m_studentCount = (int)XmlConfig.config.EducationalServices.HighSchoolCapacity;
            else
                base.m_studentCount = (int)XmlConfig.config.EducationalServices.UniversityCapacity;

            Debug.PrintMessage(base.m_studentCount);
        }
*/