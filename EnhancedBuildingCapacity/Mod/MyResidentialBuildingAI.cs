using ColossalFramework.Math;
using UnityEngine;

namespace EnhancedBuildingCapacity.Mod
{
    public class MyResidentialBuildingAI : ResidentialBuildingAI
    {
        public override int CalculateHomeCount(Randomizer r, int width, int length)
        {
            ItemClass itemClass = this.m_info.m_class;

            int num = 0;

            if (itemClass.m_subService == ItemClass.SubService.ResidentialLow)
            {
                switch (itemClass.m_level)
                {
                    case ItemClass.Level.Level1:
                        num = (int)XmlConfig.config.Residential_LowDensity[Configuration.Building.Levels.Level1].Capacity;
                        break;
                    case ItemClass.Level.Level2:
                        num = (int)XmlConfig.config.Residential_LowDensity[Configuration.Building.Levels.Level2].Capacity;
                        break;
                    case ItemClass.Level.Level3:
                        num = (int)XmlConfig.config.Residential_LowDensity[Configuration.Building.Levels.Level3].Capacity;
                        break;
                    case ItemClass.Level.Level4:
                        num = (int)XmlConfig.config.Residential_LowDensity[Configuration.Building.Levels.Level4].Capacity;
                        break;
                    case ItemClass.Level.Level5:
                        num = (int)XmlConfig.config.Residential_LowDensity[Configuration.Building.Levels.Level5].Capacity;
                        break;
                }
            }
            else if (itemClass.m_subService == ItemClass.SubService.ResidentialHigh)
            {
                switch (itemClass.m_level)
                {
                    case ItemClass.Level.Level1:
                        num = (int)XmlConfig.config.Residential_HighDensity[Configuration.Building.Levels.Level1].Capacity;
                        break;
                    case ItemClass.Level.Level2:
                        num = (int)XmlConfig.config.Residential_HighDensity[Configuration.Building.Levels.Level2].Capacity;
                        break;
                    case ItemClass.Level.Level3:
                        num = (int)XmlConfig.config.Residential_HighDensity[Configuration.Building.Levels.Level3].Capacity;
                        break;
                    case ItemClass.Level.Level4:
                        num = (int)XmlConfig.config.Residential_HighDensity[Configuration.Building.Levels.Level4].Capacity;
                        break;
                    case ItemClass.Level.Level5:
                        num = (int)XmlConfig.config.Residential_HighDensity[Configuration.Building.Levels.Level5].Capacity;
                        break;
                }
            }

            return Mathf.Max(0, width * length * num + r.Int32(100U)) / 100;
        }

