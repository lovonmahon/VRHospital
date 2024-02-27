using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class LeavePatientRoom : MonoBehaviour
{
    [SerializeField] GameObject quitImg;
    [SerializeField] int breakRoomScene;
    void OnTriggerEnter(Collider col)
    {
        //if(OVRInput.Get(OVRInput.Button.One) && col.CompareTag("Player") || col.CompareTag("Player") && Input.GetKey(KeyCode.O))//'A' button on right controller
        if(col.CompareTag("Player"))
        {
           quitImg.SetActive(true);
           StartCoroutine(QuitApplication());
        //    #if UNITY_STANDALONE
        //         Debug.Log("Quitting");
        //         Application.Quit();
        //     #endif
        //     #if UNITY_EDITOR
        //         UnityEditor.EditorApplication.isPlaying = false;
        //     #endif
        }
    }
    IEnumerator QuitApplication()
    {
        yield return new WaitForSeconds(1f);
        Application.Quit();
    }
    IEnumerator LoadStaffBreakRoom()
    {
        yield return new WaitForSeconds(0.2f);
        AsyncOperation operation = SceneManager.LoadSceneAsync(breakRoomScene);
        while(!operation.isDone)
        {
            yield return null;
        }
    }
}
