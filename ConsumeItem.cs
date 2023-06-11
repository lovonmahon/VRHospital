using UnityEngine;

namespace VRH
{
    public class ConsumeItem : MonoBehaviour
    {
        [SerializeField] GameObject obj;
        [SerializeField] GameObject newObj;
        [SerializeField] string objTag;
        void OnTriggerEnter(Collider other) 
        {
            if(other.gameObject.CompareTag(objTag))
            {
                obj.SetActive(false);
                EnableItem();
            }
        }
        public void EnableItem()
        {
            newObj.SetActive(true);
        }
        public void DisableItem()
        {
            newObj.SetActive(false);
        }
    }
}