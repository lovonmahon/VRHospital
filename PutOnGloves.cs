using System;
using UnityEngine;

namespace VRH
{
    public class PutOnGloves : MonoBehaviour
    {
        public static Action glovesOn;
        bool scoreAdded;

        void Start()
        {
            scoreAdded = false;
        }

        void OnTriggerEnter(Collider col) 
        {
            if(col.gameObject.CompareTag("Player"))
            {
                if(glovesOn != null)
                {
                    glovesOn();
                    //Add a score to ScoreManager here
                    if(!scoreAdded) ScoreManager.currentScore += 10;
                    scoreAdded = true;
                }
            }
        }
    }
}
