using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindMultipleAudioListeners : MonoBehaviour
{
    void Start()
    {
        foreach(AudioListener listener in Object.FindObjectsOfType<AudioListener>())
        {
            Debug.Log($"Found {listener} in {listener.gameObject.name}");
        }
    }
    void Update()
    {
        
    }
}
