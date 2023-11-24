// using System.Collections;
// using UnityEngine;

// public class NurseDetector : MonoBehaviour // NOTE : Does not handle multiple nurses entering/exiting
// {
//     public bool EnemyInRange => _detectedNurse != null;

//     private Nurse _detectedNurse;
    
//     private void OnTriggerEnter(Collider other)
//     {
//         if (other.GetComponent<Nurse>())
//         {
//             _detectedNurse = other.GetComponent<Nurse>(); 
//         }
//     }
    
//     private void OnTriggerExit(Collider other)
//     {
//         if (other.GetComponent<Nurse>())
//         {
//             StartCoroutine(ClearDetectedNurseAfterDelay());
//         }
//     }

//     private IEnumerator ClearDetectedNurseAfterDelay()
//     {
//         yield return new WaitForSeconds(3f);
//         _detectedNurse = null;
//     }

//     public Vector3 GetNearestNursePosition()
//     {
//         return _detectedNurse?.transform.position ?? Vector3.zero;
//     }
// }