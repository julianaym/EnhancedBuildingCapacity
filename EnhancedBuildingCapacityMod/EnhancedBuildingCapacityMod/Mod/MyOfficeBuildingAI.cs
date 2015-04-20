using ColossalFramework.Math;
using UnityEngine;

namespace EnhancedBuildingCapacity.Mod
{
    public class MyOfficeBuildingAI : OfficeBuildingAI
    {
        public override void CalculateWorkplaceCount(Randomizer r, int width, int length, out int level0, out int level1, out int level2, out int level3)
        {
            ItemClass itemClass = this.m_info.m_class;
            int num1;

            #region modified code
            if (itemClass.m_level == ItemClass.Level.Level1)
            {
                num1 = XmlConfig.config.Office[Configuration.Building.Levels.Level1].Capacity;
                level0 = 0;
                level1 = 40;
                level2 = 50;
                level3 = 10;
            }
            else if (itemClass.m_level == ItemClass.Level.Level2)
            {
                num1 = XmlConfig.config.Office[Configuration.Building.Levels.Level2].Capacity;
                level0 = 0;
                level1 = 20;
                level2 = 50;
                level3 = 30;
            }
            else
            {
                num1 = XmlConfig.config.Office[Configuration.Building.Levels.Level3].Capacity;
                level0 = 0;
                level1 = 0;
                level2 = 40;
                level3 = 60;
            }
            #endregion

            if (num1 == 0)
                return;
            int num2 = Mathf.Max(200, width * length * num1 + r.Int32(100U)) / 100;
            int num3 = level0 + level1 + level2 + level3;
            if (num3 != 0)
            {
                level0 = (num2 * level0 + r.Int32((uint)num3)) / num3;
                num2 -= level0;
            }
            int num4 = level1 + level2 + level3;
            if (num4 != 0)
            {
                level1 = (num2 * level1 + r.Int32((uint)num4)) / num4;
                num2 -= level1;
            }
            int num5 = level2 + level3;
            if (num5 != 0)
            {
                level2 = (num2 * level2 + r.Int32((uint)num5)) / num5;
                num2 -= level2;
            }
            level3 = num2;
        }

        public override void GetConsumptionRates(Randomizer r, int productionRate, out int electricityConsumption, out int waterConsumption, out int sewageAccumulation, out int garbageAccumulation, out int incomeAccumulation)
        {
            ItemClass itemClass = this.m_info.m_class;
            electricityConsumption = 0;
            waterConsumption = 0;
            sewageAccumulation = 0;
            garbageAccumulation = 0;
            incomeAccumulation = 0;

            #region modified code
            switch (itemClass.m_level)
            {
                case ItemClass.Level.Level1:
                    electricityConsumption = XmlConfig.config.Office[Configuration.Building.Levels.Level1].ElectricityConsumption;
                    waterConsumption = XmlConfig.config.Office[Configuration.Building.Levels.Level1].WaterConsumption;
                    sewageAccumulation = XmlConfig.config.Office[Configuration.Building.Levels.Level1].SewageAccumulation;
                    garbageAccumulation = XmlConfig.config.Office[Configuration.Building.Levels.Level1].GarbageAccumulation;
                    incomeAccumulation = XmlConfig.config.Office[Configuration.Building.Levels.Level1].IncomeAccumulation;
                    break;
                case ItemClass.Level.Level2:
                    electricityConsumption = XmlConfig.config.Office[Configuration.Building.Levels.Level2].ElectricityConsumption;
                    waterConsumption = XmlConfig.config.Office[Configuration.Building.Levels.Level2].WaterConsumption;
                    sewageAccumulation = XmlConfig.config.Office[Configuration.Building.Levels.Level2].SewageAccumulation;
                    garbageAccumulation = XmlConfig.config.Office[Configuration.Building.Levels.Level2].GarbageAccumulation;
                    incomeAccumulation = XmlConfig.config.Office[Configuration.Building.Levels.Level2].IncomeAccumulation;
                    break;
                case ItemClass.Level.Level3:
                    electricityConsumption = XmlConfig.config.Office[Configuration.Building.Levels.Level3].ElectricityConsumption;
                    waterConsumption = XmlConfig.config.Office[Configuration.Building.Levels.Level3].WaterConsumption;
                    sewageAccumulation = XmlConfig.config.Office[Configuration.Building.Levels.Level3].SewageAccumulation;
                    garbageAccumulation = XmlConfig.config.Office[Configuration.Building.Levels.Level3].GarbageAccumulation;
                    incomeAccumulation = XmlConfig.config.Office[Configuration.Building.Levels.Level3].IncomeAccumulation;
                    break;
            }
            #endregion

            if (electricityConsumption != 0)
                electricityConsumption = Mathf.Max(100, productionRate * electricityConsumption + r.Int32(100U)) / 100;
            if (waterConsumption != 0)
            {
                int num = r.Int32(100U);
                waterConsumption = Mathf.Max(100, productionRate * waterConsumption + num) / 100;
                if (sewageAccumulation != 0)
                    sewageAccumulation = Mathf.Max(100, productionRate * sewageAccumulation + num) / 100;
            }
            else if (sewageAccumulation != 0)
                sewageAccumulation = Mathf.Max(100, productionRate * sewageAccumulation + r.Int32(100U)) / 100;
            if (garbageAccumulation != 0)
                garbageAccumulation = Mathf.Max(100, productionRate * garbageAccumulation + r.Int32(100U)) / 100;
            if (incomeAccumulation == 0)
                return;
            incomeAccumulation = productionRate * incomeAccumulation;
        }
    }
}
