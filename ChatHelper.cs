using System;
using System.Collections;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

namespace KeepInv.Utilities
{
    public static class ChatHelper
    {
        private static bool isFirstInit = true;
        private static Chat chat;

        //Private Reflection Methods.
        private static MethodInfo addStringSimple;
        private static MethodInfo addStringComplex;


        //Initialize class.
        public static void init()
        {
            chat = Chat.instance;

            addStringSimple = chat.GetType().GetMethod("AddString", BindingFlags.NonPublic | BindingFlags.Instance, null, new Type[] { typeof(string) }, null);
            addStringComplex = chat.GetType().GetMethod("AddString", BindingFlags.NonPublic | BindingFlags.Instance, null, new Type[] { typeof(string), typeof(string), typeof(Talker.Type) }, null);

            if (isFirstInit)
            {
                isFirstInit = false;
                ChatEvents._OnChatWindow_Close += clearInput;
            }
        }


        //Check if reflection classes need to be reinitalized.
        private static void checkReinitRequired()
        {
            if (chat == null)
                init();
        }


        //Clear the text input of the chat window.
        public static void clearInput()
        {
            Chat.instance.m_input.text = string.Empty;
        }


        //Set the text of the chat window's input field.
        public static void setInputText(string text)
        {
            checkReinitRequired();

            chat.m_input.text = text;
        }


        //Add a message to the chat window.
        public static void addString(string text)
        {
            checkReinitRequired();
            addStringSimple.Invoke(chat, new object[] {text});
        }


        //Add a message to the chat window.
        public static void addString(string username, string text, Talker.Type type)
        {
            checkReinitRequired();
            addStringComplex.Invoke(chat, new object[] {username, text, type});
        }


        //Add a message to the HUD.
        public static void addHUDMessage(string text)
        {
            checkReinitRequired();
            MessageHud.instance.ShowMessage(MessageHud.MessageType.TopLeft, text);
        }

    }
}

