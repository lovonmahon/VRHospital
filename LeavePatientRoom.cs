using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LeavePatientRoom : MonoBehaviour
{
    void OnTriggerEnter(Collider col)
    {
        //if(OVRInput.Get(OVRInput.Button.One) && col.CompareTag("Player") || col.CompareTag("Player") && Input.GetKey(KeyCode.O))//'A' button on right controller
        if(col.CompareTag("Player"))
        {
           #if UNITY_STANDALONE
                Debug.Log("Quitting");
                Application.Quit();
            #endif
            #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
            #endif
        
        }
    }
}
