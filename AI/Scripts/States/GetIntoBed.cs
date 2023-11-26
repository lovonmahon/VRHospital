using System.Collections;
using System;
using UnityEngine;

namespace VRH
{

    public class GetIntoBed : IState
    {
        AIReferences _aiRef;
        AIBrain _brain;
        public GetIntoBed(AIBrain brain, AIReferences aiRef)
        {
            _brain = brain;
            _aiRef = aiRef;
        }
        public void OnEnter()
        {
            Debug.Log("Getting into bed now");
            _aiRef.anim.SetFloat("forwardSpeed", 0.0f);
            _aiRef.anim.SetTrigger("vault");
            // if(_aiRef.agent != null)
            // {
            //     _aiRef.agent.enabled = true;
            //     if(_aiRef.agent.isOnOffMeshLink)
            //     {
            //         _aiRef.agent.speed = 0.5f;
            //         _aiRef.anim.SetTrigger("vault");
            //     }
            // }
            // else
            // {
            //     Debug.Log("No navmeshagent");
            // }
        }
        public void Tick()
        {
            
        }
        public void OnExit()
        {
            _aiRef.agent.speed = 1.0f;
            _aiRef.agent.enabled = false;
            _brain.HasCLimbed = true;
            _aiRef.anim.ResetTrigger("vault");
        }
        public Color GetGizmoColor()
        {
            return Color.cyan;
        }
    }
}
