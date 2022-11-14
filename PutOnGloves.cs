using System;
using UnityEngine;

namespace VRH
{
    public class PutOnGloves : MonoBehaviour
    {
        public static Action glovesOn;

        void Start()
        {

        }

        void OnTriggerEnter(Collider col) 
        {
            if(col.gameObject.CompareTag("Player"))
            {
                if(glovesOn != null)
                {
                    glovesOn();
                    //Add a score to ScoreManager here
                    ScoreManager.currentScore += 10;
                }
            }
        }
    }
}
