using System;
using PixelCrushers.LoveHate;
using TMPro;
using UnityEngine;

namespace VRH
{
    public class CheckTemperament : MonoBehaviour
    {
        public TMP_Text _patientMoodText;
        public static Action happy;
        public static Action anxious;
        public static Action neutral;
        public static Action hostile;
        float _counter;
        float _cooldownTime = 15f;

        void Update() 
        {
            _counter += Time.deltaTime;
        }
        void OnTriggerEnter(Collider col)
        {
            if(col.gameObject.CompareTag("Player"))
            {    
                var temperament = GetComponent<FactionMember>().pad.GetTemperament();
                if(temperament == Temperament.Exuberant && _counter > _cooldownTime)
                {
                    if(happy != null) happy();
                    _counter = 0;
                    _patientMoodText.color = Color.green;
                    _patientMoodText.text = "Patient Mood: " + temperament.ToString();
                }
                if(temperament == Temperament.Anxious && _counter > _cooldownTime)
                {
                    if(anxious != null) anxious();
                    _counter = 0;
                    _patientMoodText.color = Color.yellow;
                    _patientMoodText.text = "Patient Mood: " + temperament.ToString();
                }
                if(temperament == Temperament.Neutral && _counter > _cooldownTime)
                {
                    if(neutral != null) neutral();
                    _counter = 0;
                    _patientMoodText.color = Color.gray;
                    _patientMoodText.text = "Patient Mood: " + temperament.ToString();
                }
                if(temperament == Temperament.Hostile && _counter > _cooldownTime)
                {
                    if(hostile != null) hostile();
                    _counter = 0;
                    _patientMoodText.color = Color.red;
                    _patientMoodText.text = "Patient Mood: " + temperament.ToString();
                }
            }
        }
    }
}    
