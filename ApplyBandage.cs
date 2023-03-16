using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VRH
{    
    public class ApplyBandage : MonoBehaviour
    {
        public GameObject bandage;
        bool scoreAdded;

        void Start()
        {
            bandage.SetActive(false);
            scoreAdded = false;
        }

        void Update()
        {

        }
        public void PutOnBandage()
        {
            bandage.SetActive(true);
        }
        void OnTriggerEnter(Collider col)
        {
            if(col.gameObject.CompareTag("Bandage"))
            {
                PutOnBandage();
                if(!scoreAdded) ScoreManager.currentScore += 25;
            }
        }
    }    
}
