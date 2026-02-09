using UnityEngine;
using UnityEngine.Events;

public class OnItemGet : MonoBehaviour
{
    public UnityEvent itemNearPlayer;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) itemNearPlayer?.Invoke();
    }
}
