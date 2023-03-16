using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;

namespace VRH
{
    public class ScoreManager : MonoBehaviour
    {
        public TextMeshProUGUI scoreText;
        public TextMeshProUGUI tempText;
        static int _score;
        static float _temp;
        public static float currentTemp
        {
            get
            {
                return _temp;
            }
            set
            {
                _temp = value;
            }
        }
        public static int currentScore
        { 
            get
            {
                return _score;
            } 
            set
            {
                _score = value;
            } 
        }
        // Start is called before the first frame update
        void Start()
        {
            //
        }
        // Update is called once per frame
        void Update()
        {
            scoreText.text = "Your Score " + _score.ToString() + " /100";
        }
        void UpdateTempValue()
        {
            tempText.text = "Patient temperature is: " + _temp.ToString() + " <sup>0</sup>F";//use <sub> </sub>to subscript
        }
        void OnEnable()
        {
            TakeTemperature.takeTemp += UpdateTempValue;
        }
        void OnDisable()
        {
            TakeTemperature.takeTemp -= UpdateTempValue;
        }
    }
}    
