using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VRH
{    
    public class SoundManager : MonoBehaviour
    {
        [SerializeField] AudioSource pain;
        [SerializeField] AudioSource cough;
        void Start()
        {
            GiveInjection.pain += Pain;
        }
        void Pain()
        {
            pain.Play();
        }
        void Cough()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
