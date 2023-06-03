﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nautilus.Assets.Gadgets;
using Nautilus.Assets.PrefabTemplates;
using Nautilus.Assets;
using static CraftData;
using UnityEngine;
using RamuneLib;
using Ramune.RamunesOutcrops.Fabricators;

namespace Ramune.RamunesOutcrops.Items
{
    public class RadiantSeaglideMono : MonoBehaviour
    {
        public static PlayerController controller = Player.main.GetComponent<PlayerController>();

        public void Update()
        {
            if(controller.seaglideForwardMaxSpeed == 55f) return;

            controller.seaglideForwardMaxSpeed = 55f;
            controller.seaglideWaterAcceleration = 55f;
        }
    }

    public static class RadiantSeaglide
    {
        public static PrefabInfo Info;
        public static void Patch()
        {
            Info = Utilities.CreatePrefabInfo("RadiantSeaglide", "<color=#C858DF>Radiant</color> Seaglide", "SPEED: +50%\nMay need to re-equip to apply speed", Utilities.GetSprite("RadiantSeaglideSprite"), 2, 3);
            var prefab = new CustomPrefab(Info);
            var clone = new CloneTemplate(Info, TechType.Seaglide)
            {
                ModifyPrefab = go =>
                {
                    var renderer = go.FindChild("1st Person Model").FindChild("Seaglide_rig").FindChild("SeaGlide_geo").GetComponent<SkinnedMeshRenderer>();

                    renderer.materials[0].mainTexture = Utilities.GetTexture("RadiantSeaglideTexture");
                    renderer.materials[0].SetTexture("_Illum", Utilities.GetTexture("RadiantSeaglideIllumTexture"));
                    renderer.materials[0].SetTexture("_SpecTex", Utilities.GetTexture("RadiantSeaglideIllumTexture"));
                    renderer.materials[1].SetTexture("_Illum", Utilities.GetTexture("RadiantSeaglideMapIllumTexture"));
                    renderer.materials[1].SetTexture("_EmissiveTex", Utilities.GetTexture("RadiantSeaglideMapIllumTexture"));

                    go.EnsureComponent<RadiantSeaglideMono>();
                }
            };

            prefab.SetGameObject(clone);
            prefab.SetUnlock(TechType.Seaglide);
            prefab.SetPdaGroupCategory(TechGroup.Personal, TechCategory.Tools);
            prefab.AddGadget(new EquipmentGadget(prefab, EquipmentType.Hand).WithQuickSlotType(QuickSlotType.Selectable));
            prefab.SetRecipe(Utilities.CreateRecipe(1,
                new Ingredient(TechType.Seaglide, 1),
                new Ingredient(RadiantCrystal.Info.TechType, 2)))
                .WithFabricatorType(RadiantFabricator.CraftTreeType)
                .WithStepsToFabricatorTab("Tools")
                .WithCraftingTime(5.5f);
            prefab.Register();
        }
    }
}