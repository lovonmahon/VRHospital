using System;
using UnityEngine;

namespace VRH
{
    public class WakeUp : IState
    {
        // public static Action canAttack;
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
            //TO-DO: hook up canAttack to Faction manager temperament value
            _aiBrain.canAttack = true;
        }
        public void Tick()
        {
           
        }
        public void OnExit()
        {
            _aiRef.agent.enabled = false;
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