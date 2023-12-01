using System.Collections;
using UnityEngine;

namespace VRH
{
    public class ThrowPunches : IState
    {
        AIReferences _aiRef;
        AIBrain _aiBrain;
        public ThrowPunches(AIBrain aiBrain, AIReferences aiRef)
        {
            _aiRef = aiRef;
            _aiBrain = aiBrain;
        }
        public void OnEnter()
        {
            _aiRef.agent.speed = 0f;
            _aiRef.anim.SetFloat("forwardSpeed", 0.21f);
            Debug.Log("Throwing hands");
            _aiRef.anim.SetTrigger("fight");
        }
        public void Tick()
        {
            // {
            //     _aiRef.anim.SetTrigger("fight");
            // }
        }
        public void OnExit()
        {
            _aiBrain.canAttack = false;
            _aiRef.agent.speed = 1.0f;
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