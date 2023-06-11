/*using System;
using System.Collections;
using System.Collections.Generic;
using OpenAI_API;
using OpenAI_API.Chat;
using OpenAI_API.Models;
using TMPro;
using UnityEngine.UI;
using UnityEngine;

namespace VRH
{
    #region 
    public class OpenAiController : MonoBehaviour
    {
        public TMP_Text txtField;
        public TMP_InputField inptField;
        public Button subBtn;
        OpenAIAPI api;
        List<ChatMessage> messages;
        #endregion

        void Start() 
        {
            api = new OpenAIAPI(Environment.GetEnvironmentVariable("OPENAI_API_KEY", EnvironmentVariableTarget.User));
            //Maybe start conversation on trigger enter or raycast
            StartConversation();
            subBtn.onClick.AddListener(() => GetResponseMessage());    
        }

        void StartConversation()
        {
            messages = new List<ChatMessage>
            {
                new ChatMessage(ChatMessageRole.System, "Here is your medical database.  What information do yo uneed?")
            };
            inptField.text = "";
            string startStr = "Search for more information relating to the patient's ailment if needed";
            txtField.text = startStr;
        }
        async void GetResponseMessage()
        {
            if(inptField.text.Length < 1) return;
            //Submit button disabled
            subBtn.enabled = false;

            //populate end user message from input 
            ChatMessage userMsg = new ChatMessage();
            userMsg.Role = ChatMessageRole.User;
            userMsg.Content = inptField.text;
            if(userMsg.Content.Length > 100)
            {
                //Limit words to 100 characters
                userMsg.Content = userMsg.Content.Substring(0, 100);
            }
            //Add user message to list
            messages.Add(userMsg);
            //update text field with the user's message
            txtField.text = string.Format("You: {0}", userMsg.Content);
            //clear input field
            inptField.text = "";

            //send the chat to OpenAI to parse and return a response
            var chatResult = await api.Chat.CreateChatCompletionAsync(new ChatRequest()
            {
                Model = Model.ChatGPTTurbo,
                Temperature = 0.9,
                MaxTokens = 50,
                Messages = messages
            });

            ChatMessage responseMessage = new ChatMessage();
            responseMessage.Role = chatResult.Choices[0].Message.Role;
            responseMessage.Content = chatResult.Choices[0].Message.Content;

            //Add the response to the list of messages
            messages.Add(responseMessage);
            //Update the text field with response
            txtField.text = string.Format("You: {0}\n\nMedical Assistant: {1}", userMsg.Content, responseMessage.Content);
            //Re-enabling the submit button
            subBtn.enabled = true;
        }

    }
}
*/