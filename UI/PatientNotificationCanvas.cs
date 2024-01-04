using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VRH
{    
    public class PatientNotificationCanvas : MonoBehaviour
    {
        public GameObject infusionMachineCanvas;
        public static bool infusionStarted;
        public GameObject[] buttonsUI;
        void Start()
        {
            for(int i = 0; i < buttonsUI.Length; i++)
            {
                buttonsUI[i].SetActive(false);
            }
        }
        void OnTriggerEnter(Collider other)
        {
            if(other.GetComponent<PlayerComponent>() && !infusionStarted)
            {
                infusionMachineCanvas.SetActive(true);
            }
        }
        public static void EnableUIDosageOptions()
        {
            //Initialize a new instance of the class to reference its non-static buttonsUI field
            PatientNotificationCanvas pc = new PatientNotificationCanvas();
            for(int i = 0; i < pc.buttonsUI.Length; i++)
            {
                pc.buttonsUI[i].SetActive(true);
            }
        }
    }
}