        public override void GetConsumptionRates(Randomizer r, int productionRate, out int electricityConsumption, out int waterConsumption, out int sewageAccumulation, out int garbageAccumulation, out int incomeAccumulation)
        {
            ItemClass itemClass = this.m_info.m_class;
            electricityConsumption = 0;
            waterConsumption = 0;
            sewageAccumulation = 0;
            garbageAccumulation = 0;
            incomeAccumulation = 0;

            if (itemClass.m_subService == ItemClass.SubService.ResidentialLow)
            {
                switch (itemClass.m_level)
                {
                    case ItemClass.Level.Level1:
                        electricityConsumption = (int)XmlConfig.config.Residential_LowDensity[Configuration.Building.Levels.Level1].ElectricityConsumption;
                        waterConsumption = (int)XmlConfig.config.Residential_LowDensity[Configuration.Building.Levels.Level1].WaterConsumption;
                        sewageAccumulation = (int)XmlConfig.config.Residential_LowDensity[Configuration.Building.Levels.Level1].SewageAccumulation;
                        garbageAccumulation = (int)XmlConfig.config.Residential_LowDensity[Configuration.Building.Levels.Level1].GarbageAccumulation;
                        incomeAccumulation = (int)XmlConfig.config.Residential_LowDensity[Configuration.Building.Levels.Level1].IncomeAccumulation;
                        break;
                    case ItemClass.Level.Level2:
                        electricityConsumption = (int)XmlConfig.config.Residential_LowDensity[Configuration.Building.Levels.Level2].ElectricityConsumption;
                        waterConsumption = (int)XmlConfig.config.Residential_LowDensity[Configuration.Building.Levels.Level2].WaterConsumption;
                        sewageAccumulation = (int)XmlConfig.config.Residential_LowDensity[Configuration.Building.Levels.Level2].SewageAccumulation;
                        garbageAccumulation = (int)XmlConfig.config.Residential_LowDensity[Configuration.Building.Levels.Level2].GarbageAccumulation;
                        incomeAccumulation = (int)XmlConfig.config.Residential_LowDensity[Configuration.Building.Levels.Level2].IncomeAccumulation;
                        break;
                    case ItemClass.Level.Level3:
                        electricityConsumption = (int)XmlConfig.config.Residential_LowDensity[Configuration.Building.Levels.Level3].ElectricityConsumption;
                        waterConsumption = (int)XmlConfig.config.Residential_LowDensity[Configuration.Building.Levels.Level3].WaterConsumption;
                        sewageAccumulation = (int)XmlConfig.config.Residential_LowDensity[Configuration.Building.Levels.Level3].SewageAccumulation;
                        garbageAccumulation = (int)XmlConfig.config.Residential_LowDensity[Configuration.Building.Levels.Level3].GarbageAccumulation;
                        incomeAccumulation = (int)XmlConfig.config.Residential_LowDensity[Configuration.Building.Levels.Level3].IncomeAccumulation;
                        break;
                    case ItemClass.Level.Level4:
                        electricityConsumption = (int)XmlConfig.config.Residential_LowDensity[Configuration.Building.Levels.Level4].ElectricityConsumption;
                        waterConsumption = (int)XmlConfig.config.Residential_LowDensity[Configuration.Building.Levels.Level4].WaterConsumption;
                        sewageAccumulation = (int)XmlConfig.config.Residential_LowDensity[Configuration.Building.Levels.Level4].SewageAccumulation;
                        garbageAccumulation = (int)XmlConfig.config.Residential_LowDensity[Configuration.Building.Levels.Level4].GarbageAccumulation;
                        incomeAccumulation = (int)XmlConfig.config.Residential_LowDensity[Configuration.Building.Levels.Level4].IncomeAccumulation;
                        break;
                    case ItemClass.Level.Level5:
                        electricityConsumption = (int)XmlConfig.config.Residential_LowDensity[Configuration.Building.Levels.Level5].ElectricityConsumption;
                        waterConsumption = (int)XmlConfig.config.Residential_LowDensity[Configuration.Building.Levels.Level5].WaterConsumption;
                        sewageAccumulation = (int)XmlConfig.config.Residential_LowDensity[Configuration.Building.Levels.Level5].SewageAccumulation;
                        garbageAccumulation = (int)XmlConfig.config.Residential_LowDensity[Configuration.Building.Levels.Level5].GarbageAccumulation;
                        incomeAccumulation = (int)XmlConfig.config.Residential_LowDensity[Configuration.Building.Levels.Level5].IncomeAccumulation;
                        break;
                }
            }
            else
            {
                switch (itemClass.m_level)
                {
                    case ItemClass.Level.Level1:
                        electricityConsumption = (int)XmlConfig.config.Residential_HighDensity[Configuration.Building.Levels.Level1].ElectricityConsumption;
                        waterConsumption = (int)XmlConfig.config.Residential_HighDensity[Configuration.Building.Levels.Level1].WaterConsumption;
                        sewageAccumulation = (int)XmlConfig.config.Residential_HighDensity[Configuration.Building.Levels.Level1].SewageAccumulation;
                        garbageAccumulation = (int)XmlConfig.config.Residential_HighDensity[Configuration.Building.Levels.Level1].GarbageAccumulation;
                        incomeAccumulation = (int)XmlConfig.config.Residential_HighDensity[Configuration.Building.Levels.Level1].IncomeAccumulation;
                        break;
                    case ItemClass.Level.Level2:
                        electricityConsumption = (int)XmlConfig.config.Residential_HighDensity[Configuration.Building.Levels.Level2].ElectricityConsumption;
                        waterConsumption = (int)XmlConfig.config.Residential_HighDensity[Configuration.Building.Levels.Level2].WaterConsumption;
                        sewageAccumulation = (int)XmlConfig.config.Residential_HighDensity[Configuration.Building.Levels.Level2].SewageAccumulation;
                        garbageAccumulation = (int)XmlConfig.config.Residential_HighDensity[Configuration.Building.Levels.Level2].GarbageAccumulation;
                        incomeAccumulation = (int)XmlConfig.config.Residential_HighDensity[Configuration.Building.Levels.Level2].IncomeAccumulation;
                        break;
                    case ItemClass.Level.Level3:
                        electricityConsumption = (int)XmlConfig.config.Residential_HighDensity[Configuration.Building.Levels.Level3].ElectricityConsumption;
                        waterConsumption = (int)XmlConfig.config.Residential_HighDensity[Configuration.Building.Levels.Level3].WaterConsumption;
                        sewageAccumulation = (int)XmlConfig.config.Residential_HighDensity[Configuration.Building.Levels.Level3].SewageAccumulation;
                        garbageAccumulation = (int)XmlConfig.config.Residential_HighDensity[Configuration.Building.Levels.Level3].GarbageAccumulation;
                        incomeAccumulation = (int)XmlConfig.config.Residential_HighDensity[Configuration.Building.Levels.Level3].IncomeAccumulation;
                        break;
                    case ItemClass.Level.Level4:
                        electricityConsumption = (int)XmlConfig.config.Residential_HighDensity[Configuration.Building.Levels.Level4].ElectricityConsumption;
                        waterConsumption = (int)XmlConfig.config.Residential_HighDensity[Configuration.Building.Levels.Level4].WaterConsumption;
                        sewageAccumulation = (int)XmlConfig.config.Residential_HighDensity[Configuration.Building.Levels.Level4].SewageAccumulation;
                        garbageAccumulation = (int)XmlConfig.config.Residential_HighDensity[Configuration.Building.Levels.Level4].GarbageAccumulation;
                        incomeAccumulation = (int)XmlConfig.config.Residential_HighDensity[Configuration.Building.Levels.Level4].IncomeAccumulation;
                        break;
                    case ItemClass.Level.Level5:
                        electricityConsumption = (int)XmlConfig.config.Residential_HighDensity[Configuration.Building.Levels.Level5].ElectricityConsumption;
                        waterConsumption = (int)XmlConfig.config.Residential_HighDensity[Configuration.Building.Levels.Level5].WaterConsumption;
                        sewageAccumulation = (int)XmlConfig.config.Residential_HighDensity[Configuration.Building.Levels.Level5].SewageAccumulation;
                        garbageAccumulation = (int)XmlConfig.config.Residential_HighDensity[Configuration.Building.Levels.Level5].GarbageAccumulation;
                        incomeAccumulation = (int)XmlConfig.config.Residential_HighDensity[Configuration.Building.Levels.Level5].IncomeAccumulation;
                        break;
                }
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
