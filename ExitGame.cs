using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void ExitScene()
    {
        //Load main screen.
        // SceneManager.LoadScene(0);
        Debug.Log("Exiting...");
    }
    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.CompareTag("Player"))
        {
            // Time.timeScale = 0f; //pause
            ExitScene();
        }
    }
}
