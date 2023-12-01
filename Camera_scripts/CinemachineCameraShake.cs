using Cinemachine;
using UnityEngine;

namespace VRH
{
    public class CinemachineCameraShake : MonoBehaviour
    {
        CinemachineVirtualCamera _cineCam;
        float _shakeIntensity = 1f;
        float _shakeTime = 0.2f;
        float _timer;
        CinemachineBasicMultiChannelPerlin _cbmcperlin;

        void Awake()
        {
            _cineCam = GetComponent<CinemachineVirtualCamera>();
            _cbmcperlin = _cineCam.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
            
        }
        void Start()
        {
            StopShake();//prevents the scene from starting with the camera shaking
        }
        void Update()
        {
            if(Input.GetKey(KeyCode.Z))
            {
                if(_timer > 0)//initially set to _shakeTime value
                {
                    _timer -= Time.deltaTime;
                    if(_timer <= 0)
                    {
                        StopShake();
                    }
                }
            }
        }
        public void ShakeCamera()
        {
            _cbmcperlin.m_AmplitudeGain = _shakeIntensity;
            _timer = _shakeTime;
        }
        public void StopShake()
        {
            _cbmcperlin.m_AmplitudeGain = 0f;
            _timer = 0f;
        }

    }
}