using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace KeepInv
{
    class ChatEvents
    {

        public static event Action _OnChatWindow_Open;
        public static event Action _OnChatWindow_Close;
        public static event Action _OnChatInput;
        public static event Action _OnInputLoseFocus;


        public static void handleChatWindowActiveState(Chat __instance, bool __state)
        {

            if (__instance.IsChatDialogWindowVisible() != __state)
            {
                if (__instance.IsChatDialogWindowVisible())
                    _OnChatWindow_Open?.Invoke();
                else
                    _OnChatWindow_Close?.Invoke();
            }

        }

        public static void handleChatInputState()
        {
            _OnChatInput?.Invoke();
        }

        public static void handleChatInputLoseFocus()
        {
            _OnInputLoseFocus?.Invoke();
        }
    }
}
