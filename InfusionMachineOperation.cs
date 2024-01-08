using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VRH
{
    public class InfusionMachineOperation : MonoBehaviour
    {
        public static Action correctInfusionSetting;
        public static Action incorrectIndustionSetting;
        GameObject[] infusionCanvasButtons;

        void Start()
        {
            for(int i = 0; i < infusionCanvasButtons.Length; i++)
            {
                infusionCanvasButtons[i].SetActive(false);
            }
        }
        
        void Update()
        {
            //If the 'A' button is pressed, send haptic feedback and call correct method.
            if(OVRInput.Get(OVRInput.Button.One))
            {
                OVRInput.SetControllerVibration(1, 1, OVRInput.Controller.RTouch);
                CorrectAnswer();
                
            }
            if(OVRInput.Get(OVRInput.Button.Two))
            {
                //Report to Temperament
                OVRInput.SetControllerVibration(1, 1, OVRInput.Controller.RTouch);
                WrongEntry();
            }
            //'X' button
            if(OVRInput.Get(OVRInput.Button.Three))
            {
                //Report to Temperament
                OVRInput.SetControllerVibration(1, 1, OVRInput.Controller.RTouch);
                WrongEntry();
            }
        }
        void OnTriggerEnter(Collider other)
        {
            if(!PatientNotificationCanvas.infusionStarted && other.GetComponent<PlayerComponent>())
            {
                //TO-DO: bring up virtual oculus keyboard
                //TO-Do: enable input field so player can enter correct dosage amount.

                //Simpler way for now - enable pre-set canvas elements
                for(int i = 0; i < infusionCanvasButtons.Length; i++)
                {
                    infusionCanvasButtons[i].SetActive(true);
                }

            }
        }
        public void CorrectAnswer()
        {
            //turn on infusion machine and increase patient temperament
            //Raise the event for the correct settings to all subscribers
            correctInfusionSetting?.Invoke();
        }
        public void WrongEntry()
        {
            //turn on infusion machine, then let it break.
            //Add some effects
            //To-DO: Patient temperament depreciates and agetn will attack.(Use an event)

            //Raise the event for the incorrect settings to all subscribers
            incorrectIndustionSetting?.Invoke();
        }
    }
}
