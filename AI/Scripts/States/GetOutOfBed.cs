using System.Collections;
using UnityEngine;

namespace VRH
{
    public class GetOutOfBed : IState
    {
        AIReferences _aiRef;
        AIBrain _aiBrain;
        public GetOutOfBed(AIBrain aiBrain, AIReferences aiRef)
        {
            _aiRef = aiRef;
            _aiBrain = aiBrain;
        }
        public void OnEnter()
        {
            _aiRef.agent.enabled = true;
            _aiBrain.canAttack = true;
            _aiRef.anim.SetFloat("forwardSpeed", 1f);
            Debug.Log("I'm coming for ya!");
            
            if(_aiRef.agent != null)
            {
                GetOnGround();
                if(_aiRef.agent.isOnOffMeshLink)
                {
                    _aiRef.agent.speed = 0.5f;
                }
                _aiRef.agent.speed = 1.0f;
            }
            else
            {
                Debug.Log("No navmeshagent");
            }
        }
        public void Tick()
        {
            _aiRef.agent.SetDestination(SetDestinationTest.currentTargetDestination);
            GetOnGround();
        }
        public void OnExit()
        {

        }
        public Color GetGizmoColor()
        {
            return Color.red;
        }
        void GetOnGround()
        {
            _aiRef.agent.SetDestination(SetDestinationTest.currentTargetDestination);

            
        }
        public string GetStateName()
        {
            return this.ToString();
        }
        
    }
}