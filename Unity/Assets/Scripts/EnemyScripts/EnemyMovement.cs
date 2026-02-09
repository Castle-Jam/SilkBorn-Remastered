using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float moveDistance;
    [SerializeField] private int aggroTime;
    [SerializeField] private bool huntState;
    public GameObject aggroArea;
    public GameObject damageArea;
    public GameObject attackRange;

    private readonly Vector2 _moveVector = new(1, 0);
    private const int Multiplier = 10;
    private const int Negative = -1;

    private Transform _playerLocation;
    private float _aggroCounter;
    private float _currentMoveDistance;
    private bool _collided;
    private int _direction = 1;

    private void Start()
    {
        _playerLocation = GameObject.FindWithTag("Player").transform;
        huntState = false;
    }

    private void Update()
    {
        // --- Patrol Movement ---
        if (huntState)
        {
            ChasePlayer();
            return;
        }

        transform.rotation = _direction == 1 ? Quaternion.Euler(0, -180, 0) : Quaternion.Euler(0, 0, 0);
        Patrol();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // --- Wall Detection ---
        //FÜr einzelne Objekte gut
        // collision.attachedRigidbody.gameObject.tag != "Player";
        _collided = collision != null;

        if (collision.gameObject.TryGetComponent(out Health health) && collision.CompareTag("Player"))
            health.Damage(155);
    }

    private void Patrol()
    {
        _currentMoveDistance = _currentMoveDistance + 1 * Time.deltaTime * Multiplier;
        Vector2 position = transform.position;
        position += _moveVector * (speed * _direction * Time.deltaTime);
        transform.position = position;

        if (moveDistance <= _currentMoveDistance)
        {
            _direction *= Negative;
            _currentMoveDistance = 0;
        }
    }

    private void UpdateRotation()
    {
        transform.rotation = _direction == 1 ? Quaternion.Euler(0, -180, 0) : Quaternion.Euler(0, 0, 0);
    }

    public void TurnAround()
    {
        if (_collided)
        {
            _direction = _direction * Negative;
            _currentMoveDistance = moveDistance - _currentMoveDistance;
        }

        UpdateRotation();
    }

    public void ChasePlayer()
    {
        // --- Der Enemy versucht zum Spieler zu gelangen kommt aber nicht durch Wände oder über Blöcke wäre auch gut wenn er dafür nicht
        // fallen müsste hat nämlich keine Gravity bisher ---
        if (!_playerLocation) return;

        huntState = true;
        var playerDirection = _playerLocation.position - transform.position;
        playerDirection.y = 0;
        playerDirection = playerDirection.normalized;

        transform.position += playerDirection * (speed * Time.deltaTime);

        _aggroCounter += Time.deltaTime;
        if (_aggroCounter >= aggroTime)
        {
            huntState = false;
            _aggroCounter = 0;
        }
    }

    public void Die()
    {
        Destroy(gameObject);
    }
}
