using UnityEngine;

namespace VRH
{
    public class ThrowAway : MonoBehaviour
    {
        [SerializeField]  Animator _anim;
        [SerializeField] GameObject objInHand;
        [SerializeField] GameObject newObj;
        public void ThrowAwayItem()
        {
            objInHand.transform.parent = null;
            objInHand.AddComponent<BoxCollider>();
            Rigidbody rb = objInHand.AddComponent<Rigidbody>();
            rb.useGravity = true;
            rb.AddForce(Vector3.forward * 5, ForceMode.Force);
        }

        public void DisableItem()
        {
            newObj.SetActive(false);
        }
    }
}