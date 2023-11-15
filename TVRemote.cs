using UnityEngine.Video;
using UnityEngine;

namespace VRH
{
    public class TVRemote : MonoBehaviour
    {
        //Raycast only against colliders in layer 11.  To cast against
        //all other colliders EXCEPT 11, do layerMask = ~layerMask
        int layerMask = 1<<11;
        [SerializeField] VideoPlayer _vidPlayer;
        [SerializeField] bool _isTVOn;
        [SerializeField] GameObject _remoteSensor;
        Renderer _rend;
        void Start()
        {
            _isTVOn = false;
            _rend = _remoteSensor.GetComponent<Renderer>();
        }
        void FixedUpdate()
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, 15f, layerMask))
            {
                #if UNITY_ANDROID
                    //Quest OVR controller input
                    if(OVRInput.Get(OVRInput.Button.One)) //'A' button on right controller
                    {
                        _vidPlayer.Play();
                        _isTVOn = true;
                        _rend.material.color = Color.green;
                    }
                    else if(OVRInput.Get(OVRInput.Button.Two))////'B' button on right controller
                    {
                        _vidPlayer.Stop();
                        _isTVOn = false;
                        _rend.material.color = Color.red;
                    }
                #endif
                #if UNITY_EDITOR
                    if(Input.GetKey(KeyCode.P))
                    {
                        _vidPlayer.Play();
                        _isTVOn = true;
                    }
                    else if(Input.GetKey(KeyCode.O))
                    {
                        _vidPlayer.Stop();
                        _isTVOn = false;
                    }
                    Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
                #endif
            }
        }
    }
}
