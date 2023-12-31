
/*      BepInEx      */
global using BepInEx;
global using BepInEx.Logging;
global using HarmonyLib;

/*       Unity       */
global using UnityEngine;
global using UnityEngine.UI;
global using UnityEngine.Animations;
global using UnityEngine.AddressableAssets;

/*       System      */
global using System;
global using System.IO;
global using System.Collections;
global using System.Collections.Generic;
global using System.Linq;

/*       Nautilus    */
global using Nautilus.Assets;
global using Nautilus.Assets.Gadgets;
global using Nautilus.Assets.PrefabTemplates;
global using Nautilus.Commands;
global using Nautilus.Crafting;
global using Nautilus.Extensions;
global using Nautilus.FMod;
global using Nautilus.FMod.Interfaces;
global using Nautilus.Handlers;
global using Nautilus.Json;
global using Nautilus.Json.Attributes;
global using Nautilus.Json.Converters;
global using Nautilus.Json.ExtensionMethods;
global using Nautilus.Json.Interfaces;
global using Nautilus.Options;
global using Nautilus.Options.Attributes;
global using Nautilus.Utility;
global using Nautilus.Utility.MaterialModifiers;
global using Nautilus.Utility.ModMessages;

/*        Other      */
global using FMOD;
global using RamuneLib;
global using static CraftData;