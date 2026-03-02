using AssetsLib;
using SimpleSRmodLibrary.Creation;
using SimpleSRmodLibrary.Ids;
using SRML;
using SRML.SR;
using SRML.Utils.Enum;
using System.Collections.Generic;
using UnityEngine;

namespace EmeraldSlime
{
    [EnumHolder]
    public static class Ids
    {
        public static readonly Identifiable.Id EMERALD_SLIME;
        public static readonly Identifiable.Id EMERALD_PLORT;
        public static readonly Identifiable.Id EMERALD_GORDO;
        public static readonly Identifiable.Id RUSTY_CARROT;
        public static readonly Identifiable.Id EMERALD_BRINE;
        public static readonly Identifiable.Id OBSIDIAN_CHICK;
        public static readonly Identifiable.Id OBSIDIAN_HEN;

        public static readonly PediaDirector.Id PEDIA_EMERALD_SLIME;
        public static readonly PediaDirector.Id PEDIA_RUSTY_CARROT;
        public static readonly PediaDirector.Id PEDIA_EMERALD_BRINE;
        public static readonly PediaDirector.Id PEDIA_OBSIDIAN_CHICK;
        public static readonly PediaDirector.Id PEDIA_OBSIDIAN_HEN;
        public static readonly PediaDirector.Id PEDIA_ORE_ZONE;

        public static readonly SpawnResource.Id RUSTY_CARROT_FARM;
        public static readonly SpawnResource.Id RUSTY_CARROT_FARM_DLX;

        public static readonly ZoneDirector.Zone ORE_ZONE;
    }

    public class Main : ModEntryPoint
    {
        private readonly List<Identifiable.Id> largoIds1 = new List<Identifiable.Id>();
        private readonly List<Identifiable.Id> largoIds2 = new List<Identifiable.Id>();

        public override void PreLoad()
        {
            TranslationPatcher.AddUITranslation("t.loading.oreslimes.tip1", "Emerald Slimes love Gilded Ginger.");
            TranslationPatcher.AddUITranslation("t.loading.oreslimes.tip2", "Emerald Plorts store crystalline energy.");
            TranslationPatcher.AddUITranslation("t.loading.oreslimes.tip3", "Rusty Carrots grow best in mineral soil.");
            TranslationPatcher.AddUITranslation("t.loading.oreslimes.tip4", "Obsidian Hens are hard to see in the dark.");

            PlortCreation.PlortPreLoad(Ids.EMERALD_PLORT, "Emerald Plort", false);
            SpawnCreation.CreateSingleZoneSpawner(Ids.EMERALD_SLIME, ZoneDirector.Zone.DESERT, 0.02f);

            List<Identifiable.Id> slimesToLargoWith = new List<Identifiable.Id>
            {
                Identifiable.Id.PINK_SLIME,
                Identifiable.Id.ROCK_SLIME,
                Identifiable.Id.TABBY_SLIME,
                Identifiable.Id.PHOSPHOR_SLIME,
                Identifiable.Id.RAD_SLIME,
                Identifiable.Id.BOOM_SLIME,
                Identifiable.Id.HONEY_SLIME,
                Identifiable.Id.CRYSTAL_SLIME,
                Identifiable.Id.HUNTER_SLIME,
                Identifiable.Id.QUANTUM_SLIME,
                Identifiable.Id.DERVISH_SLIME,
                Identifiable.Id.MOSAIC_SLIME,
                Identifiable.Id.TANGLE_SLIME,
                Identifiable.Id.SABER_SLIME,
                Identifiable.Id.GOLD_SLIME,
                Identifiable.Id.LUCKY_SLIME,
                Identifiable.Id.GLITCH_SLIME,
                Identifiable.Id.QUICKSILVER_SLIME
            };

            foreach (Identifiable.Id id in slimesToLargoWith)
            {
                string baseName = id.ToString().Split('_')[0];

                largoIds1.Add(
                    IdentifiableRegistry.CreateIdentifiableId(
                        EnumPatcher.GetFirstFreeValue<Identifiable.Id>(),
                        "EMERALD_" + baseName + "_LARGO"
                    )
                );

                largoIds2.Add(
                    IdentifiableRegistry.CreateIdentifiableId(
                        EnumPatcher.GetFirstFreeValue<Identifiable.Id>(),
                        baseName + "_EMERALD_LARGO"
                    )
                );
            }
            HarmonyInstance.PatchAll();
        }

