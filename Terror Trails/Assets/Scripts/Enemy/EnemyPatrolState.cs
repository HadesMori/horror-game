using UnityEngine;

public class EnemyPatrolState : EnemyBaseState
{
    private Rigidbody2D _enemyRb;
    private Vector2 _direction;
    private int _i = 0;
    private float _minDistance = 0.1f;
    
    public override void EnterState(EnemyStateManager enemy)
    {
        _enemyRb = enemy.EnemyRb;
        _direction = enemy.Direction;
    }

    public override void UpdateState(EnemyStateManager enemy)
    {
        if (Vector2.Distance(enemy.PatrolPoints[_i].position, _enemyRb.transform.position) < _minDistance)
        {
            _i++;
        }
        if (_i == enemy.PatrolPoints.Length)
        {
            _i = 0;
        }
        _direction = (enemy.PatrolPoints[_i].position - _enemyRb.transform.position).normalized;
    }

    public override void FixedUpdateState(EnemyStateManager enemy)
    {
        _enemyRb.velocity = _direction * enemy.Speed * Time.fixedDeltaTime;
    }

    public override void OnTriggerEnter(EnemyStateManager enemy, Collider2D collision)
    {
        if(collision.name == "Player")
        {
            enemy.SwitchState(enemy.ChaseState);
        }
    }

    public override void OnTriggerExit(EnemyStateManager enemy, Collider2D collision)
    {

    }
}
