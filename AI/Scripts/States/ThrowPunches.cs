using System.Collections;
using UnityEngine;

namespace VRH
{
    public class ThrowPunches : IState
    {
        AIReferences _aiRef;
        AIBrain _aiBrain;
        public static float attackTimer;
        public ThrowPunches(AIBrain aiBrain, AIReferences aiRef)
        {
            _aiRef = aiRef;
            _aiBrain = aiBrain;
        }
        public void OnEnter()
        {
            attackTimer = 4f;
            _aiRef.agent.speed = 0.21f;
            _aiRef.anim.SetFloat("forwardSpeed", 0.21f);
            Debug.Log("Throwing hands");
            _aiRef.anim.SetTrigger("fight");
        }
        public void Tick()
        {
            {
                attackTimer -= Time.deltaTime;
            }
        }
        public void OnExit()
        {
            attackTimer = 0f;
            _aiBrain.canAttack = false;
            _aiRef.agent.speed = 1f;
            _aiRef.anim.SetFloat("forwardSpeed", 1f);
            _aiRef.anim.ResetTrigger("fight");
        }
        public Color GetGizmoColor()
        {
            return Color.red;
        }
        void GetOnGround()
        {
            _aiRef.agent.speed = 1.0f;
            _aiRef.agent.SetDestination(SetDestinationTest.currentTargetDestination);
            
            _aiRef.anim.SetFloat("forwardSpeed", 1f);
            

        }
        public string GetStateName()
        {
            return this.ToString();
        }
        
    }
}