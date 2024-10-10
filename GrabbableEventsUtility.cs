using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VRH
{    
    public class GrabbableEventsUtility : MonoBehaviour
    {
        Animator _anim;
        [SerializeField] string animatorTrigger;

        void Start()
        {
            _anim = GetComponent<Animator>();
        }
        public void OnPatientReady()
        {
            _anim.SetTrigger(animatorTrigger);
        }
    }
}
