using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Verse;
using HarmonyLib;
using System.Reflection;
namespace VanillaPlantsExpandedFlowers
{
    [StaticConstructorOnStartup]
    public class Main
    {
        static Main()
        {
            var harmony = new Harmony("com.VanillaPlantsExpandedFlowers");
            harmony.PatchAll(Assembly.GetExecutingAssembly());
        }
    }
}
