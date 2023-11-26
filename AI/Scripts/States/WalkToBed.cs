using UnityEngine.AI;
using UnityEngine;

namespace VRH
{
    public class WalkToBed : IState
    {
        AIReferences _aiRef;
        AIBrain _brain;
        Vault _vault;
        public WalkToBed(AIBrain brain, AIReferences aiRef, Vault vault)
        {
            _aiRef = aiRef;
            _brain = brain;
            _vault = vault;
        }
        public void Tick()
        {
            if(_aiRef.agent.isOnOffMeshLink)
                {
                    _aiRef.agent.speed = 0.2f;
                    _vault.DoVault();
                }
        }
        public void OnEnter()
        {
            Debug.Log("Walking to bed");
            _aiRef.agent.enabled = true;
            _aiRef.agent.SetDestination(_brain.BedTarget.transform.position);
            _aiRef.anim.SetFloat("forwardSpeed", 1.0f);
        }
        public void OnExit()
        {
            _aiRef.agent.enabled = false;
            _aiRef.anim.SetFloat("forwardSpeed", 0.0f);
        }
        public Color GetGizmoColor()
        {
            return Color.green;
        }
    }
}