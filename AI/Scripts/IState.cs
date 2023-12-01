using UnityEngine;
public interface IState
{
    void Tick();
    void OnEnter();
    void OnExit();
    Color GetGizmoColor();
    string GetStateName();
    
}
