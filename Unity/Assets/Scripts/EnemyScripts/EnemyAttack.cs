using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private float windUpTime = 1;
    [SerializeField] private float attackDuration = 1;
    [SerializeField] private float cooldownDuration = 1;

    public GameObject attackArea;
    private AttackState _attackState;
    private PlayerMovement _playerMovement;

    private float _currentAttackDuration;
    private float _currentCooldownTime;
    private float _currentWindUpTime;

    private void Start()
    {
        _playerMovement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        switch (_attackState)
        {
            case AttackState.Windup:
                _currentWindUpTime += Time.deltaTime;
                if (_currentWindUpTime >= windUpTime) DoAttack();
                break;
            case AttackState.Attacking:
                _currentAttackDuration += Time.deltaTime;
                if (_currentAttackDuration >= attackDuration) EndAttack();
                break;
            case AttackState.Cooldown:
                _currentCooldownTime += Time.deltaTime;
                if (_currentCooldownTime >= cooldownDuration) _attackState = AttackState.Ready;
                break;
        }
    }

    private void EndAttack()
    {
        _attackState = AttackState.Cooldown;
        attackArea.SetActive(false);

        _playerMovement.enabled = true;
    }

    public void Attack()
    {
        if (_attackState != AttackState.Ready) return;

        _attackState = AttackState.Windup;
        _currentWindUpTime = 0;

        _playerMovement.enabled = false;
    }

    private void DoAttack()
    {
        _attackState = AttackState.Attacking;

        Debug.Log("Attack wird ausgeführt");

        attackArea.SetActive(true);
        _currentAttackDuration = 0;
    }

    public void DoDamage(GameObject enemy)
    {
        Debug.Log("Damage");

        enemy.TryGetComponent(out Health healthValue);
        healthValue.Damage(1);
    }

    private enum AttackState
    {
        Ready,
        Windup,
        Attacking,
        Cooldown
    }
}
