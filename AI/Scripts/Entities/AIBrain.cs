using System;
using UnityEngine.AI;
using UnityEngine;

namespace VRH
{    
    // [RequireComponent(typeof(Animator))]
    // [RequireComponent(typeof(NavMeshAgent))]
    public class AIBrain : MonoBehaviour
    {
        StateMachine _stateMachine;
        WanderAreasParent _wanderParent;
        AIReferences _aiRef;
        NavMeshAgent _agent;
        Animator _anim;
        
        void Start()
        {
            _stateMachine = new StateMachine();
            // nurses = GetComponent<NurseReferences>();
            _wanderParent = FindObjectOfType<WanderAreasParent>();
            _aiRef = GetComponent<AIReferences>();
            _agent = GetComponent<NavMeshAgent>();
            _anim = GetComponent<Animator>();
            

            //STATES
            var wander = new WanderHospitalRoom(_aiRef, _wanderParent);
            
            //TRANSITIONS

            //START STATE
            _stateMachine.SetState(wander);

            //FUNCTIONS & CONDITIONS
            void At(IState from, IState to, Func<bool> condition) => _stateMachine.AddTransition(from, to, condition);
            void Any(IState to, Func<bool> condition) => _stateMachine.AddAnyTransition(to, condition);
        }

        // Update is called once per frame
        void Update()
        {
            _stateMachine.Tick();
        }
        public virtual void OnDrawGizmos() 
        {
            if(_stateMachine != null)
            {
                Gizmos.color = Color.gray;
                Gizmos.DrawSphere(transform.position + Vector3.up * 3, 0.5f);
            }
        }
    }
}
