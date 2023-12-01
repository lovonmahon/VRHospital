using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

//Attach to XR rig
public class ScreenBloodController : MonoBehaviour
{
    Canvas _canvas;
    public Image Img;
    [SerializeField] float _duration;

    void Start()
    {
        _canvas = FindObjectOfType<Canvas>();
        if(_canvas == null)
        {
            Debug.LogError($"No {_canvas} found");
        }
    }

    void Update()
    {
        // if(Input.GetKey(KeyCode.F))
        // {
        //     AggroScreenEffectOn();
        // }
        // else
        // {
        //     AggroScreenEffectOff();
        // }
    }

    private void AggroScreenEffectOff()
    {
        Color c = Img.color;
        c.a = 0f;
        Img.color = c;
    }

    public void AggroScreenEffectOn()
    {
        Debug.Log("Screen effect On");
        float time = 1f;
        //Store temporary color for modifying
        Color c = Img.color;
        //Change alpha value
        c.a = 1f;
        //Assign back to the final color property
        Img.color = c;
        time -= Time.deltaTime;
        if(time <= 0)
        {
            AggroScreenEffectOff();
        }
    }
}
