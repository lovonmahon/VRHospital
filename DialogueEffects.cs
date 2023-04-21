//Implement results of dialogue called from Dialogue System

//Implement with the emotional model

//positive and negative/neutral dialogue with patient will have the
//respective impacts
using System;
using UnityEngine;

namespace VRH
{
    public class DialogueEffects : MonoBehaviour
    {
        public static Action onPositiveDialogue;
        public static Action onNegativeDialogue;

        public void ReflectPositiveDialogue()
        {
            if(onPositiveDialogue != null)
            {
                onPositiveDialogue();
            }
        }
        public void ReflectNegativeDialogue()
        {
            if(onNegativeDialogue != null)
            {
                onNegativeDialogue();
            }
        }

    }
}