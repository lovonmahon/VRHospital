using System;
using UnityEngine;

namespace VRH
{
    public class WakeUp : IState
    {
        public static Action canAttack;
        AIReferences _aiRef;
        AIBrain _aiBrain;
        // bool canAttack;
        public WakeUp(AIBrain aiBrain, AIReferences aiRef)
        {
            _aiRef = aiRef;
            _aiBrain = aiBrain;
        }
        public void OnEnter()
        {
            _aiRef.anim.SetTrigger("wakeup");
            Debug.Log("waking up");
            _aiRef.agent.enabled = true;
            _aiBrain.canAttack = true;
            // canAttack = true;
            
            // if(_aiRef.anim.GetCurrentAnimatorStateInfo(0).IsName("wakeup"))
            // {
            //     Debug.Log($"Alright, that's it! {_aiRef.anim.GetCurrentAnimatorStateInfo(0)}");
            //     _aiRef.agent.enabled = true;
            //     GetOnGround();
            // }
            // else if(!_aiRef.anim.IsInTransition(0))
            // {
            //     Debug.Log($"Alright, that's it! {_aiRef.anim.IsInTransition(0)}");
                
            // }
        }
        public void Tick()
        {
           
        }
        public void OnExit()
        {
            _aiRef.agent.enabled = false;
            // canAttack = false;
        }
        public Color GetGizmoColor()
        {
            return Color.red;
        }
        public string GetStateName()
        {
            return this.ToString();
        }
    }
}