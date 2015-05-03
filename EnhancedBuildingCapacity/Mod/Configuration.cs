using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;

namespace EnhancedBuildingCapacity.Mod
{
    /// <summary>
    /// Some dirty code for storing all your configurations
    /// </summary>
    [XmlRootAttribute(Namespace = "https://github.com/julianaym/EnhancedBuildingCapacity", IsNullable = false)]
    public class Configuration
    {
        public string Version;

        [XmlElement("EducationalServices")]
        public EducationalServices Schools;

        public Building Residential_LowDensity = new Building(Building.Types.Residential);
        public Building Residential_HighDensity = new Building(Building.Types.Residential);
        public Building Commercial_LowDensity = new Building(Building.Types.Commercial);
        public Building Commercial_HighDensity = new Building(Building.Types.Commercial);
        public Building Industrial_Generic = new Building(Building.Types.IndustrialGeneretic);
        public Building Industrial_Forestry = new Building(Building.Types.IndustrialSpecial);
        public Building Industrial_Farming = new Building(Building.Types.IndustrialSpecial);
        public Building Industrial_Oil = new Building(Building.Types.IndustrialSpecial);
        public Building Industrial_Ore = new Building(Building.Types.IndustrialSpecial);
        public Building Office = new Building(Building.Types.Office);

        public Configuration() // When the xml deserializer calls the constructor no variables will be 
        {
        }

        public Configuration(bool setDefault) // This is called by the XmlConfig class to set the default values
        {
            Version = Debug.GetVersion();

            Schools = new EducationalServices(false, 300, 1000, 4500);

            Residential_LowDensity[Building.Levels.Level1] = new Building.Level(20, 60, 120, 120, 100, 120);
            Residential_LowDensity[Building.Levels.Level2] = new Building.Level(25, 60, 110, 110, 100, 160);
            Residential_LowDensity[Building.Levels.Level3] = new Building.Level(30, 60, 100, 100, 60, 240);
            Residential_LowDensity[Building.Levels.Level4] = new Building.Level(35, 60, 90, 90, 40, 360);
            Residential_LowDensity[Building.Levels.Level5] = new Building.Level(40, 60, 80, 80, 30, 450);

            Residential_HighDensity[Building.Levels.Level1] = new Building.Level(60, 30, 60, 60, 70, 70);
            Residential_HighDensity[Building.Levels.Level2] = new Building.Level(100, 28, 55, 55, 70, 100);
            Residential_HighDensity[Building.Levels.Level3] = new Building.Level(130, 26, 50, 50, 40, 130);
            Residential_HighDensity[Building.Levels.Level4] = new Building.Level(150, 24, 45, 45, 30, 160);
            Residential_HighDensity[Building.Levels.Level5] = new Building.Level(160, 22, 40, 40, 20, 200);

            Commercial_LowDensity[Building.Levels.Level1] = new Building.Level(50, 50, 60, 60, 100, 520);
            Commercial_LowDensity[Building.Levels.Level2] = new Building.Level(75, 60, 80, 80, 50, 800);
            Commercial_LowDensity[Building.Levels.Level3] = new Building.Level(100, 70, 100, 100, 25, 1120);

            Commercial_HighDensity[Building.Levels.Level1] = new Building.Level(75, 30, 70, 70, 50, 280);
            Commercial_HighDensity[Building.Levels.Level2] = new Building.Level(100, 30, 60, 60, 50, 560);
            Commercial_HighDensity[Building.Levels.Level3] = new Building.Level(125, 30, 50, 50, 25, 800);

            Industrial_Generic[Building.Levels.Level1] = new Building.Level(100, 150, 100, 100, 200, 160);
            Industrial_Generic[Building.Levels.Level2] = new Building.Level(150, 200, 130, 130, 150, 200);
            Industrial_Generic[Building.Levels.Level3] = new Building.Level(200, 250, 160, 160, 100, 240);

            Industrial_Forestry[Building.Levels.None] = new Building.Level(100, 90, 60, 60, 100, 140);
            Industrial_Farming[Building.Levels.None] = new Building.Level(100, 110, 350, 350, 150, 180);
            Industrial_Oil[Building.Levels.None] = new Building.Level(150, 350, 200, 200, 200, 360);
            Industrial_Ore[Building.Levels.None] = new Building.Level(150, 300, 250, 250, 150, 300);

            Office[Building.Levels.Level1] = new Building.Level(50, 80, 90, 90, 100, 140);
            Office[Building.Levels.Level2] = new Building.Level(110, 100, 100, 100, 50, 200);
            Office[Building.Levels.Level3] = new Building.Level(170, 120, 110, 110, 25, 300);
        }

        public class EducationalServices
        {
            [XmlAttribute("override")]
            public bool? OverrideSchoolCapacity;

            public int? ElementarySchoolCapacity,
                HighSchoolCapacity, UniversityCapacity;

            public EducationalServices() { }

            public EducationalServices(bool? overrideSchoolCapacity, int? elementarySchoolCapacity, int? highSchoolCapacity, int? universityCapacity)
            {
                OverrideSchoolCapacity = overrideSchoolCapacity;
                ElementarySchoolCapacity = elementarySchoolCapacity;
                HighSchoolCapacity = highSchoolCapacity;
                UniversityCapacity = universityCapacity;
            }
        }

        public class Building
        {
            public enum Types { Residential = 5, Commercial = 3, IndustrialGeneretic = 3, IndustrialSpecial = 1, Office = 3 };
            public enum Levels { None = 0, Level1 = 0, Level2 = 1, Level3 = 2, Level4 = 3, Level5 = 4 };

            [XmlElement("Level")]
            public Level[] levels;

