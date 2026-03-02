using AssetsLib;
using HarmonyLib;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace EmeraldSlime
{
    [HarmonyPatch(typeof(LoadingUI))]
    class LoadingUIPatch
    {
        private static bool applied = false;

        [HarmonyPostfix]
        [HarmonyPatch("Awake")]
        static void AwakePatch(LoadingUI __instance)
        {
            if (applied) return;
            applied = true;

            try
            {
                ReplaceIcons(__instance);
                ReplaceTips(__instance);
                ReplaceBackground(__instance);
            }
            catch (System.Exception e)
            {
                Debug.LogError("[OreSlimes] LoadingUI patch failed: " + e);
            }
        }

        static void ReplaceIcons(LoadingUI ui)
        {
            List<Sprite> icons = new List<Sprite>
            {
                TextureUtils.LoadImage("EmeraldSlime.png").CreateSprite(),
                TextureUtils.LoadImage("EmeraldGordo.png").CreateSprite()
            };

            ui.bouncyIcons = icons.ToArray();
        }

        static void ReplaceTips(LoadingUI ui)
        {
            string[] tips =
            {
                "Emerald Slimes love Gilded Ginger.",
                "Emerald Plorts store crystalline energy.",
                "Rusty Carrots grow best in mineral soil.",
                "Obsidian Hens are hard to see in the dark."
            };

            var field = typeof(LoadingUI).GetField("tipText",
                BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);

            if (field == null) return;

            var tmp = field.GetValue(ui) as TMP_Text;
            if (tmp == null) return;

            ui.StartCoroutine(CycleTips(tmp, tips));
        }

        static IEnumerator CycleTips(TMP_Text text, string[] tips)
        {
            int i = 0;

            while (true)
            {
                text.text = tips[i];
                i++;
                if (i >= tips.Length) i = 0;

                yield return new WaitForSeconds(6f);
            }
        }

        static void ReplaceBackground(LoadingUI ui)
        {
            Sprite splash = TextureUtils.LoadImage("LoadingScreen.png").CreateSprite();

            var fields = typeof(LoadingUI).GetFields(
                BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);

            foreach (var f in fields)
            {
                if (f.FieldType != typeof(Image))
                    continue;

                if (f.Name.ToLower().Contains("bouncy"))
                    continue;

                var img = f.GetValue(ui) as Image;
                if (img == null)
                    continue;

                img.sprite = splash;
            }
        }
    }
}