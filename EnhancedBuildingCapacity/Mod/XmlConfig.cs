﻿using ColossalFramework.IO;
using System;
using System.IO;
using System.Xml.Serialization;

namespace EnhancedBuildingCapacity.Mod
{
    /// <summary>
    /// Class for handling saving and loading the configurations.
    /// </summary>
    public static class XmlConfig
    {
        public static Configuration config = new Configuration(true);

        private static Type[] extraTypes = {typeof(Configuration.EducationalServices), typeof(Configuration.Building), typeof(Configuration.Building.Level)};
        private static XmlSerializer xmlSerializer = new XmlSerializer(typeof(Configuration), extraTypes);
        private static string path = Path.Combine(DataLocation.applicationBase, "EnhancedBuildingCapacityConfig.xml");

        static XmlConfig()
        {
            if (!File.Exists(path))
                Save();
        }

        /// <summary>
        /// Serializes the configurations from the mods config file
        /// </summary>
        /// <returns>True if the xml serialization was successful and false otherwise</returns>
        public static bool Save()
        {
            using (TextWriter textWriter = new StreamWriter(path))
            {
                try
                {
                    xmlSerializer.Serialize(textWriter, config);
                }
                catch
                {
                    Debug.PrintError("An error occured while saving: " + path);
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Deserializes the configurations from the mods config file
        /// </summary>
        /// <returns>True if the xml deserialization was successful and false otherwise</returns>
        public static bool Load()
        {
            bool CombineDidSelfRepair = false;

            using (TextReader reader = new StreamReader(path))
            {
                try
                {
                    CombineDidSelfRepair = config.Combine((Configuration)xmlSerializer.Deserialize(reader));
                }
                catch
                {
                    Debug.PrintError("An error occured while loading: " + path);
                    return false;
                }
            }

            if (CombineDidSelfRepair)
                Save();

            return true;
        }

        /// <summary>
        /// Ensures that the game does not crash, when there are errors in the config file
        /// </summary>
        public static void SafeLoad()
        {
            if(!Load())
            {
                string backupPath = GetBackupPath();

                File.Move(path, backupPath);
                Debug.PrintWarning("Backup file created: " + backupPath + " and new file with default values created!");

                config = new Configuration(true); // Thanks Garbage Collector! :)
                Save();
            }
        }

        /// <summary>
        /// Loops through the games main directory and looks for the smalles non-existing numbered backup filename
        /// </summary>
        /// <returns>The full backup path (with filename) as a string</returns>
        public static string GetBackupPath()
        {
            if(File.Exists(Path.Combine(DataLocation.applicationBase, "EnhancedBuildingCapacityConfigBACKUP.xml")))
            {
                int index = 2;
                while (File.Exists(Path.Combine(DataLocation.applicationBase, "EnhancedBuildingCapacityConfigBACKUP" + index + ".xml")))
                {
                    ++index;
                }
                return Path.Combine(DataLocation.applicationBase, "EnhancedBuildingCapacityConfigBACKUP" + index + ".xml");
            }
            return Path.Combine(DataLocation.applicationBase, "EnhancedBuildingCapacityConfigBACKUP.xml");
        }
    }
}
