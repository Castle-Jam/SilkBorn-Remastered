using UnityEngine;
using UnityEngine.Events;

public class EnemyTurnAround : MonoBehaviour
{
    [SerializeField] private UnityEvent collisionDetection;

    public void Start()
    {
        collisionDetection ??= new UnityEvent();
    }

    private void OnTriggerEnter(Collider other)
    {
        collisionDetection.Invoke();
    }
}
