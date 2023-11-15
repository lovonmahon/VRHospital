using UnityEngine;
using UnityEngine.AI;

internal class MoveToSelectedResource : IState
{
    private readonly Patron _patron;
    private readonly NavMeshAgent _navMeshAgent;
    private readonly Animator _animator;
    private static readonly int Speed = Animator.StringToHash("Speed");

    private Vector3 _lastPosition = Vector3.zero;
    
    public float TimeStuck;

    public MoveToSelectedResource(Patron patron, NavMeshAgent navMeshAgent, Animator animator)
    {
        _patron = patron;
        _navMeshAgent = navMeshAgent;
        _animator = animator;
    }
    
    public void Tick()
    {
        if (Vector3.Distance(_patron.transform.position, _lastPosition) <= 0f)
            TimeStuck += Time.deltaTime;

        _lastPosition = _patron.transform.position;
    }

    public void OnEnter()
    {
        TimeStuck = 0f;
        _navMeshAgent.enabled = true;
        _navMeshAgent.SetDestination(_patron.Target.transform.position);
        _animator.SetFloat(Speed, 1f);
    }

    public void OnExit()
    {
        _navMeshAgent.enabled = false;
        _animator.SetFloat(Speed, 0f);
    }
}