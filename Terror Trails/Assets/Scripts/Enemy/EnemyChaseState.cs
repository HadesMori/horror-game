using UnityEngine;

public class EnemyChaseState : EnemyBaseState
{
    private Rigidbody2D _enemyRb;
    private Vector2 _direction;
    private float _speedMultiplier = 2f;

    public override void EnterState(EnemyStateManager enemy)
    {
        _enemyRb = enemy.EnemyRb;
        _direction = enemy.Direction;
        _speedMultiplier = enemy.SpeedMult;
    }
    public override void UpdateState(EnemyStateManager enemy)
    {
        _direction = (enemy.ChaseTarget.position - _enemyRb.transform.position).normalized;
    }

    public override void FixedUpdateState(EnemyStateManager enemy)
    {
        _enemyRb.velocity = _direction * enemy.Speed * _speedMultiplier * Time.fixedDeltaTime;
    }

    public override void OnTriggerEnter(EnemyStateManager enemy, Collider2D collision)
    {

    }

    public override void OnTriggerExit(EnemyStateManager enemy, Collider2D collision)
    {
        if (collision.name == "Player")
        {
            enemy.SwitchState(enemy.PatrolState);
        }
    }
}
