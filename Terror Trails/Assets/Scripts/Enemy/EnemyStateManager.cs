using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateManager : MonoBehaviour
{
    private EnemyBaseState _currentState;

    public EnemyChaseState ChaseState = new EnemyChaseState();
    public EnemyPatrolState PatrolState = new EnemyPatrolState();

    public Rigidbody2D EnemyRb { get; private set; }
    public Vector2 Direction { get; private set; }

    public Transform[] PatrolPoints;
    public Transform ChaseTarget;
    public float Speed;
    public float SpeedMult;

    void Start()
    {
        EnemyRb = GetComponent<Rigidbody2D>();
        _currentState = PatrolState;
        _currentState.EnterState(this);
    }

    private void Update()
    {
        _currentState.UpdateState(this);
    }

    private void FixedUpdate()
    {
        _currentState.FixedUpdateState(this);
    }

    public void SwitchState(EnemyBaseState state)
    {
        _currentState = state;
        state.EnterState(this);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        _currentState.OnTriggerEnter(this, collision);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _currentState.OnTriggerExit(this, collision);
    }
}
