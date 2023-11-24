using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine;

namespace VRH
{    
    public class WanderHospitalRoom : IState
    {
        AIReferences aiRef;
        WanderAreasParent _wanderAreasParent;
        int index;
        Vector3 nextDestination;
        public WanderHospitalRoom(AIReferences aiReference, WanderAreasParent area) 
        {
            aiRef = aiReference;
            _wanderAreasParent = area;
            
        }
        public void OnEnter()
        {
            // AreaOfInterest currentInterrestPoint = _wanderAreasParent.GetRandomArea();
            if(aiRef.agent != null)
            {
                aiRef.agent.enabled = true;
                // aiRef.agent.SetDestination(currentInterrestPoint.transform.position);
                nextDestination = GetNextWaypoint();
                aiRef.agent.SetDestination(nextDestination);
            }
            else
            {
                Debug.Log("No navmeshagent");
            }
        }
        public void OnExit()
        {
            aiRef.agent.enabled = false;
            aiRef.agent.ResetPath();
            // _client.Anim.SetFloat() //set back to zero
        }
        public void Tick()
        {
            // _client.Anim.SetFloat();
            if(HasArrived())
            {
                nextDestination = GetNextWaypoint();
                aiRef.agent.SetDestination(nextDestination);
            }
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
            return Color.blue;
        }
    }
}
