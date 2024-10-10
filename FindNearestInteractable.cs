using System.Collections;
using System.Collections.Generic;
using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using UnityEngine;


public class FindNearestInteractable : MonoBehaviour
{
    public Transform[] interactables;//Array of transform targets
    [SerializeField] Transform player;
    [SerializeField] float timer;
    float elapsedTime;
 
    void Update()
    {
        elapsedTime += Time.deltaTime;
        if(elapsedTime >= timer)
        {
            FindNearest();
            elapsedTime = 0f;
        }
    }

    void FindNearest()
    {
        Vector3 currentPlayerPosition = player.position;//dynamically update player loc
        //Set up native containers 
        NativeArray<Vector3> interactablesPositions = new NativeArray<Vector3>(interactables.Length, Allocator.TempJob);
        NativeArray<float> distances = new NativeArray<float>(interactables.Length, Allocator.TempJob);

        //Populate the above native arrays with data from this class to be passed later to struct
        for(int i = 0; i < interactables.Length; i++)
        {
            interactablesPositions[i] = interactables[i].position;
        }

        //Create and schedule job. Set struct's native container variables to this class's native container variables
        FindNearestInteractableJob theJob = new FindNearestInteractableJob
        {
            //struct variables          class variavbles
            interactablesPositions  = interactablesPositions,
            distances               = distances,
            playerLoc               = currentPlayerPosition
        };
        JobHandle jobHandle = theJob.Schedule(interactables.Length, 64);
        jobHandle.Complete();
        
        //Get the nearest
        float nearestDistance = float.MaxValue;
        int nearestInteractableIndex = -1; //default sentinel value. None selected 
        for(int i = 0; i < interactables.Length; i++)
        {
            if(distances[i] < nearestDistance)
            {
                nearestDistance = distances[i];
                nearestInteractableIndex = i;
            }
        }
        //Do something with the nearest found interactable
        if(nearestInteractableIndex != -1)//if there is an interactable
        {
            Transform closestTransform = interactables[nearestInteractableIndex];
            Debug.Log($"Closest transform is {closestTransform}");
        }
        // //Dispose the native containers
        interactablesPositions.Dispose();
        distances.Dispose();
    }

    [BurstCompile]
    struct FindNearestInteractableJob : IJobParallelFor
    {
        public Vector3 playerLoc;
        [ReadOnly]
        public NativeArray<Vector3> interactablesPositions;
        public NativeArray<float> distances;
        public void Execute(int index)
        {
            distances[index] = Vector3.Distance(playerLoc, interactablesPositions[index]);
        }
    }
}
