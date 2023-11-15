using UnityEngine;

internal class HarvestResource : IState
{
    private readonly Patron _patron;
    private readonly Animator _animator;
    private float _resourcesPerSecond = 3;

    private float _nextTakeResourceTime;
    private static readonly int Harvest = Animator.StringToHash("Harvest");

    public HarvestResource(Patron patron, Animator animator)
    {
        _patron = patron;
        _animator = animator;
    }

    public void Tick()
    {
        if (_patron.Target != null)
        {
            if (_nextTakeResourceTime <= Time.time)
            {
                _nextTakeResourceTime = Time.time + (1f / _resourcesPerSecond);
                _patron.TakeFromTarget();
                _animator.SetTrigger(Harvest);
            }
        }
    }

    public void OnEnter()
    {
    }

    public void OnExit()
    {
    }
}