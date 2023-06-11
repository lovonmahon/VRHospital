using System;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitch : MonoBehaviour
{
    public static Action _lightsOff;
    public static Action _lightsOn;
    public List<Light> roomLights;
    bool _dimLights;
    Collider _playerCollider;
    void Start()
    {
        _dimLights = false;
        _playerCollider = PlayerComponent.PlayerCollider;
        
    }
    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.CompareTag("Player"))
        {
            if(!_dimLights)
            {
                TurnOffLight();
            }
            else if(_dimLights)
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
            GetComponent<Renderer>().material.color = Color.blue;
            _dimLights = false;
        }
    }
    void TurnOffLight()
    {
        foreach(var light in roomLights)
        {
            light.intensity = 0.2f;
            if(_lightsOff != null) _lightsOff();
            GetComponent<Renderer>().material.color = Color.green;
            _dimLights = true;
        }
    }
}
