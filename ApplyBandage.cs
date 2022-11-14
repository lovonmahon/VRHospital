using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VRH
{    
    public class ApplyBandage : MonoBehaviour
    {
        public GameObject bandage;
        // Start is called before the first frame update
        void Start()
        {
            bandage.SetActive(false);
        }

        // Update is called once per frame
        void Update()
        {

        }

        public void PutOnBandage()
        {
            bandage.SetActive(true);
        }

        void OnTriggerEnter(Collider col)
        {
            if(col.gameObject.CompareTag("Bandage"))
            {
                PutOnBandage();
            }
        }
    }    
}
