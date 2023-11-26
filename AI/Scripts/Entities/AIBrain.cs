using System;
using UnityEngine.AI;
using UnityEngine;

namespace VRH
{
    public class AIBrain : MonoBehaviour
    {
        StateMachine _stateMachine;
        WanderAreasParent _wanderParent;
        AIReferences _aiRef;
        NavMeshAgent _agent;
        Animator _anim;
        Vault _vault;
        public HospitalBedClimbPoint BedTarget{get; set;}
        public bool HasCLimbed {get; set;}
        float characterHeight = 2f;
        float characterRadius = 0.5f;
        
        void Start()
        {
            _stateMachine = new StateMachine();
            // nurses = GetComponent<NurseReferences>();
            _wanderParent = FindObjectOfType<WanderAreasParent>();
            _aiRef = GetComponent<AIReferences>();
            _agent = GetComponent<NavMeshAgent>();
            _anim = GetComponent<Animator>();
            BedTarget = FindObjectOfType<HospitalBedClimbPoint>();
            _vault = GetComponent<Vault>();
            

            //STATES
            var wander = new WanderHospitalRoom(this, _aiRef, _wanderParent);
            var getIntoBed = new GetIntoBed(this, _aiRef);
            var walktoBed = new WalkToBed(this, _aiRef, _vault);
            //TRANSITIONS
            // At(wander, getIntoBed, () => vaultTest.canBed = true);
            At(wander, walktoBed, HasTarget());
            At(walktoBed, getIntoBed, ReachedTarget());

            _stateMachine.AddAnyTransition(wander, HasNoTarget());

            //START STATE
            _stateMachine.SetState(wander);
            // _stateMachine.SetState(getIntoBed);

            //FUNCTIONS & CONDITIONS
            void At(IState from, IState to, Func<bool> condition) => _stateMachine.AddTransition(from, to, condition);
            void Any(IState to, Func<bool> condition) => _stateMachine.AddAnyTransition(to, condition);

            Func<bool> HasTarget() => () => BedTarget != null;
            Func<bool> NearBed() => () => Vector3.Distance(transform.position, BedTarget.transform.position) < 2f;
            Func<bool> HasNoTarget() => () => BedTarget == null;
            Func<bool> ReachedTarget() => () => Vector3.Distance(
                                        transform.position, BedTarget.transform.position) <= 1f;
        }

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
