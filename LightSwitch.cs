using System;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitch : MonoBehaviour
{
    public static Action _lightsOff;
    public static Action _lightsOn;
    public List<Light> roomLights;
    bool _dimLights;
    void Start()
    {
        _dimLights = false;
    }
    void OnTriggerEnter(Collider col)
    {
        if(col.CompareTag("Player"))
        {
            if(!_dimLights)
            {
                TurnOffLight();
            }
            if(_dimLights)
            {
                TurnOnLight();
            }
        }
    }
    void TurnOnLight()
    {
        foreach(var light in roomLights)
        {
            light.intensity = 1f;
            if(_lightsOn != null) _lightsOn();
        }
    }
    void TurnOffLight()
    {
        foreach(var light in roomLights)
        {
            light.intensity = 0.2f;
            if(_lightsOff != null) _lightsOff();
        }
    }
  
}
