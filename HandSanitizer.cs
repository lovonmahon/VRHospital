using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandSanitizer : MonoBehaviour
{
    public GameObject handSanitizerSpray;
    
    // Start is called before the first frame update
    void Start()
    {
        handSanitizerSpray.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.CompareTag("Player"))
        {
            handSanitizerSpray.SetActive(true);
        }
    }

    void OnTriggerExit(Collider col)
    {
        if(col.gameObject.CompareTag("Player"))
        {
            handSanitizerSpray.SetActive(false);
        }
    }
}
