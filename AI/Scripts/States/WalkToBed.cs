using UnityEngine.AI;
using UnityEngine;

namespace VRH
{
    public class WalkToBed : IState
    {
        AIReferences _aiRef;
        AIBrain _aiBrain;
        Vault _vault;
        public WalkToBed(AIBrain aiBrain, AIReferences aiRef, Vault vault)
        {
            _aiRef = aiRef;
            _aiBrain = aiBrain;
            _vault = vault;
        }
        public void Tick()
        {
            if(_aiRef.agent.isOnOffMeshLink)
            {
                _aiRef.agent.speed = 0.2f;
            }
        }
        public void OnEnter()
        {
            _aiRef.agent.enabled = true;
            _aiRef.agent.SetDestination(_aiBrain.BedTarget.transform.position);
            _aiRef.anim.SetFloat("forwardSpeed", 0.5f);
            Debug.Log("Walking to bed");
        }
        public void OnExit()
        {
            _aiRef.agent.enabled = false;
            _aiRef.anim.SetFloat("forwardSpeed", 0.0f);
            _aiRef.anim.SetTrigger("vault");
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