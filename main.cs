using AssetsLib;
using SimpleSRmodLibrary.Creation;
using SRML;
using SRML.SR;
using SRML.Utils.Enum;
using System.Collections.Generic;
using UnityEngine;
using static SRML.SR.AchievementRegistry;

namespace KalistaSlime
{
    [EnumHolder]
    public static class Ids
    {
        public static readonly Identifiable.Id KALISTA_SLIME;
        public static readonly Identifiable.Id KALISTA_PLORT;
        public static readonly PediaDirector.Id PEDIA_KALISTA_SLIME;
    }
    public class Main : ModEntryPoint
    {
        public override void PreLoad()
        {
            PlortCreation.PlortPreLoad(Ids.KALISTA_PLORT, "Kalista Plort", false);
            SpawnCreation.CreateSingleZoneSpawner(Ids.KALISTA_SLIME, ZoneDirector.Zone.REEF, 0.1f);
            HarmonyInstance.PatchAll();
        }

        public override void Load()
        {

        }

        public override void PostLoad()
        {
            var KalistaPlort = PlortCreation.CreatePlort("Kalista Plort", Ids.KALISTA_PLORT, Vacuumable.Size.NORMAL, Color.cyan, Color.blue, Color.blue);
            PlortCreation.PlortLoad(Ids.KALISTA_PLORT, 20f, 10f, KalistaPlort, TextureUtils.LoadImage("KALI1.jpg").CreateSprite(), new Color32(230, 120, 10, 255), true, true, false);
            var KalistaSlime = SlimeCreation.SlimeBaseCreate(Ids.KALISTA_SLIME, "Kalista_Slime", "Kalista Slime", "slimeKalista", "Kalista_Slime", Identifiable.Id.BOOM_SLIME, Identifiable.Id.RAD_SLIME, Identifiable.Id.PINK_SLIME, Identifiable.Id.PINK_SLIME, SlimeEat.FoodGroup.GINGER, Identifiable.Id.GINGER_VEGGIE, Identifiable.Id.GLASS_SHARD_CRAFT, Identifiable.Id.BOMB_BALL_TOY, Ids.KALISTA_PLORT, false, TextureUtils.LoadImage("KALI2.png").CreateSprite(), Vacuumable.Size.NORMAL, true, 0f, 0.1f, Color.cyan, Color.blue, Color.green, Color.white, Color.cyan, Color.white, Color.cyan, Color.green, Color.black, Color.green, Color.green, Color.black, Color.white, Color.cyan);
            SlimeCreation.LoadSlime(KalistaSlime);
            SlimePediaCreation.LoadSlimePediaIcon(Ids.PEDIA_KALISTA_SLIME, TextureUtils.LoadImage("KALI2.png").CreateSprite());
            SlimePediaCreation.PreLoadSlimePediaConnection(Ids.PEDIA_KALISTA_SLIME, Ids.KALISTA_SLIME, PediaRegistry.PediaCategory.SLIMES);
            SlimePediaCreation.CreateSlimePediaForSlime(Ids.PEDIA_KALISTA_SLIME, "Kalista is the Spear of Vengeance.", "Gilded Ginger", "Gilded Ginger", "A specter of wrath and retribution, Kalista is the undying spirit of vengeance, an armored nightmare summoned from the Shadow Isles to hunt deceivers and traitors.The betrayed may cry out in blood to be avenged, but Kalista only answers those willing to pay with their very souls.Those who become the focus of Kalista's wrath should make their final peace, for any pact sealed with this grim hunter can only end with the cold, piercing fire of her soul-spears.", "No One, Kalista is Friendly :3", "Very valuable due to its scarcity.");
            TranslationPatcher.AddPediaTranslation(t.pedia_kalista_slime, "Kalista Slime");
        }
    }
}