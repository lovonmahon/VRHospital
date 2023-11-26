using UnityEngine;

namespace VRH
{
    public class WalkToBed : IState
    {
        AIReferences _aiRef;
        AIBrain _brain;
        Vault _vaultRef;
        public WalkToBed(AIBrain brain, AIReferences aiRef, Vault vault)
        {
            _aiRef = aiRef;
            _vaultRef = vault;
            _brain = brain;
        }
        public void Tick()
        {

        }
        public void OnEnter()
        {
            Debug.Log("Walking to bed now");
            _aiRef.agent.enabled = true;
            _aiRef.agent.SetDestination(_brain.bedTarget.position);
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