using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VRH
{
    public class PutOnMask : MonoBehaviour
    {
        bool scoreAdded;
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
               if(!scoreAdded) ScoreManager.currentScore += 25;
               scoreAdded = true;
           }
       }
    }
}
