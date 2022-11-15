using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script added to patient

namespace VRH
{    
    public class SoundManager : MonoBehaviour
    {
        [SerializeField] AudioSource pain;
        [SerializeField] AudioSource cough;
        float coughInterval;
        float coughReset;
        void Start()
        {
            GiveInjection.pain += Pain;
            coughInterval = Random.Range(10.0f, 30.0f);
            coughReset = Time.deltaTime;
        }
        void Pain()
        {
            pain.Play();
        }
        void Cough()
        {
            Debug.Log(coughReset);
            if(coughReset > coughInterval)
            {
                cough.Play();
                coughReset = 0f;
            }
        }
        void CoughCounter()
        {
            coughReset += Time.deltaTime;
        }

        // Update is called once per frame
        void Update()
        {
            Cough();
            CoughCounter();
        }
    }
}
