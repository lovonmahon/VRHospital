using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

namespace VRH
{    
    public class WanderHospitalRoom : IState
    {
        AIBrain _brain;
        AIReferences aiRef;
        WanderAreasParent _wanderAreasParent;
        int index;
        Vector3 nextDestination;
        public WanderHospitalRoom(AIBrain brain, AIReferences aiReference, WanderAreasParent area) 
        {
            _brain = brain;
            aiRef = aiReference;
            _wanderAreasParent = area;
            
        }
        void Start()
        {

        }
        public void OnEnter()
        {
            if(aiRef.agent != null)
            {
                aiRef.agent.enabled = true;
                nextDestination = GetNextWaypoint();
                aiRef.agent.SetDestination(nextDestination);
                aiRef.anim.SetFloat("forwardSpeed", 1.0f);
            }
            else
            {
                Debug.Log("No navmeshagent");
            }
        }
        public void OnExit()
        {
            aiRef.agent.enabled = false;
            aiRef.anim.SetFloat("forwardSpeed", 0.0f);
        }
        public void Tick()
        {
            if(HasArrived())
            {
                nextDestination = GetNextWaypoint();
                aiRef.agent.SetDestination(nextDestination);
                UpdateAnimator();
            }
            // _brain.climbTarget = Object.FindObjectOfType<HospitalBedClimbPoint>();
        }
        Vector3 GetNextWaypoint()
        {
            index++;
            if(index >= _wanderAreasParent.areas.Length)
            {
                index = 0;
            }
            return _wanderAreasParent.areas[index].transform.position;
        }
        public bool HasArrived()
        {
            return aiRef.agent.remainingDistance <= 0.2f;
        }
        public Color GetGizmoColor()
        {
            return Color.cyan;
        }
        void UpdateAnimator()
        {
            //First get global velocity on navmesh agent
            Vector3 velocity = aiRef.agent.velocity;
            //convert to local velocity
            Vector3 localVelocity = aiRef.transform.InverseTransformDirection(velocity);
            //Which direction of interest for movement
            float speed = localVelocity.z;
            //Influence the float parameter on the animator by feding it the speed values from the local velocity.
            aiRef.anim.SetFloat("forwardSpeed", speed);
        }
        public string GetStateName()
        {
            return this.ToString();
        }
    }
}
