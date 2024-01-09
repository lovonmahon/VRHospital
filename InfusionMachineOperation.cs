using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VRH
{
    //Attach to infusion pump
    public class InfusionMachineOperation : MonoBehaviour
    {
        public static Action correctInfusionSetting;
        public static Action incorrectInfustionSetting;
        public GameObject[] infusionScreenCanvas;
        public GameObject infusionPumpPowerOnCanvas;

        void Start()
        {
            for(int i = 0; i < infusionScreenCanvas.Length; i++)
            {
                infusionScreenCanvas[i].SetActive(false);
            }
            infusionPumpPowerOnCanvas.SetActive(false);
        }
        
        void Update()
        {
            #region Android input
            #if UNITY_ANDROID
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
            #endif
            #endregion
            #region Unity editor input
            #if UNITY_EDITOR
                if(Input.GetKey(KeyCode.Alpha1) && PatientNotificationCanvas.nearInfusionMachine)
                {
                    CorrectAnswer();
                }
                if(Input.GetKey(KeyCode.Alpha2) && PatientNotificationCanvas.nearInfusionMachine)
                {
                    //Report to Temperament
                    WrongEntry();
                }
                //'X' button
                if(Input.GetKey(KeyCode.Alpha3) && PatientNotificationCanvas.nearInfusionMachine)
                {
                    //Report to Temperament
                    WrongEntry();
                }
            #endif
            #endregion
        }
        public void CorrectAnswer()
        {
            //turn on infusion machine and increase patient temperament
            //Raise the event for the correct settings to all subscribers
            correctInfusionSetting?.Invoke();
            infusionPumpPowerOnCanvas.SetActive(true);
            PatientNotificationCanvas.infusionStarted = true;
        }
        public void WrongEntry()
        {
            //turn on infusion machine, then let it break.
            //Add some effects
            //To-DO: Patient temperament depreciates and agetn will attack.(Use an event)

            //Raise the event for the incorrect settings to all subscribers
            incorrectInfustionSetting?.Invoke();
            infusionPumpPowerOnCanvas.SetActive(true);
            PatientNotificationCanvas.infusionStarted = true;
        }
    }
}
