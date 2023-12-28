using System.Collections;
using UnityEngine.AI;
using UnityEngine;

namespace VRH
{
    public class GetOutOfBed : IState
    {
        AIReferences _aiRef;
        AIBrain _aiBrain;
        OffMeshLinkData _linkData;
        public GetOutOfBed(AIBrain aiBrain, AIReferences aiRef)
        {
            _aiRef = aiRef;
            _aiBrain = aiBrain;
        }
        public void OnEnter()
        {
           _aiBrain.canAttack = true;
           _aiRef.agent.enabled = true;
           _aiRef.agent.speed = 1f;
           _aiRef.agent.destination = SetDestinationTest.currentTargetDestination;
           _aiRef.anim.SetFloat("forwardSpeed", 1f);
            Debug.Log("Getting out of bed so you can talk to my hands now!!!");
            if(_aiRef.agent != null)
            {
                // _aiRef.agent.SetDestination(_aiBrain.playerTarget.transform.position);
                if(_aiRef.agent.isOnOffMeshLink)
                {
                    _aiRef.agent.speed = 0.5f;
                }
            }
            else
            {
                Debug.Log("No navmeshagent");
            }
        }

        public void Tick()
        {
            if(_aiRef.agent.isOnOffMeshLink)
            {
                Debug.Log("Moving it!");
                _aiRef.agent.CompleteOffMeshLink();
               
                Debug.Log(_aiRef.agent.pathStatus);
            }
            _aiRef.agent.destination = SetDestinationTest.currentTargetDestination;//   _aiBrain.playerTarget.transform.position;
        }
        public void OnExit()
        {
            _aiRef.agent.enabled = false;
            _aiRef.agent.speed = 0f;
            _aiRef.anim.SetFloat("forwardSpeed", 0f);
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