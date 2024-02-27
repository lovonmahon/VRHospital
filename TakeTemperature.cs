using System;
using UnityEngine;

namespace VRH
{
    public class TakeTemperature : MonoBehaviour
    {
        public static Action takeTemp;
        public AudioClip clip;
        void OnTriggerEnter(Collider col)
        {
            if(col.gameObject.CompareTag("mouth"))
            {
                // GetComponent<AudioSource>().PlayOneShot(clip, 0.5f);
                if(takeTemp != null) takeTemp();
                ScoreManager.currentTemp = UnityEngine.Random.Range(97.2f, 99.9f);
                ScoreManager.currentScore -= UnityEngine.Random.Range(10, 25);
            }
        }
    }
}

