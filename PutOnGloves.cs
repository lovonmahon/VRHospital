using System;
using UnityEngine;
using BNG;

namespace VRH
{
    public class PutOnGloves : MonoBehaviour
    {
        public static Action glovesOn;
        bool scoreAdded;
     
        [Header("Original hand models")]
        [SerializeField] GameObject _rightHand;
        [SerializeField] GameObject _leftHand;
        [Header("Gloves to put on")]
        [SerializeField] Material _gloveColor;

        void Start()
        {
            scoreAdded = false;
        }
        
        void OnTriggerExit(Collider col) 
        {
            if(col.gameObject.CompareTag("Player"))
            {
                if(glovesOn != null)
                {
                    glovesOn();
                    _rightHand.GetComponent<Renderer>().material = _gloveColor;
                    _leftHand.GetComponent<Renderer>().material = _gloveColor;

                    //Add a score to ScoreManager here
                    if(!scoreAdded) ScoreManager.currentScore += 25;
                    scoreAdded = true;
                }
            }
        }
    }
}
