using System;
using UnityEngine;

///<summary>
///attach to needle GO
///</summary>
namespace VRH
{
    public class GiveInjection : MonoBehaviour
    {
        public static Action pain;
        public GameObject bloodFX;

        void Start()
        {
            bloodFX.SetActive(false);
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
                ScoreManager.currentScore += 5;
            }
        }
        void OnTriggerExit(Collider col)
        {
            if(col.gameObject.CompareTag("PatientArm"))
            {
                bloodFX.SetActive(false);
            }
        }
    }
}    