            public Level this[Levels level]
            {
                get
                {
                    return levels[(int)level];
                }
                set
                {
                    levels[(int)level] = value;
                    levels[(int)level].SetRank((int)level);
                }
            }

            public Building() { }
            public Building(Types type)
            {
                levels = new Level[(int)type];
            }

            public class Level
            {
                [XmlAttribute("rank")]
                public int rank;

                // The values are nullable because otherwise the values will be set to 0 if the xml deserializer can't find them in the config file,
                // thus the self-repair part of the Combine function would not work
                public int? Capacity, ElectricityConsumption, WaterConsumption,
                    SewageAccumulation, GarbageAccumulation, IncomeAccumulation;

                public Level() { }

                public Level(int? capacity, int? electricityConsumption, int? waterConsumption, int? sewageAccumulation, int? garbageAccumulation, int? incomeAccumulation)
                {
                    Capacity = capacity;
                    ElectricityConsumption = electricityConsumption;
                    WaterConsumption = waterConsumption;
                    SewageAccumulation = sewageAccumulation;
                    GarbageAccumulation = garbageAccumulation;
                    IncomeAccumulation = incomeAccumulation;
                }

                public void SetRank(int index)
                {
                    rank = index + 1;
                }
            }
        }

        /// <summary>
        /// Combines the class instance which called this function with the given secondary instance and also does a simple self-repair of the loaded config file data
        /// </summary>
        /// <param name="secondaryConfig">Configuration instance to combine the primary with</param>
        /// <returns>If the loaded config file data got repaired</returns>
        public bool Combine(Configuration secondaryConfig)
        {
            bool DidSelfRepair = false;

            if (this.Version != secondaryConfig.Version)
            {
                Debug.PrintMessage("Outdated config file found! Upgrading to newer version...");
                DidSelfRepair = true;
            }

            try
            {
                this.Schools.OverrideSchoolCapacity = secondaryConfig.Schools.OverrideSchoolCapacity ?? this.Schools.OverrideSchoolCapacity;

                if (secondaryConfig.Schools.OverrideSchoolCapacity == null)
                    DidSelfRepair = true;

                this.Schools.ElementarySchoolCapacity = secondaryConfig.Schools.ElementarySchoolCapacity ?? this.Schools.ElementarySchoolCapacity;
                this.Schools.HighSchoolCapacity = secondaryConfig.Schools.HighSchoolCapacity ?? this.Schools.HighSchoolCapacity;
                this.Schools.UniversityCapacity = secondaryConfig.Schools.UniversityCapacity ?? this.Schools.UniversityCapacity;

                if (secondaryConfig.Schools.ElementarySchoolCapacity == null ||
                    secondaryConfig.Schools.HighSchoolCapacity == null ||
                    secondaryConfig.Schools.UniversityCapacity == null)
                    DidSelfRepair = true;
            }
            catch
            {
                // This will only occur when the block is missing in the xml
                DidSelfRepair = true;
            }

            Dictionary<Building, Building> buildings = new Dictionary<Building, Building>();
            buildings.Add(this.Residential_LowDensity, secondaryConfig.Residential_LowDensity);
            buildings.Add(this.Residential_HighDensity, secondaryConfig.Residential_HighDensity);
            buildings.Add(this.Commercial_LowDensity, secondaryConfig.Commercial_LowDensity);
            buildings.Add(this.Commercial_HighDensity, secondaryConfig.Commercial_HighDensity);
            buildings.Add(this.Industrial_Generic, secondaryConfig.Industrial_Generic);
            buildings.Add(this.Industrial_Forestry, secondaryConfig.Industrial_Forestry);
            buildings.Add(this.Industrial_Farming, secondaryConfig.Industrial_Farming);
            buildings.Add(this.Industrial_Oil, secondaryConfig.Industrial_Oil);
            buildings.Add(this.Industrial_Ore, secondaryConfig.Industrial_Ore);
            buildings.Add(this.Office, secondaryConfig.Office);

            foreach (KeyValuePair<Building, Building> building in buildings)
            {
                Building Primary = building.Key;
                Building Secondary = building.Value;

                for (int i = 0; i < Secondary.levels.Length; ++i)
                {
                    try
                    {
                        int index = Secondary.levels[i].rank - 1;

                        if (index <= Primary.levels.Length)
                        {
                            Primary.levels[index].Capacity = Secondary.levels[i].Capacity ?? Primary.levels[index].Capacity;
                            Primary.levels[index].ElectricityConsumption = Secondary.levels[i].ElectricityConsumption ?? Primary.levels[index].ElectricityConsumption;
                            Primary.levels[index].WaterConsumption = Secondary.levels[i].WaterConsumption ?? Primary.levels[index].WaterConsumption;
                            Primary.levels[index].SewageAccumulation = Secondary.levels[i].SewageAccumulation ?? Primary.levels[index].SewageAccumulation;
                            Primary.levels[index].GarbageAccumulation = Secondary.levels[i].GarbageAccumulation ?? Primary.levels[index].GarbageAccumulation;
                            Primary.levels[index].IncomeAccumulation = Secondary.levels[i].IncomeAccumulation ?? Primary.levels[index].IncomeAccumulation;

                            if (Secondary.levels[i].Capacity == null || Secondary.levels[i].ElectricityConsumption == null || Secondary.levels[i].WaterConsumption == null ||
                                Secondary.levels[i].SewageAccumulation == null || Secondary.levels[i].GarbageAccumulation == null || Secondary.levels[i].IncomeAccumulation == null)
                                DidSelfRepair = true;
                        }
                    }
                    catch
                    {
                        Debug.PrintError("Could not repair configuration file!");
                        return false; // Don't save failed self-repair
                    }
                }
            }
            return DidSelfRepair;
        }
    }
}
