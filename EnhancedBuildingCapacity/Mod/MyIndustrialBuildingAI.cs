using ColossalFramework.Math;
using UnityEngine;

namespace EnhancedBuildingCapacity.Mod
{
    public class MyIndustrialBuildingAI : IndustrialBuildingAI
    {
        public override void CalculateWorkplaceCount(Randomizer r, int width, int length, out int level0, out int level1, out int level2, out int level3)
        {
            ItemClass itemClass = this.m_info.m_class;
            int num1 = 0;
            level0 = 0;
            level1 = 0;
            level2 = 0;
            level3 = 0;

            if (itemClass.m_subService == ItemClass.SubService.IndustrialGeneric)
            {
                if (itemClass.m_level == ItemClass.Level.Level1)
                {
                    num1 = (int)XmlConfig.config.Industrial_Generic[Configuration.Building.Levels.Level1].Capacity;
                    level0 = 100;
                    level1 = 0;
                    level2 = 0;
                    level3 = 0;
                }
                else if (itemClass.m_level == ItemClass.Level.Level2)
                {
                    num1 = (int)XmlConfig.config.Industrial_Generic[Configuration.Building.Levels.Level2].Capacity;
                    level0 = 20;
                    level1 = 60;
                    level2 = 20;
                    level3 = 0;
                }
                else
                {
                    num1 = (int)XmlConfig.config.Industrial_Generic[Configuration.Building.Levels.Level3].Capacity;
                    level0 = 5;
                    level1 = 15;
                    level2 = 30;
                    level3 = 50;
                }
            }
            else if (itemClass.m_subService == ItemClass.SubService.IndustrialForestry)
            {
                num1 = (int)XmlConfig.config.Industrial_Forestry[Configuration.Building.Levels.None].Capacity;
                level0 = 100;
                level1 = 0;
                level2 = 0;
                level3 = 0;
            }
            else if (itemClass.m_subService == ItemClass.SubService.IndustrialFarming)
            {
                num1 = (int)XmlConfig.config.Industrial_Farming[Configuration.Building.Levels.None].Capacity;
                level0 = 100;
                level1 = 0;
                level2 = 0;
                level3 = 0;
            }
            else if (itemClass.m_subService == ItemClass.SubService.IndustrialOil)
            {
                num1 = (int)XmlConfig.config.Industrial_Oil[Configuration.Building.Levels.None].Capacity;
                level0 = 20;
                level1 = 60;
                level2 = 20;
                level3 = 0;
            }
            else if (itemClass.m_subService == ItemClass.SubService.IndustrialOre)
            {
                num1 = (int)XmlConfig.config.Industrial_Ore[Configuration.Building.Levels.None].Capacity;
                level0 = 20;
                level1 = 60;
                level2 = 20;
                level3 = 0;
            }

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

            if (itemClass.m_subService == ItemClass.SubService.IndustrialGeneric)
            {
                switch (itemClass.m_level)
                {
                    case ItemClass.Level.Level1:
                        electricityConsumption = (int)XmlConfig.config.Industrial_Generic[Configuration.Building.Levels.Level1].ElectricityConsumption;
                        waterConsumption = (int)XmlConfig.config.Industrial_Generic[Configuration.Building.Levels.Level1].WaterConsumption;
                        sewageAccumulation = (int)XmlConfig.config.Industrial_Generic[Configuration.Building.Levels.Level1].SewageAccumulation;
                        garbageAccumulation = (int)XmlConfig.config.Industrial_Generic[Configuration.Building.Levels.Level1].GarbageAccumulation;
                        incomeAccumulation = (int)XmlConfig.config.Industrial_Generic[Configuration.Building.Levels.Level1].IncomeAccumulation;
                        break;
                    case ItemClass.Level.Level2:
                        electricityConsumption = (int)XmlConfig.config.Industrial_Generic[Configuration.Building.Levels.Level2].ElectricityConsumption;
                        waterConsumption = (int)XmlConfig.config.Industrial_Generic[Configuration.Building.Levels.Level2].WaterConsumption;
                        sewageAccumulation = (int)XmlConfig.config.Industrial_Generic[Configuration.Building.Levels.Level2].SewageAccumulation;
                        garbageAccumulation = (int)XmlConfig.config.Industrial_Generic[Configuration.Building.Levels.Level2].GarbageAccumulation;
                        incomeAccumulation = (int)XmlConfig.config.Industrial_Generic[Configuration.Building.Levels.Level2].IncomeAccumulation;
                        break;
                    case ItemClass.Level.Level3:
                        electricityConsumption = (int)XmlConfig.config.Industrial_Generic[Configuration.Building.Levels.Level3].ElectricityConsumption;
                        waterConsumption = (int)XmlConfig.config.Industrial_Generic[Configuration.Building.Levels.Level3].WaterConsumption;
                        sewageAccumulation = (int)XmlConfig.config.Industrial_Generic[Configuration.Building.Levels.Level3].SewageAccumulation;
                        garbageAccumulation = (int)XmlConfig.config.Industrial_Generic[Configuration.Building.Levels.Level3].GarbageAccumulation;
                        incomeAccumulation = (int)XmlConfig.config.Industrial_Generic[Configuration.Building.Levels.Level3].IncomeAccumulation;
                        break;
                }
            }
            else if (itemClass.m_subService == ItemClass.SubService.IndustrialForestry)
            {
                electricityConsumption = (int)XmlConfig.config.Industrial_Forestry[Configuration.Building.Levels.None].ElectricityConsumption;
                waterConsumption = (int)XmlConfig.config.Industrial_Forestry[Configuration.Building.Levels.None].WaterConsumption;
                sewageAccumulation = (int)XmlConfig.config.Industrial_Forestry[Configuration.Building.Levels.None].SewageAccumulation;
                garbageAccumulation = (int)XmlConfig.config.Industrial_Forestry[Configuration.Building.Levels.None].GarbageAccumulation;
                incomeAccumulation = (int)XmlConfig.config.Industrial_Forestry[Configuration.Building.Levels.None].IncomeAccumulation;
            }
            else if (itemClass.m_subService == ItemClass.SubService.IndustrialFarming)
            {
                electricityConsumption = (int)XmlConfig.config.Industrial_Farming[Configuration.Building.Levels.None].ElectricityConsumption;
                waterConsumption = (int)XmlConfig.config.Industrial_Farming[Configuration.Building.Levels.None].WaterConsumption;
                sewageAccumulation = (int)XmlConfig.config.Industrial_Farming[Configuration.Building.Levels.None].SewageAccumulation;
                garbageAccumulation = (int)XmlConfig.config.Industrial_Farming[Configuration.Building.Levels.None].GarbageAccumulation;
                incomeAccumulation = (int)XmlConfig.config.Industrial_Farming[Configuration.Building.Levels.None].IncomeAccumulation;
            }
            else if (itemClass.m_subService == ItemClass.SubService.IndustrialOil)
            {
                electricityConsumption = (int)XmlConfig.config.Industrial_Oil[Configuration.Building.Levels.None].ElectricityConsumption;
                waterConsumption = (int)XmlConfig.config.Industrial_Oil[Configuration.Building.Levels.None].WaterConsumption;
                sewageAccumulation = (int)XmlConfig.config.Industrial_Oil[Configuration.Building.Levels.None].SewageAccumulation;
                garbageAccumulation = (int)XmlConfig.config.Industrial_Oil[Configuration.Building.Levels.None].GarbageAccumulation;
                incomeAccumulation = (int)XmlConfig.config.Industrial_Oil[Configuration.Building.Levels.None].IncomeAccumulation;
            }
            else if (itemClass.m_subService == ItemClass.SubService.IndustrialOre)
            {
                electricityConsumption = (int)XmlConfig.config.Industrial_Ore[Configuration.Building.Levels.None].ElectricityConsumption;
                waterConsumption = (int)XmlConfig.config.Industrial_Ore[Configuration.Building.Levels.None].WaterConsumption;
                sewageAccumulation = (int)XmlConfig.config.Industrial_Ore[Configuration.Building.Levels.None].SewageAccumulation;
                garbageAccumulation = (int)XmlConfig.config.Industrial_Ore[Configuration.Building.Levels.None].GarbageAccumulation;
                incomeAccumulation = (int)XmlConfig.config.Industrial_Ore[Configuration.Building.Levels.None].IncomeAccumulation;
            }

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
