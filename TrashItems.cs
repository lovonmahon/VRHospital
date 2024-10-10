using System;
using UnityEngine;
using BNG;

namespace VRH
{
    public class TrashItems : MonoBehaviour
    {
        public static Action onBioHazDisposal;
        ///<summary>
        ///Tooltip for function example
        ///</summary>
        ///<param name="other">Tooltip for parameter</param>
        ///<returns></returns> 

    void OnTriggerEnter(Collider other)
        {
            if(other.gameObject.CompareTag("Needle") || other.gameObject.CompareTag("Bandage"))
            {
                onBioHazDisposal?.Invoke();
                ScoreManager.currentScore += 50;
                if(!other.GetComponent<Grabbable>().BeingHeld)
                {
                    Destroy(other.gameObject);
                }
            }
        }
    }
}
