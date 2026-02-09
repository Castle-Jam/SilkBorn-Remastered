using UnityEngine;
using UnityEngine.Events;

// was called AggroTrigger, now EnemyScripts
public class AggroTrigger : MonoBehaviour
{
    public UnityEvent onPlayerEnter;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) onPlayerEnter?.Invoke();
    }
}
