using System;
using System.Collections;
using UnityEngine;
using BNG;

namespace VRH
{
    public class PutOnGloves : MonoBehaviour
    {
        public static Action glovesOn;
        bool scoreAdded;
        bool hasGloves;
     
        [Header("Original hand models")]
        [SerializeField] GameObject _rightHand;
        [SerializeField] GameObject _leftHand;
        [Header("Gloves to put on")]
        [SerializeField] Material _gloveColor;

        void Start()
        {
            scoreAdded = false;
            hasGloves = false;

            hasGloves = true;
            glovesOn?.Invoke();
            if(!scoreAdded)
            {
                ScoreManager.currentScore += 25;
                scoreAdded = true;
            } 
        }
        
        void OnTriggerEnter(Collider col) 
        {
            if(col.gameObject.CompareTag("Player") && !hasGloves)
            {
                _rightHand.GetComponent<Renderer>().material = _gloveColor;
                _leftHand.GetComponent<Renderer>().material = _gloveColor;
                hasGloves = true;
                glovesOn?.Invoke();
                if(!scoreAdded)
                {
                    ScoreManager.currentScore += 25;
                    scoreAdded = true;
                } 
            }
        }
        // void OnTriggerExit(Collider col)
        // {
        //     if(col.gameObject.CompareTag("Player")) StartCoroutine("DestroyThisTrigger", 2f);
        // }
        // IEnumerator DestroyThisTrigger()
        // {
        //     yield return new WaitForSeconds(0.2f);
        //     Destroy(this.gameObject);
        // }
    }
}
