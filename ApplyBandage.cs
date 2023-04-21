using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VRH
{    
    public class ApplyBandage : MonoBehaviour
    {
        public static Action bandageOn;
        public GameObject bandage;
        bool scoreAdded;

        void Start()
        {
            bandage.SetActive(false);
            scoreAdded = false;
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
                if(bandageOn != null) bandageOn();
                if(!scoreAdded) ScoreManager.currentScore += 25;
            }
        }
        void OnTriggerExit(Collider col)
        {
            if(col.gameObject.CompareTag("Player"))
            {
                StartCoroutine("DestroyThisTrigger", 2f);
            }
        }
        IEnumerator DestroyThisTrigger()
        {
            yield return null;
            Destroy(this.gameObject);
        }
    }    
}
