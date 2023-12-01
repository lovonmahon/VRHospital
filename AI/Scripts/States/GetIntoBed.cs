using System.Collections;
using System;
using UnityEngine;

namespace VRH
{

    public class GetIntoBed : IState
    {
        AIReferences _aiRef;
        AIBrain _brain;
        AgentLinkMover _agentLink;
        public GetIntoBed(AIBrain brain, AIReferences aiRef, AgentLinkMover agentMover)
        {
            _brain = brain;
            _aiRef = aiRef;
            _agentLink = agentMover;
        }
        public void OnEnter()
        {
            _aiRef.agent.enabled = true;
            Debug.Log("Getting into bed now");
            if(_aiRef.agent != null)
            {
                _aiRef.agent.SetDestination(_brain.layPosition.transform.position);
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
            
        }
        public void OnExit()
        {
            _aiRef.agent.speed = 0f;
            _aiRef.agent.enabled = false;
            // _brain.HasCLimbed = true;
            // _aiRef.anim.ResetTrigger("vault");
        }
        public Color GetGizmoColor()
        {
            return Color.green;
        }
        public string GetStateName()
        {
            return this.ToString();
        }
    }
}
