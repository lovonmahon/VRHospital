using System;
using UnityEngine;

namespace VRH
{
    public class HandSanitizer : MonoBehaviour
    {
        public static Action useSanitizer;
        public GameObject handSanitizerSpray;
        bool scoreAdded;

        // Start is called before the first frame update
        void Start()
        {
            handSanitizerSpray.SetActive(false);
            scoreAdded = false;
        }
        // Update is called once per frame
        void Update()
        {

        }
        void OnTriggerEnter(Collider col)
        {
            if(col.gameObject.CompareTag("Player"))
            {
                handSanitizerSpray.SetActive(true);
                if(!scoreAdded) ScoreManager.currentScore += 25;
                scoreAdded = true;
                if(useSanitizer != null) useSanitizer();
            }
        }
        void OnTriggerExit(Collider col)
        {
            if(col.gameObject.CompareTag("Player"))
            {
                handSanitizerSpray.SetActive(false);
            }
        }
    }
}    
