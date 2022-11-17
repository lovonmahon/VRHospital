using System;
using UnityEngine;
using UnityEngine.UI;

///<summary>
///attach to needle GO
///</summary>
namespace VRH
{
    public class GiveInjection : MonoBehaviour
    {
        public static Action pain;
        public GameObject bloodFX;
        [SerializeField] GameObject ui;
        bool scoreAdded;

        void Start()
        {
            bloodFX.SetActive(false);
            scoreAdded = false;
        }
     
        void Update()
        {

        }
        void OnTriggerEnter(Collider col)
        {
            if(col.gameObject.CompareTag("PatientArm"))
            {
                bloodFX.SetActive(true);
                if(pain != null)
                {
                    pain();
                }
                if(!scoreAdded) ScoreManager.currentScore += 5;
                scoreAdded = true;
            }
            if(col.gameObject.CompareTag("Player"))
            {
                ui.SetActive(false);
            }
        }
        void OnTriggerExit(Collider col)
        {
            if(col.gameObject.CompareTag("PatientArm"))
            {
                bloodFX.SetActive(false);
            }
            // if(col.gameObject.CompareTag("Player"))
            // {
            //     ui.SetActive(true);
            //     //add code to always display ui at a vector3.up offset
            // }
        }
    }
}    
