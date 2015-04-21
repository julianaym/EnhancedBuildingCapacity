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
        public string Version = Debug.GetVersion();

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


        /// <summary>
        /// The constructor sets the default values
        /// </summary>
        public Configuration()
        {
            Residential_LowDensity[Building.Levels.Level1] = new Building.Level(20, 60, 120, 120, 100, 120);
            Residential_LowDensity[Building.Levels.Level2] = new Building.Level(25, 60, 110, 110, 100, 160);
            Residential_LowDensity[Building.Levels.Level3] = new Building.Level(30, 60, 100, 100, 60, 240);
            Residential_LowDensity[Building.Levels.Level4] = new Building.Level(35, 60, 90, 90, 40, 360);
            Residential_LowDensity[Building.Levels.Level5] = new Building.Level(40, 60, 80, 80, 30, 450);

            Residential_HighDensity[Building.Levels.Level1] = new Building.Level(60, 30, 60, 60, 70, 70);
            Residential_HighDensity[Building.Levels.Level2] = new Building.Level(100, 28, 55, 55, 70, 100);
            Residential_HighDensity[Building.Levels.Level3] = new Building.Level(130, 26, 50, 50, 40, 130);
            Residential_HighDensity[Building.Levels.Level4] = new Building.Level(150, 24, 45, 45, 30, 160);
            Residential_HighDensity[Building.Levels.Level5] = new Building.Level(160, 20, 30, 40, 50, 60);

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

                [XmlIgnore]
                public readonly int defaultCapacity, defaultElectricityConsumption, defaultWaterConsumption,
                    defaultSewageAccumulation, defaultGarbageAccumulation, defaultIncomeAccumulation;

                public int Capacity, ElectricityConsumption, WaterConsumption,
                    SewageAccumulation, GarbageAccumulation, IncomeAccumulation;

                public Level() { }

                public Level(int capacity, int electricityConsumption, int waterConsumption,
                    int sewageAccumulation, int garbageAccumulation, int incomeAccumulation)
                {
                    defaultCapacity = capacity;
                    defaultElectricityConsumption = electricityConsumption;
                    defaultWaterConsumption = waterConsumption;
                    defaultSewageAccumulation = sewageAccumulation;
                    defaultGarbageAccumulation = garbageAccumulation;
                    defaultIncomeAccumulation = incomeAccumulation;

                    SetValues(capacity, electricityConsumption, waterConsumption,
                        sewageAccumulation, garbageAccumulation, incomeAccumulation);
                }

                public void SetValues(int capacity, int electricityConsumption, int waterConsumption,
                    int sewageAccumulation, int garbageAccumulation, int incomeAccumulation)
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
    }
}
