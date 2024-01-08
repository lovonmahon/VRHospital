using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using BNG;

namespace VRH
{    
    public class MakeAllAvailable : MonoBehaviour
    {
        //Prevent the player from performing activities before
        //...gloves are adorned
        [SerializeField] Grabbable[] gb;

        void Start()
        {
            for(int i = 0; i < gb.Length; i++)
            {
                Grabbable grab = gb[i].gameObject.GetComponent<Grabbable>();
                grab.enabled = false;
            }
            PutOnGloves.glovesOn += MakeAllInteractable;
        }
        void MakeAllInteractable()
        {
            for(int i = 0; i < gb.Length; i++)
            {
                Grabbable grab = gb[i].gameObject.GetComponent<Grabbable>();
                grab.enabled = true;
            }
        }
        
        void Update()
        {

        }
    }
}
