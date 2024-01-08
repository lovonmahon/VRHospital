using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Profiling;

//Script added to patient

namespace VRH
{    
    public class SoundManager : MonoBehaviour
    {
        [SerializeField] AudioSource _pain;
        [SerializeField] AudioSource _cough;
        [SerializeField] AudioSource _hostile;
        [SerializeField] AudioSource _anxious;
        [SerializeField] AudioSource _neutral;
        [SerializeField] AudioSource _happy;
        [SerializeField] List<AudioClip> _hostileClips;
        [SerializeField] List<AudioClip> _anxiousClips;
        [SerializeField] List<AudioClip> _neutralClips;
        [SerializeField] List<AudioClip> _happyClips;

        float _coughInterval;
        float _coughReset;
        void Start()
        {
            GiveInjection.pain += Pain;
            _coughInterval = Random.Range(10.0f, 30.0f);
            _coughReset = Time.deltaTime;
        }
        void Pain()
        {
            
            _pain.Play();
        }
        void Cough()
        {
            if(_coughReset > _coughInterval)
            {
                _cough.Play();
                _coughReset = 0f;
            }
        }
        void CoughCounter()
        {
            _coughReset += Time.deltaTime;
        }
        void Update()
        {
            //Tag the cough function in profiler for analysis
            // Profiler.BeginSample("Cough");
            Cough();
            // Profiler.EndSample();
            CoughCounter();
        }
        void OnEnable()
        {
            CheckTemperament.happy += PlayExhuberantSound;
            CheckTemperament.neutral += PlayNeutralSound;
            CheckTemperament.anxious += PlayAnxiousSound;
            CheckTemperament.hostile += PlayHostileSound;
        }
        void OnDisable()
        {
            GiveInjection.pain -= Pain;
            CheckTemperament.happy -= PlayExhuberantSound;
            CheckTemperament.neutral -= PlayNeutralSound;
            CheckTemperament.anxious -= PlayAnxiousSound;
            CheckTemperament.hostile -= PlayHostileSound;
        }
        public void PlayHostileSound()
        {
            AudioClip currHostileClip = _hostileClips[Random.Range(0,_hostileClips.Count)];
            _hostile.PlayOneShot(currHostileClip);
        }
        public void PlayAnxiousSound()
        {
            AudioClip currAnxiousClip = _anxiousClips[Random.Range(0,_anxiousClips.Count)];
            _anxious.PlayOneShot(currAnxiousClip);
        }
        public void PlayNeutralSound()
        {
            AudioClip currNeutralClip = _neutralClips[Random.Range(0,_neutralClips.Count)];
            _neutral.PlayOneShot(currNeutralClip);
        }
        public void PlayExhuberantSound()
        {
            AudioClip currHappyClip = _happyClips[Random.Range(0,_happyClips.Count)];
            _happy.PlayOneShot( currHappyClip);
        }
       
    }
}
