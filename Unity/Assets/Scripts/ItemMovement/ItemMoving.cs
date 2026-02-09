using UnityEngine;

public class ItemMoving : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float moveDistance;
    [SerializeField] private int aggroTime;
    public bool huntState;
    private float _aggroCounter;
    private Transform _playerLocation;
    // private bool _collided;

    private void Start()
    {
        _playerLocation = GameObject.FindWithTag("Player").transform;
        huntState = false;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        // --- Wall Detection ---
        // FÜr einzelne Objekte gut
        // collision.attachedRigidbody.gameObject.tag != "Player";
        // if (collision != null) _collided = true;
        // else _collided = false;

        if (collision.gameObject.TryGetComponent(out Health health) && collision.CompareTag("Player")) health.Heal(1);
    }

    public void ChasePlayer()
    {
        // --- Der Enemy versucht zum Spieler zu gelangen kommt aber nicht durch Wände oder über Blöcke wäre auch gut wenn er dafür nicht
        // fallen müsste hat nämlich keine Gravity bisher ---
        if (_playerLocation == null) return;

        huntState = true;
        var playerDirection = _playerLocation.position - transform.position;
        // playerDirection.y = 0;
        playerDirection = playerDirection.normalized;

        transform.position += playerDirection * speed * Time.deltaTime;

        _aggroCounter += Time.deltaTime;
        if (_aggroCounter >= aggroTime)
        {
            huntState = false;
            _aggroCounter = 1f;
        }
    }

    public void Die()
    {
        Destroy(gameObject);

        // if (collision.gameObject.TryGetComponent<Health>(out Health health))  { health.Heal(1); }
    }
}
