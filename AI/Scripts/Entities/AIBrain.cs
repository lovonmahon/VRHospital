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
        AgentLinkMover _agentMover;
        public ReportEverything reportEverything {get; set;}
        public HospitalBedClimbPoint BedTarget{get; set;}
        public BedLayPosition layPosition {get; set;}
        public DismountPosition dismountPosition {get; set;}
        public PlayerTarget playerTarget {get; set;}
        public Vector3 PlayerTargetPosition => SetDestinationTest.currentTargetDestination;
        public bool hasCLimbed {get; set;}
        public bool  canAttack {get; set;}
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
            layPosition = FindObjectOfType<BedLayPosition>();
            dismountPosition = FindObjectOfType<DismountPosition>();
            playerTarget = FindObjectOfType<PlayerTarget>();
            _vault = GetComponent<Vault>();
            _agentMover = GetComponent<AgentLinkMover>();
            reportEverything = FindObjectOfType<ReportEverything>();
            if(reportEverything == null)
            {
                Debug.Log($"{reportEverything} script not found!");
            }
            
            #region states
            //STATES
            var wander = new WanderHospitalRoom(this, _aiRef, _wanderParent);
            var getIntoBed = new GetIntoBed(this, _aiRef, _agentMover);
            var walktoBed = new WalkToBed(this, _aiRef, _vault);
            var wakeup = new WakeUp(this, _aiRef);
            var getOutOfBed = new GetOutOfBed(this, _aiRef);
            var fight = new ThrowPunches(this, _aiRef);
            #endregion

            #region linked transitions
            //TRANSITIONS
            At(wander, walktoBed, HasTarget());
            At(walktoBed, getIntoBed, ReachedTarget());//Makes AI get into bed
            At(getIntoBed, wakeup, Annoyed());
            At(wakeup, getOutOfBed, ChasePlayer());
            At(getOutOfBed, fight, InRange());
            At(fight, walktoBed, () => ThrowPunches.attackTimer <= 0);
            
            #endregion

            #region any transitions
            _stateMachine.AddAnyTransition(wander, HasNoTarget());
            #endregion

            #region starting state
            //START STATE
            // _stateMachine.SetState(wander);
            // _stateMachine.SetState(attack);
            // _stateMachine.SetState(getOutOfBed);
            _stateMachine.SetState(getIntoBed);
            #endregion

            #region conditions & functions
            //FUNCTIONS & CONDITIONS
            void At(IState from, IState to, Func<bool> condition) => _stateMachine.AddTransition(from, to, condition);
            void Any(IState to, Func<bool> condition) => _stateMachine.AddAnyTransition(to, condition);

            Func<bool> HasTarget() => () => BedTarget != null;
            Func<bool> HasNoTarget() => () => BedTarget == null;
            Func<bool> ReachedTarget() => () => !canAttack && Vector3.Distance(
                                        transform.position, BedTarget.transform.position) <= 1.2f;
            Func<bool> Annoyed() => () => reportEverything.InfusionPumpNotifyAIBrainCanAttack();//Input.GetKey(KeyCode.A);
            Func<bool> ChasePlayer() => () => canAttack 
                                        && Vector3.Distance(
                                        transform.position, PlayerTargetPosition) >= 1.5f
                                        && CheckAnimatorStateComplete("standup");//Is the state done playing?
            Func<bool> InRange() => () => canAttack && Vector3.Distance(
                                        transform.position, PlayerTargetPosition) < 1.5f;
                                                   
            #endregion
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
        bool CheckAnimatorStateComplete(string anim)
        {
            if(_aiRef.anim.GetCurrentAnimatorStateInfo(0).IsName(anim) &&
                _aiRef.anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.9f)
                {
                    return true;
                }
                return false;
        }
    }
}
