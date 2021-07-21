using KeepInv.Utilities;
using System.Collections.Generic;

namespace KeepInv
{
    class ChatHistory
    {
        private const int maxHistory = 10;
        private static int chatHistoryIndex = 0;
        public static List<string> chatHistory { get; private set; }

        //Initialize the class on plugin start.
        public static void init()
        {
            chatHistory = new List<string>();
            ChatEvents._OnChatWindow_Open += chatOpen;
            ChatEvents._OnChatInput += onChat;
        }

        //Log the chat to the history list when a player talks or uses a command.
        public static void logChat(string chat)
        {
            if (chatHistory.Count == maxHistory)
                chatHistory.RemoveAt(0);

            chatHistory.Add(chat);

        }


        //Go back and display older chat history when the player presses the up button in the chat window.
        public static void pageHistoryUp()
        {
            Chat chat = Chat.instance;

            if (!chat.IsChatDialogWindowVisible() || !chat.m_input.isFocused)
                return;

            chatHistoryIndex--;

            displayChatHistory();
        }


        //Go forward and display newer chat history when the player presses the down button in the chat window.
        public static void pageHistoryDown()
        {
            Chat chat = Chat.instance;

            if (!chat.IsChatDialogWindowVisible() || !chat.m_input.isFocused)
                return;

            chatHistoryIndex++;

            displayChatHistory();
        }


        //Called when the chat window is opened and sets the chat history cursor back to default.
        private static void chatOpen()
        {
            resetChatHistoryIndex();
        }


        //Called when the player submits new text and resets the chat history cursor.
        private static void onChat()
        {
            chatHistoryIndex = chatHistory.Count + 1;
        }


        //Reset the chat history cursor.
        private static void resetChatHistoryIndex()
        {
            chatHistoryIndex = chatHistory.Count;
        }


        //Display the chat history to the chat window and update chat history cursor if needed.
        private static void displayChatHistory()
        {
            if(chatHistoryIndex >= 0 && chatHistoryIndex < chatHistory.Count)
            {
                ChatHelper.setInputText(chatHistory[chatHistoryIndex]);
            }
            else if(chatHistoryIndex >= chatHistory.Count)
            {
                resetChatHistoryIndex();
                ChatHelper.setInputText(string.Empty);
            }
            else
            {
                chatHistoryIndex = 0;
            }
        }
    }
}
