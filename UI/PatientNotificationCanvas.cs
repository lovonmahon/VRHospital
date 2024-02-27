using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VRH
{    
    //Attach to Infusion Machine
    public class PatientNotificationCanvas : MonoBehaviour
    {
        public GameObject infusionMachineCanvas;
        public static bool infusionStarted;
        public static bool nearInfusionMachine;
        public GameObject[] buttonsUI;
        void Start()
        {
            infusionStarted = false;
            nearInfusionMachine = false;
            for(int i = 0; i < buttonsUI.Length; i++)
            {
                buttonsUI[i].SetActive(false);
            }
        }
        void OnTriggerEnter(Collider other)
        {
            if(other.GetComponent<PlayerComponent>() /*&& !infusionStarted*/)
            {
                for(int i = 0; i < buttonsUI.Length; i++)
                {
                    buttonsUI[i].SetActive(true);
                }
                nearInfusionMachine = true;
            }
            
        }
        void OnTriggerExit(Collider other)
        {
            if(other.GetComponent<PlayerComponent>() /*&& !infusionStarted*/)
            {
                for(int i = 0; i < buttonsUI.Length; i++)
                {
                    buttonsUI[i].SetActive(false);
                }
                nearInfusionMachine = false;
            }
        }
    }
}
