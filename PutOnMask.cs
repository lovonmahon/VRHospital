using System;
using System.Collections;
using UnityEngine;

namespace VRH
{
    public class PutOnMask : MonoBehaviour
    {
        public static Action maskOn;
        bool scoreAdded;
        [SerializeField] GameObject faceMask;
        void Start()
        {
            scoreAdded = false;
        }

       void OnTriggerEnter(Collider col)
       {
           if(col.gameObject.CompareTag("Player"))
           {
                if(faceMask != null)
                {
                    if(!scoreAdded) ScoreManager.currentScore += 25;
                    if( maskOn != null) maskOn();
                    scoreAdded = true;
                    Destroy(faceMask);
                }
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
