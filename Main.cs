using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using MelonLoader;
using HarmonyLib;
using ModSettings;

namespace AstridPaperdoll
{
    public class PatchClass
    {
        /*
        [HarmonyPatch(typeof(PlayerManager), "InteractiveObjectsProcessInteraction")]
        public static bool Prefix()
        {
            GameObject dollF = InterfaceManager.GetPanel<Panel_Clothing>().m_PaperDollFemale;
            //GameObject dollFHands = dollF.transform.Find("DollHands").gameObject;
            GameObject dollFHead = dollF.transform.Find("DollHead").gameObject;
            //GameObject dollFFeet = dollF.transform.Find("DollFeet").gameObject;
            //GameObject dollFBody = dollF.transform.Find("DollBody").gameObject;

            Texture2D headTex = new Texture2D(2, 2, TextureFormat.ARGB32, false);
            //Texture2D handsTex = new Texture2D(2, 2, TextureFormat.ARGB32, false);
            //Texture2D feetTex = new Texture2D(2, 2, TextureFormat.ARGB32, false);
            //Texture2D bodyTex = new Texture2D(2, 2, TextureFormat.ARGB32, false);

            ImageConversion.LoadImage(headTex, File.ReadAllBytes("Mods/PrettierAstrid/PaperDoll_Head_F.png"));
            //ImageConversion.LoadImage(handsTex, File.ReadAllBytes("Mods/characterCustomizer/paperDoll/F/hands.png"));
            //ImageConversion.LoadImage(feetTex, File.ReadAllBytes("Mods/characterCustomizer/paperDoll/F/feet.png"));
            //ImageConversion.LoadImage(bodyTex, File.ReadAllBytes("Mods/characterCustomizer/paperDoll/F/body.png"));

            dollFHead.GetComponent<UITexture>().mainTexture = headTex;
            //dollFHands.GetComponent<UITexture>().mainTexture = handsTex;
            //dollFFeet.GetComponent<UITexture>().mainTexture = feetTex;
            //dollFBody.GetComponent<UITexture>().mainTexture = bodyTex;
        
            return false;
        }
        */

        
    }

    public class Astrid_Melon : MelonMod
    {
        public override void OnApplicationLateStart()
        {
            MelonDebug.Msg($"[{Info.Name}] Version {Info.Version} loaded!");

        }

        public override void OnApplicationStart()
        {	
            Settings.Settings.OnLoad();
        }


        public static bool startLoading = false;
        public override void OnSceneWasInitialized(int level, string name) // finished loading scene
        {
            if (level >= 3)
            {
                startLoading = true;
            }
            else
            {
                startLoading = false;
            }
        }

        /*
        public override void OnSceneWasUnloaded(int level, string name) // unloading scene
        {
            if (level >= 3 && startLoading)
            {
                startLoading = false;
            }
        }
        */

        public override void OnUpdate()
        {
            if (startLoading)
            {
                UpdateAppearance();
                startLoading = false;
            }
        }

        public static void UpdateAppearance()
        {
            
            Panel_Clothing clothingpanel = InterfaceManager.GetPanel<Panel_Clothing>();
            MelonLogger.Msg("clothingpanel: " + clothingpanel == null);

            GameObject paperdollfemale = new GameObject();
            if (clothingpanel != null) paperdollfemale = clothingpanel.m_PaperDollFemale;
            MelonLogger.Msg("paperdollfemale: " + paperdollfemale == null);

            Transform dolltx = new Transform();
            if (paperdollfemale != null) dolltx = paperdollfemale.transform;
            MelonLogger.Msg("dolltx: " + dolltx == null);

            GameObject dollFHead = new GameObject();
            if (dolltx != null) dollFHead = dolltx.Find("DollHead").gameObject;
            MelonLogger.Msg("dollFHead: " + dollFHead == null);

            Texture2D headTex = new Texture2D(2, 2, TextureFormat.ARGB32, false);
            MelonLogger.Msg("headtex: " + headTex == null);

            ImageConversion.LoadImage(headTex, File.ReadAllBytes(path()));

            dollFHead.GetComponent<UITexture>().mainTexture = headTex;
        }

        static string path()
        {
            string[] paths = new string[] 
            { 
                "Mods/AstridMakeover/PaperDoll_Head_F.png",
                "Mods/AstridMakeover/PaperDoll_Head_F_NO_Eyeliner_light.png",
                "Mods/AstridMakeover/PaperDoll_Head_F_NO_Eyeliner_medium.png",
                "Mods/AstridMakeover/PaperDoll_Head_F_NO_Eyeliner_dark.png",
                "Mods/AstridMakeover/PaperDoll_Head_F_Eyeliner_light.png",
                "Mods/AstridMakeover/PaperDoll_Head_F_Eyeliner_medium.png",
                "Mods/AstridMakeover/PaperDoll_Head_F_Eyeliner_dark.png"
            };
            int index = 0;
            if (Settings.Settings.options.enabled)
            {
                index = Settings.Settings.options.lipstick+1;
                if (Settings.Settings.options.Eyeliner) index += 3;
            }
            return paths[index];
        }
        

     }

}




    