        public override void Load()
        {
        }

        public override void PostLoad()
        {
            CLS.AddToLoading.AddSplash(TextureUtils.LoadImage("LoadingScreen.png").CreateSprite());
            CLS.AddToLoading.AddIcon(TextureUtils.LoadImage("EmeraldSlime.png").CreateSprite());
            CLS.AddToLoading.AddIcon(TextureUtils.LoadImage("EmeraldGordo.png").CreateSprite());
            CLS.AddToLoading.AddLocalTipText("t.loading.oreslimes.tip1");
            CLS.AddToLoading.AddLocalTipText("t.loading.oreslimes.tip2");
            CLS.AddToLoading.AddLocalTipText("t.loading.oreslimes.tip3");
            CLS.AddToLoading.AddLocalTipText("t.loading.oreslimes.tip4");

            var emeraldPlortObj = PlortCreation.CreatePlort(
                "Emerald Plort",
                Ids.EMERALD_PLORT,
                Vacuumable.Size.NORMAL,
                new Color32(18, 95, 45, 255),
                new Color32(95, 255, 160, 255),
                new Color32(18, 95, 45, 255)
            );

            PlortCreation.PlortLoad(
                Ids.EMERALD_PLORT,
                600f,
                50f,
                emeraldPlortObj,
                TextureUtils.LoadImage("EmeraldPlort.png").CreateSprite(),
                new Color32(95, 255, 160, 255),
                true,
                true,
                false
            );

            var emeraldSlime = SlimeCreation.SlimeBaseCreate(
                Ids.EMERALD_SLIME,
                "Emerald Slime",
                "Emerald Slime",
                "Emerald Slime",
                "Emerald Slime",
                Identifiable.Id.CRYSTAL_SLIME,
                Identifiable.Id.CRYSTAL_SLIME,
                Identifiable.Id.CRYSTAL_SLIME,
                Identifiable.Id.CRYSTAL_SLIME,
                SlimeEat.FoodGroup.GINGER,
                Identifiable.Id.GINGER_VEGGIE,
                Identifiable.Id.GINGER_VEGGIE,
                Identifiable.Id.TREASURE_CHEST_TOY,
                Ids.EMERALD_PLORT,
                false,
                TextureUtils.LoadImage("EmeraldSlime.png").CreateSprite(),
                Vacuumable.Size.NORMAL,
                false,
                0f,
                0.1f,
                new Color32(120, 255, 170, 255),
                new Color32(45, 200, 120, 255),
                new Color32(10, 95, 55, 255),
                new Color32(190, 255, 220, 255),
                new Color32(8, 70, 40, 255),
                new Color32(5, 45, 28, 255),
                new Color32(2, 25, 15, 255),
                new Color32(210, 255, 230, 255),
                new Color32(20, 120, 70, 255),
                new Color32(5, 20, 10, 255),
                new Color32(170, 255, 210, 255),
                new Color32(45, 200, 120, 255),
                new Color32(10, 95, 55, 255),
                new Color32(90, 255, 170, 255)
            );

            SlimeCreation.LoadSlime(emeraldSlime);

            var emeraldGordo = GordoCreation.CreateGordoWithIcon(
                Ids.EMERALD_GORDO,
                "Emerald Gordo",
                Identifiable.Id.CRYSTAL_GORDO,
                Ids.EMERALD_SLIME,
                Ids.EMERALD_SLIME,
                "Emerald",
                ZoneDirector.Zone.DESERT,
                "Emerald Gordo",
                Ids.EMERALD_SLIME,
                30,
                TextureUtils.LoadImage("EmeraldGordo.png").CreateSprite()
            );

            SlimeCreation.LoadSlime(emeraldGordo);

            List<Identifiable.Id> slimesToLargoWith = new List<Identifiable.Id>
            {
                Identifiable.Id.PINK_SLIME,
                Identifiable.Id.ROCK_SLIME,
                Identifiable.Id.TABBY_SLIME,
                Identifiable.Id.PHOSPHOR_SLIME,
                Identifiable.Id.RAD_SLIME,
                Identifiable.Id.BOOM_SLIME,
                Identifiable.Id.HONEY_SLIME,
                Identifiable.Id.CRYSTAL_SLIME,
                Identifiable.Id.HUNTER_SLIME,
                Identifiable.Id.QUANTUM_SLIME,
                Identifiable.Id.DERVISH_SLIME,
                Identifiable.Id.MOSAIC_SLIME,
                Identifiable.Id.TANGLE_SLIME,
                Identifiable.Id.SABER_SLIME,
                Identifiable.Id.GOLD_SLIME,
                Identifiable.Id.LUCKY_SLIME,
                Identifiable.Id.GLITCH_SLIME,
                Identifiable.Id.QUICKSILVER_SLIME
            };

            int looper = 0;
            foreach (Identifiable.Id id in slimesToLargoWith)
            {
                SlimeRegistry.CraftLargo(largoIds1[looper], Ids.EMERALD_SLIME, id, SlimeRegistry.LargoProps.NONE);
                SlimeRegistry.CraftLargo(largoIds2[looper], id, Ids.EMERALD_SLIME, SlimeRegistry.LargoProps.NONE);
                EatMapCreation.AddLargo(largoIds1[looper], Ids.EMERALD_SLIME, id);
                EatMapCreation.AddLargo(largoIds2[looper], id, Ids.EMERALD_SLIME);
                looper++;
            }

            var rustyCarrotObj = CropCreation.CreateCropNoFModel(
                Ids.RUSTY_CARROT,
                "Rusty Carrot",
                Identifiable.Id.PARSNIP_VEGGIE,
                CropCreation.CreateCropMaterial(
                    Identifiable.Id.PARSNIP_VEGGIE,
                    TextureUtils.LoadImage("RustyCarrotColors.png"),
                    TextureUtils.LoadImage("RustyCarrotColors.png"),
                    TextureUtils.LoadImage("RustyCarrotColors.png"),
                    TextureUtils.LoadImage("RustyCarrotColors.png")
                ),
                new Vector3(2, 2.2f, 2),
                new Vector3(1.6f, 1.8f, 1.6f)
            );

            CropCreation.LoadCrop(Ids.RUSTY_CARROT, rustyCarrotObj, false, true, false, false);

            CropCreation.LoadFarmSetup(
                Ids.RUSTY_CARROT,
                CropCreation.CropVeggieFarmSetup(
                    SpawnResource.Id.PARSNIP_PATCH,
                    "Rusty Carrot Patch",
                    Ids.RUSTY_CARROT_FARM,
                    new GameObject[] { rustyCarrotObj },
                    new GameObject[0],
                    20,
                    10,
                    15,
                    20,
                    0f,
                    0,
                    Ids.RUSTY_CARROT,
                    Ids.RUSTY_CARROT
                ),
                CropCreation.CropVeggieFarmSetup(
                    SpawnResource.Id.PARSNIP_PATCH_DLX,
                    "Rusty Carrot Patch DLX",
                    Ids.RUSTY_CARROT_FARM_DLX,
                    new GameObject[] { rustyCarrotObj },
                    new GameObject[0],
                    30,
                    20,
                    15,
                    20,
                    0f,
                    0,
                    Ids.RUSTY_CARROT,
                    Ids.RUSTY_CARROT
                )
            );

            var emeraldBrineObj = ScienceItemCreation.CreateItem(
                "Emerald Brine",
                Ids.EMERALD_BRINE,
                Identifiable.Id.DEEP_BRINE_CRAFT,
                IdChange.GetObjectFromName<GameObject>("craftDeepBrine").transform.GetChild(0).gameObject.GetComponent<MeshRenderer>().material,
                IdChange.GetObjectFromName<GameObject>("craftDeepBrine").transform.GetChild(0).gameObject.GetComponent<MeshRenderer>().material
            );

            ScienceItemCreation.LoadItem(
                emeraldBrineObj,
                Ids.EMERALD_BRINE,
                new Color32(80, 200, 120, 255),
                TextureUtils.LoadImage("EmeraldBrine.png").CreateSprite(),
                Vacuumable.Size.NORMAL
            );

            ScienceItemCreation.ItemExtractionSet(
                Ids.EMERALD_BRINE,
                Gadget.Id.EXTRACTOR_PUMP_NOVICE,
                22f,
                ZoneDirector.Zone.REEF,
                true,
                6
            );

            var obsidianHenAndChick = HenChickCreation.CreateAHenAndChick(
                Ids.OBSIDIAN_CHICK,
                Ids.OBSIDIAN_HEN,
                Identifiable.Id.CHICK,
                Identifiable.Id.HEN,
                HenChickCreation.CreateChickMaterial(
                    Identifiable.Id.CHICK,
                    TextureUtils.LoadImage("ObsidianColors.png"),
                    TextureUtils.LoadImage("ObsidianColors.png"),
                    TextureUtils.LoadImage("ObsidianColors.png"),
                    TextureUtils.LoadImage("ObsidianColors.png")
                ),
                HenChickCreation.CreateHenMaterial(
                    Identifiable.Id.HEN,
                    TextureUtils.LoadImage("ObsidianColors.png"),
                    TextureUtils.LoadImage("ObsidianColors.png"),
                    TextureUtils.LoadImage("ObsidianColors.png"),
                    TextureUtils.LoadImage("ObsidianColors.png")
                ),
                "Obsidian Chick",
                "Obsidian Hen"
            );

            HenChickCreation.LoadHenAndChick(
                obsidianHenAndChick.Item1,
                obsidianHenAndChick.Item2,
                "Obsidian Chick",
                "Obsidian Hen",
                Ids.OBSIDIAN_CHICK,
                Ids.OBSIDIAN_HEN,
                TextureUtils.LoadImage("ObsidianChick.png").CreateSprite(),
                TextureUtils.LoadImage("ObsidianHen.png").CreateSprite(),
                Color.black,
                Color.black,
                Vacuumable.Size.NORMAL,
                Vacuumable.Size.NORMAL,
                true,
                true,
                false,
                false
            );

            SlimePediaCreation.LoadSlimePediaIcon(Ids.PEDIA_OBSIDIAN_CHICK, TextureUtils.LoadImage("ObsidianChick.png").CreateSprite());
            SlimePediaCreation.LoadSlimePediaIcon(Ids.PEDIA_OBSIDIAN_HEN, TextureUtils.LoadImage("ObsidianHen.png").CreateSprite());
            SlimePediaCreation.PreLoadSlimePediaConnection(Ids.PEDIA_OBSIDIAN_CHICK, Ids.OBSIDIAN_CHICK, PediaRegistry.PediaCategory.RESOURCES);
            SlimePediaCreation.PreLoadSlimePediaConnection(Ids.PEDIA_OBSIDIAN_HEN, Ids.OBSIDIAN_HEN, PediaRegistry.PediaCategory.RESOURCES);

            SlimePediaCreation.CreateSlimePediaForItemWithName(
                Ids.PEDIA_OBSIDIAN_CHICK,
                Ids.OBSIDIAN_CHICK,
                "Obsidian Chick",
                "A young chick with soot-dark feathers and a faint glassy sheen.",
                "Fauna",
                "Often found wandering rocky and mineral-rich environments.",
                "Obsidian Chicks are believed to develop their dark coloration from prolonged exposure to mineral-heavy soil and dust. Though they look tough and almost stone-like, they are just as fragile and skittish as any other chickadoos.",
                "Tip: Keep them safe and well fed so they can mature properly. Their dark coloring makes them easy to lose in dim areas."
            );

            SlimePediaCreation.CreateSlimePediaForItemWithName(
                Ids.PEDIA_OBSIDIAN_HEN,
                Ids.OBSIDIAN_HEN,
                "Obsidian Hen",
                "A hen with glossy black feathers that shimmer like polished volcanic glass.",
                "Fauna",
                "Commonly found in dry, rocky regions with high mineral content.",
                "The Obsidian Hen appears to be the result of generations living among mineral deposits. Their feathers reflect light with a glass-like shine, and some ranchers claim they feel slightly warm when startled — though this is likely just the sun heating their dark plumage.",
                "Tip: Provide bright enclosures. They camouflage extremely well in shadows and can wander off before you notice."
            );

            VacItemCreation.NewVacItem(
                Vacuumable.Size.NORMAL,
                rustyCarrotObj,
                Ids.RUSTY_CARROT,
                "Rusty Carrot",
                TextureUtils.LoadImage("RustyCarrot.png").CreateSprite(),
                new Color32(110, 72, 45, 255)
            );

            SlimePediaCreation.LoadSlimePediaIcon(Ids.PEDIA_EMERALD_BRINE, TextureUtils.LoadImage("EmeraldBrine.png").CreateSprite());
            SlimePediaCreation.PreLoadSlimePediaConnection(Ids.PEDIA_EMERALD_BRINE, Ids.EMERALD_BRINE, PediaRegistry.PediaCategory.SCIENCE);

            SlimePediaCreation.LoadSlimePediaIcon(Ids.PEDIA_RUSTY_CARROT, TextureUtils.LoadImage("RustyCarrot.png").CreateSprite());

            SlimePediaCreation.LoadSlimePediaIcon(Ids.PEDIA_EMERALD_SLIME, TextureUtils.LoadImage("EmeraldSlime.png").CreateSprite());
            SlimePediaCreation.PreLoadSlimePediaConnection(Ids.PEDIA_EMERALD_SLIME, Ids.EMERALD_SLIME, PediaRegistry.PediaCategory.SLIMES);
            SlimePediaCreation.PreLoadSlimePediaConnection(Ids.PEDIA_RUSTY_CARROT, Ids.RUSTY_CARROT, PediaRegistry.PediaCategory.RESOURCES);

            SlimePediaCreation.CreateSlimePediaForSlime(
                Ids.PEDIA_EMERALD_SLIME,
                "Emerald Slimes are crystalline slimes that glow softly as light passes through their gemlike bodies.",
                "Gilded Ginger",
                "Gilded Ginger",
                "Scientists believe Emerald Slimes form when a Quantum Slime remains exposed to ancient mineral deposits for long periods of time. The minerals slowly fuse with its shifting matter, stabilizing parts of its body into a semi-crystalline structure. Despite this stability, their internal energy continues to pulse and shimmer, giving them their characteristic glow. Ranchers report that Emerald Slimes are unusually calm when undisturbed, but will suddenly relocate when stressed, as if slipping through the environment rather than physically moving through it.",
                "Living near Emerald Slimes can be disorienting. Objects may occasionally appear displaced, and loose items often vanish only to reappear nearby moments later. Prolonged exposure has been known to cause dizziness in ranchers due to their intense light refraction. High walls help, but do not guarantee containment.",
                "Emerald Plorts contain tightly packed crystalline matrices capable of storing and releasing energy in small bursts. Engineers have begun experimenting with them as stabilizers in delicate devices and advanced ranch tech. However, improper handling may result in sudden energy discharge, leaving tools briefly disabled or scrambled."
            );

            SlimePediaCreation.CreateSlimePediaForItemWithName(
                Ids.PEDIA_RUSTY_CARROT,
                Ids.RUSTY_CARROT,
                "Rusty Carrot",
                "A hardy root vegetable with an iron-rich skin and a strangely metallic crunch.",
                "Resource",
                "Commonly found in dry, mineral-heavy soil where normal carrots struggle to grow.",
                "Rusty Carrots pick up trace minerals as they mature, giving them their distinctive color and taste. Ranchers say even picky slimes will eat them when they're fresh, but leaving them out too long can make them tough as scrap.",
                "Tip: Store them quickly after harvesting. The longer they sit, the more they dry out and the less appealing they become."
            );

            SlimePediaCreation.CreateSlimePediaForItemWithName(
                Ids.PEDIA_EMERALD_BRINE,
                Ids.EMERALD_BRINE,
                "Emerald Brine",
                "A luminous, mineral-rich brine shot through with emerald crystalline residue.",
                "Science Resource",
                "Collected by pumps from underground seepage where ancient deposits leach into water over time.",
                "Emerald Brine behaves like a liquid, but carries suspended crystal lattices that store trace plort-energy. Under pressure, it can briefly harden into glassy fragments before returning to a fluid state—making it valuable for stabilizers, filters, and experimental ranch tech.",
                "Handle with care: It can leave a stubborn residue as crystals rapidly form and dissolve. Keep it sealed and clean your equipment after use."
            );

            TranslationPatcher.AddPediaTranslation("t.pedia_emerald_slime", "Emerald Slime");
            TranslationPatcher.AddPediaTranslation("t.pedia_obsidian_chick", "Obsidian Chick");
            TranslationPatcher.AddPediaTranslation("t.pedia_obsidian_hen", "Obsidian Hen");

            SRCallbacks.PreSaveGameLoad += context =>
            {
                GameObject oreZone = ZoneAndCellCreation.CreateZone(
                    "zoneORE",
                    Ids.ORE_ZONE,
                    Ids.PEDIA_ORE_ZONE,
                    new Vector3(356, 2.9f, 300)
                );

                GameObject oreCell = ZoneAndCellCreation.CreateCell(
                    "cellOre_Ore",
                    oreZone,
                    false,
                    8,
                    1,
                    4,
                    12,
                    MonomiPark.SlimeRancher.Regions.RegionRegistry.RegionSetId.HOME,
                    new Vector3(356, 2.9f, 300),
                    new Vector3(356, 2.9f, 300)
                );

                (GameObject, GameObject) objectsAndSectorOreCell = ZoneAndCellCreation.CreateObjectsAndSector();
                objectsAndSectorOreCell.Item2.transform.SetParent(oreZone.transform);

                ZoneAndCellCreation.ConnectSectorAndCell(oreCell, objectsAndSectorOreCell.Item2);

                GameObject objectsOre = objectsAndSectorOreCell.Item1;

                oreZone.SetActive(true);
                oreCell.SetActive(true);
                objectsAndSectorOreCell.Item2.SetActive(true);
                objectsOre.SetActive(true);

                WorldObjectsCreation.PlaceNormalObject(
                    "zoneQUARRY/cellQuarry_Bridgeway/Sector/Main Nav/woodPlat02 (3)",
                    objectsOre,
                    0,
                    new Vector3(377, 2.7f, 300),
                    new Vector3(355.59f, 177.95f, 2.50f),
                    new Vector3(1, 1, 1)
                );

                WorldObjectsCreation.PlaceNormalObject(
                    "zoneQUARRY/cellQuarry_OverUnder/Sector/Main Nav/mtnBase02 (4)",
                    objectsOre,
                    0,
                    new Vector3(356, 2.9f, 300),
                    new Vector3(0, 173.85f, 0),
                    new Vector3(1, 1, 1)
                );

                GameObject replacer = new GameObject("replacer", typeof(WorldObjectsCreation))
                {
                    transform =
                    {
                        localPosition = new Vector3(356, 3, 299),
                        localEulerAngles = new Vector3(0f, 0f, 0f),
                        localScale = new Vector3(1, 1, 1)
                    }
                };

                replacer.GetComponent<WorldObjectsCreation>().BuildGordo(
                    Ids.EMERALD_GORDO,
                    objectsOre,
                    "EmeraldG1Ore",
                    new List<GameObject> { emeraldSlime.Item2 }
                );
            };
        }
    }
}