using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;

namespace VRH
{
    public class ScoreManager : MonoBehaviour
    {
        public TextMeshProUGUI scoreText;
        static int _score;
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
            Invoke("ShowScore", 6f);
        }

        // Update is called once per frame
        void Update()
        {
            scoreText.text = "Your Score " + _score.ToString() + " /100";
        }

        void ShowScore()
        {
            Debug.Log("Score is " + _score);
        }
    }
}    
