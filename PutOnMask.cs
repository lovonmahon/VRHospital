using System;
using UnityEngine;

namespace VRH
{
    public class PutOnMask : MonoBehaviour
    {
        public static Action maskOn;
        bool scoreAdded;
        [SerializeField] GameObject faceMask;
        // Start is called before the first frame update
        void Start()
        {
            scoreAdded = false;
        }

        // Update is called once per frame
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
    }
}
