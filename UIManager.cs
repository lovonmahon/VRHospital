using UnityEngine;

//Attach to canvas
namespace VRH
{
    public class UIManager : MonoBehaviour
    {
        void LateUpdate()
        {
            transform.LookAt(transform.position + Camera.main.transform.rotation * Vector3.forward, Camera.main.transform.rotation * Vector3.up);
        }
    }
}
