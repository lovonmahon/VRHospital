using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class IntroLoader : MonoBehaviour
{
    [SerializeField] int level;
    [SerializeField] float waitTime;
    WaitForSeconds waitForSeconds;
    void Start()
    {
        waitForSeconds = new WaitForSeconds(waitTime);
        StartCoroutine(LoadVRH());
    }
    IEnumerator LoadVRH()
    {
        //wait for seconds optimization
        yield return waitForSeconds;
        // AsyncOperation operation = SceneManager.LoadSceneAsync(level);

        SceneManager.LoadScene(level);
    }
}
