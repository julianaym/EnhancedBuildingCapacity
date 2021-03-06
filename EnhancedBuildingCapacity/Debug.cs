﻿using ColossalFramework.Plugins;

namespace EnhancedBuildingCapacity
{
    /// <summary>
    /// Helper class for printing to the game's debugging console
    /// </summary>
    public static class Debug
    {
        public static void PrintMessage(object o)
        {
            DebugOutputPanel.AddMessage(PluginManager.MessageType.Message, "EnhancedBuildingCapacity: " + o.ToString());
        }

        public static void PrintWarning(object o)
        {
            DebugOutputPanel.AddMessage(PluginManager.MessageType.Warning, "EnhancedBuildingCapacity: " + o.ToString());
        }

        public static void PrintError(object o)
        {
            DebugOutputPanel.AddMessage(PluginManager.MessageType.Error, "EnhancedBuildingCapacity: " + o.ToString());
        }
        
        /// <summary>
        /// Returns the mod version
        /// </summary>
        /// <returns>The version of the mod</returns>
        public static string GetVersion()
        {
            return typeof(ModInfo).Assembly.GetName().Version.Major.ToString() + "." + typeof(ModInfo).Assembly.GetName().Version.Minor.ToString();
        }
    }
}
