using System;
using System.Collections;
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
        public Transform bedTarget;
        public bool HasCLimbed {get; set;}
        public HospitalBedClimbPoint climbTarget {get; set;}
        int vaultLayer = 1 << 12;
        [SerializeField] Transform eyes;
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
            

            //STATES
            var wander = new WanderHospitalRoom(this, _aiRef, _wanderParent);
            var getIntoBed = new GetIntoBed(_aiRef, _vault);
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

            Func<bool> HasTarget() => () => climbTarget != null;
            Func<bool> NearBed() => () => Vector3.Distance(transform.position, bedTarget.position) < 2f;
            Func<bool> HasNoTarget() => () => climbTarget == null;
            Func<bool> ReachedTarget() => () => Vector3.Distance(
                                        transform.position, climbTarget.transform.position) < 0.5f;
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
        public void PerformVault()
    {
        RaycastHit hit;
        Debug.DrawRay(eyes.position, eyes.forward, Color.cyan, 5f);
        if(Physics.Raycast(eyes.position, eyes.forward, out hit, 3f, vaultLayer))
        {
            Debug.Log($"Hitting {hit.transform.name}");
            RaycastHit secondHit;
            if(Physics.Raycast(hit.point + (eyes.forward * characterRadius) + (Vector3.up * 0.6f * characterHeight), Vector3.down, out secondHit, characterHeight))
            {
                StartCoroutine(MoveCharacterRoutine(secondHit.point, 2f));
            }
        }
    }
    IEnumerator MoveCharacterRoutine(Vector3 targetPosition, float duration)
    {
        float time = 0;
        while(time < duration)
        {
            transform.position = Vector3.Lerp(transform.position, targetPosition, time/duration);
            time += Time.deltaTime;
            yield return null;
        }
        transform.position = targetPosition;
    }
    }
}
