using BepInEx;
using HarmonyLib;
using KeepInv.Commands;
using KeepInv.Utilities;
using System.Collections;
using System.IO;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

namespace KeepInv
{

    //Todo add tab auto complete for commands and player names.

    [BepInPlugin("club.jeffs.KeepInv", "KeepInv", "1.0.0")]
    [BepInProcess("valheim.exe")]
    public class KeepInv : BaseUnityPlugin
    {
        public static KeepInv instance;

        private readonly Harmony harmony = new Harmony("club.jeffs.KeepInv");
        
        public static string[] swears;
        public static System.Random rand = new System.Random();

        void Awake()
        {
            instance = this;
            ChatHelper.init();
            CmdHandler.init();
            ChatHistory.init();
            getSwears();
            harmony.PatchAll();
        }

        void OnDestroy()
        {
            harmony.UnpatchSelf();
        }

        public static void getSwears()
        {

            swears = File.ReadAllLines(@"B:\Steam\steamapps\common\Valheim\BepInEx\hehe.txt");

        }

        public static IEnumerator MoveTextEnd_NextFrame(InputField f)
        {
            yield return 0; // Skip the first frame in which this is called.
            f.MoveTextEnd(false); // Do this during the next frame.
        }

        public static IEnumerator swearXtimes(int times)
        {
            for(int i = 0; i < times; i++)
            {
                if(i != 0)
                    yield return new WaitForSeconds(0.8f);

                Chat.instance.SendText(Talker.Type.Shout, swears[rand.Next(0, swears.Length - 1)]);
            }
        }


        public static bool isLocalPlayer(Player __instance)
        {
            if (Player.m_localPlayer == null || Player.m_localPlayer.GetInstanceID() != __instance.GetInstanceID())
                return false;

            return true;
        }


        [HarmonyPatch]
        public class SwearLikeAutistOnDeath
        {
            [HarmonyPatch(typeof(Player), "OnDeath")]
            static void Prefix(ref Player __instance)
            {

                if (!isLocalPlayer(__instance))
                    return;

                Back_Cmd.updateLastLocation();
                __instance.StartCoroutine(swearXtimes(10));
            }
        }

        [HarmonyPatch]
        public class Patch_Chat_Cmds
        {
            [HarmonyPatch(typeof(Chat), "InputText")]
            static bool Prefix(ref Chat __instance)
            {
                ChatEvents.handleChatInputState();
                ChatHistory.logChat(__instance.m_input.text);
                return CmdHandler.handle(__instance.m_input.text);
            }
        }

        [HarmonyPatch]
        public class Patch_Chat_Update_Prefix
        {
            [HarmonyPatch(typeof(Chat), "Update")]
            static void Prefix(ref Chat __instance, ref float ___m_hideTimer, ref RectTransform ___m_chatWindow, ref InputField ___m_input, out bool __state)
            {
                __state = __instance.IsChatDialogWindowVisible();

                if (Input.GetKeyDown(KeyCode.Slash) && (Object)Player.m_localPlayer != (Object)null && (!___m_chatWindow.gameObject.activeSelf && !Console.IsVisible() && !TextInput.IsVisible()) && (!Minimap.InTextInput() && !Menu.IsVisible()))
                {

                    ___m_input.text = "/";

                    ___m_hideTimer = 0.0f;
                    ___m_chatWindow.gameObject.SetActive(true);
                    ___m_input.gameObject.SetActive(true);
                    ___m_input.ActivateInputField();
                    ___m_input.Select();
                    __instance.StartCoroutine(MoveTextEnd_NextFrame(___m_input));
                }

                else if(Input.GetKeyDown(KeyCode.UpArrow) && (Object)Player.m_localPlayer != (Object)null && ___m_chatWindow.gameObject.activeSelf && ___m_input.isFocused)
                {
                    ChatHistory.pageHistoryUp();
                }

                else if(Input.GetKeyDown(KeyCode.DownArrow) && (Object)Player.m_localPlayer != (Object)null && ___m_chatWindow.gameObject.activeSelf && ___m_input.isFocused)
                {
                    ChatHistory.pageHistoryDown();
                }
            }

            [HarmonyPatch(typeof(Chat), "Update")]
            static void Postfix(ref Chat __instance, bool __state)
            {
                ChatEvents.handleChatWindowActiveState(__instance, __state);
            }
        }
    }
}
