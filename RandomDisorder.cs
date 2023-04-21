///Implement logic to negatively impact patient mood.  
//Ex, if the player drops the apple on floor
//or other equipment

//Also, if a lukewarm greeting is performed, patient may get upset
//Maybe implement a randomness to it to decide factor

using System;
using System.Collections.Generic;
using UnityEngine;

namespace VRH
{
    public class RandomDisorder : MonoBehaviour
    {
        public static Action randomDisorder;
        public List<GameObject> randomObjectsToDrop = new List<GameObject>();
        
      
        void OnTriggerEnter(Collider col)
        {
            
            foreach(var item in randomObjectsToDrop)
            {
                if(col.CompareTag("Floor"))
                {
                    if(randomDisorder != null)
                    {
                        randomDisorder();
                        ScoreManager.currentScore -= UnityEngine.Random.Range(15, 25);
                        Debug.Log("random Order called");
                    }
                }
            }
            //Refactor. Use tag ID instead of string value for optimization?
            // if(col.CompareTag("Floor"))
            // {
            //     if(randomDisorder != null)
            //     {
            //         randomDisorder();
            //         ScoreManager.currentScore -= UnityEngine.Random.Range(15, 25);
            //         Debug.Log("random Order called");
            //     }
            // }
        }
    }
}