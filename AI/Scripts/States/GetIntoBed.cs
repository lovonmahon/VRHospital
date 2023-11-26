using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VRH
{

    public class GetIntoBed : IState
    {
        AIReferences _aiRef;
        AIBrain _brain;
        Vault _vaultRef;
        public GetIntoBed(AIReferences aiRef, Vault vault)
        {
            _aiRef = aiRef;
            _vaultRef = vault;
        }
        public void OnEnter()
        {
            Debug.Log("Getting into bed now");
            if(_aiRef.agent != null)
            {
                _aiRef.agent.enabled = true;
                _aiRef.anim.SetTrigger("vault");
                
            }
            else
            {
                Debug.Log("No navmeshagent");
            }
        }
        public void Tick()
        {
            // _vaultRef.PerformVault();
        }
        public void OnExit()
        {
            _aiRef.agent.enabled = false;
            _brain.HasCLimbed = true;
        }
        public Color GetGizmoColor()
        {
            return Color.cyan;
        }
    }
}
