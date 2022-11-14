using UnityEngine;

namespace VRH
{
    public class GlovesAlert : MonoBehaviour
    {
        void OnEnable() 
        {
            PutOnGloves.glovesOn += Message;
        }

        void Message()
        {
            Debug.Log("Gloves were put on");
        }

        void OnDisable() 
        {
            PutOnGloves.glovesOn -= Message;
        }

        void Update()
        {
            //
        }
    }    
}
