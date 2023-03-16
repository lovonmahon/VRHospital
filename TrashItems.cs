using UnityEngine;
using BNG;

namespace VRH
{
    public class TrashItems : MonoBehaviour
    {
        
        ///<summary>
        ///Tooltip for function example
        ///</summary>
        ///<param name="other">Tooltip for paremeter</param>
        ///<returns></returns> 

    void OnTriggerEnter(Collider other)
        {
            if(other.gameObject.CompareTag("Needle") || other.gameObject.CompareTag("Bandage"))
            {
                if(!other.GetComponent<Grabbable>().BeingHeld)
                {
                    Destroy(other.gameObject);
                }
            }
        }
    }
}
