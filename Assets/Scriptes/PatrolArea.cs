using UnityEngine;
using UnityEngine.Events;

public class PatrolArea : MonoBehaviour
{
    public event UnityAction<bool> StateChanged;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out _))
        {
            StateChanged?.Invoke(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent<Player>(out _))
            StateChanged?.Invoke(false);
    }
}
