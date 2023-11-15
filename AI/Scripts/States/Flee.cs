using UnityEngine;
using UnityEngine.AI;

public class Flee : IState
{
    private readonly Patron _patron;
    private NavMeshAgent _navMeshAgent;
    private readonly NurseDetector _enemyDetector;
    private Animator _animator;
    private readonly ParticleSystem _particleSystem;
    private static readonly int FleeHash = Animator.StringToHash("Flee");

    private float _initialSpeed;
    private const float FLEE_SPEED = 6F;
    private const float FLEE_DISTANCE = 5F;

    public Flee(Patron gatherer, NavMeshAgent navMeshAgent, NurseDetector nurseDetector, Animator animator, ParticleSystem particleSystem)
    {
        _patron = gatherer;
        _navMeshAgent = navMeshAgent;
        _enemyDetector = nurseDetector;
        _animator = animator;
        _particleSystem = particleSystem;
    }

    public void OnEnter()
    {
        _navMeshAgent.enabled = true;
        _patron.DropAllResources();
        _animator.SetBool(FleeHash, true);
        _initialSpeed = _navMeshAgent.speed;
        _navMeshAgent.speed = FLEE_SPEED;
        _particleSystem.Play();
    }

    public void Tick()
    {
        if (_navMeshAgent.remainingDistance < 1f)
        {
            var away = GetRandomPoint();
            _navMeshAgent.SetDestination(away);
        }
    }

    private Vector3 GetRandomPoint()
    {
        var directionFromBeast = _patron.transform.position - _enemyDetector.GetNearestNursePosition();
        directionFromBeast.Normalize();

        var endPoint = _patron.transform.position + (directionFromBeast * FLEE_DISTANCE);
        if (NavMesh.SamplePosition(endPoint, out var hit, 10f, NavMesh.AllAreas))
        {
            return hit.position;
        }

        return _patron.transform.position;
    }

    public void OnExit()
    {
        _navMeshAgent.speed = _initialSpeed;
        _navMeshAgent.enabled = false;
        _animator.SetBool(FleeHash, false);
    }
}