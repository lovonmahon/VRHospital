using UnityEngine.AI;
using UnityEngine;

namespace VRH
{
    public class AIReferences : MonoBehaviour
    {
        public Animator anim;
        public NavMeshAgent agent;
        void Awake()
        {
            anim = GetComponent<Animator>();
            agent = GetComponent<NavMeshAgent>();
        }
    }
}