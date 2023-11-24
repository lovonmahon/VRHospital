using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderAreasVisualization : MonoBehaviour
{
    // Start is called before the first frame update
    void OnDrawGizmos() 
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(transform.position, 0.3f);

    }
}
