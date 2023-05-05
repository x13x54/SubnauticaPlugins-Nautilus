﻿
using Nautilus.Assets.PrefabTemplates;
using Nautilus.Assets;
using Nautilus.Crafting;
using static CraftData;
using RamuneLib.Utils;
using Nautilus.Assets.Gadgets;

namespace Ramune.MoreDecoys.Items
{
    public static class StasisDecoy
    {
        public static PrefabInfo info;
        public static void Patch()
        {
            // Create new RecipeData
            RecipeData recipe = Recipe.Create(3,
                new Ingredient(TechType.Titanium, 5),
                new Ingredient(TechType.WiringKit, 1),
                new Ingredient(TechType.Magnetite, 2),
                new Ingredient(TechType.Lithium, 1));

            // Create new PrefabInfo with Nautilus, gives the item a TechType and such
            PrefabInfo CyclopsStasisDecoyInfo = PrefabInfo
                .WithTechType("CyclopsDecoyStasis", "Creature stasis decoy", "A decoy that deploys a stasis field after a few seconds.")
                .WithIcon(Sprite.Get("DecoyStasis"))
                .WithSizeInInventory(new Vector2int(1, 2));
            info = CyclopsStasisDecoyInfo;

            CustomPrefab CyclopsStasisDecoy = new CustomPrefab(CyclopsStasisDecoyInfo);
            PrefabTemplate clone = new CloneTemplate(CyclopsStasisDecoyInfo, TechType.CyclopsDecoy) {};

            CyclopsStasisDecoy.SetGameObject(clone); // Set item prefab to the CyclopsDecoy clone
            CyclopsStasisDecoy.SetEquipment(EquipmentType.DecoySlot); // Set item to be used in Decoy slots
            CyclopsStasisDecoy.SetRecipe(recipe) // Set recipe with the one made earlier
                .WithFabricatorType(CraftTree.Type.Fabricator) // Set the type, e.g. workbench, moonpool
                .WithStepsToFabricatorTab("Resources", "AdvancedMaterials"); // Steps to crafting tab node, self-explanatory 

            CyclopsStasisDecoy.Register();
        }
    }
}