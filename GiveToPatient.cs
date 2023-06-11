using System;
using System.Collections.Generic;
using UnityEngine;

public class GiveToPatient : MonoBehaviour
{
    public static Action onHappy;
    [SerializeField] Animator _anim;
    void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.CompareTag("Apple"))
        {
            _anim.SetTrigger("Eat");
            if(onHappy != null) onHappy();
        }
        if(col.gameObject.CompareTag("Tea"))
        {
            _anim.SetTrigger("Drink");
            if(onHappy != null) onHappy();
        }
        if(col.gameObject.CompareTag("Remote"))
        {
            _anim.SetTrigger("WatchTV");
            if(onHappy != null) onHappy(); 
        }
    }
}
