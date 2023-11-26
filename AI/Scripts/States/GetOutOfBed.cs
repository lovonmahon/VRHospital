using System;
using UnityEngine;

namespace VRH
{
    public class GetOutOfBed : IState
    {
        public static Action IsStanding;
        public static Action isOutOfBed;
        AIReferences _aiRef;
        AIBrain _aiBrain;
        public GetOutOfBed(AIBrain aiBrain, AIReferences aiRef)
        {
            _aiRef = aiRef;
            _aiBrain = aiBrain;
        }
        public void OnEnter()
        {
            StandUp();
        }
        public void Tick()
        {

        }
        public void OnExit()
        {

        }
        public Color GetGizmoColor()
        {
            return Color.red;
        }
        void StandUp()
        {
            IsStanding?.Invoke();
        }
        void LerpOutOfBed()
        {
            //play animation of climbing
        }
        void HopDown()
        {
            isOutOfBed?.Invoke();
        }
    }
}