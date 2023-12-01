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
                    // _vault.DoVault();
                }
        }
        public void OnEnter()
        {
            _aiRef.agent.enabled = true;
            _aiRef.agent.SetDestination(_brain.BedTarget.transform.position);
            _aiRef.anim.SetFloat("forwardSpeed", 0.5f);
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