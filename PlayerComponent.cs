using System.Collections.Generic;
using UnityEngine;
public class PlayerComponent : MonoBehaviour
{
    public static PlayerComponent Instance;
    public static Collider PlayerCollider;

    void Awake()
    {
        if(Instance == null)
        { 
            Instance = this;
        }
        else
        {
            Destroy(Instance);
        }
        PlayerCollider = GetComponent<Collider>();
    }
}