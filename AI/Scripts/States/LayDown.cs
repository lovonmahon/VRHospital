using System;
using UnityEngine;

namespace VRH
{
    public class LayDown : IState
    {
        public static Action IsStanding;
        public static Action isOutOfBed;
        AIReferences _aiRef;
        AIBrain _aiBrain;
        public LayDown(AIBrain aiBrain, AIReferences aiRef)
        {
            _aiRef = aiRef;
            _aiBrain = aiBrain;
        }
        public void OnEnter()
        {
            Debug.Log("Laying down now");
            _aiRef.agent.enabled = true;
            _aiRef.agent.SetDestination(_aiBrain.layPosition.transform.position);
            _aiRef.anim.SetFloat("forwardSpeed", 0.5f);
        }
        public void Tick()
        {
            
        }
        public void OnExit()
        {
            _aiRef.agent.enabled = false;
            _aiRef.anim.SetFloat("forwardSpeed", 0.0f);
        }
        public Color GetGizmoColor()
        {
            return Color.red;
        }
        void StandUp()
        {
            IsStanding?.Invoke();
        }
        void LerpOutOfBed()
        {
            //play animation of climbing
        }
        void HopDown()
        {
            isOutOfBed?.Invoke();
        }
        public string GetStateName()
        {
            return this.ToString();
        }
    }
}