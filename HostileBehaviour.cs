using System.Threading.Tasks;
using UnityEngine;

namespace VRH
{
    public class HostileBehaviour : MonoBehaviour
    {
        [SerializeField] Animator _anim;
        [SerializeField] AudioClip _clip;
        [SerializeField] AudioSource _source;
        void OnEnable()
        {
            CheckTemperament.anxious += Annoyance;
            CheckTemperament.hostile += Hostility;
        }
        void OnDisable() 
        {
            CheckTemperament.anxious -= Annoyance;
            CheckTemperament.hostile -= Hostility;
        }

        void Annoyance()
        {
            _anim.SetTrigger("Annoyed");
            PlayAngrySound();
        }
        void Hostility()
        {
            _anim.SetTrigger("Hostile");
            HostileSound();
        }
        async void PlayAngrySound()
        {
            await Task.Delay(4000);
            _source.PlayOneShot(_clip);
        }
        void HostileSound()
        {
            _source.PlayOneShot(_clip);
        }
    }
}