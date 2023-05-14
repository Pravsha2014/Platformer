using UnityEngine;
using TMPro;

public class Enemy : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.TryGetComponent(out Player _))
        {
            Destroy(collision.gameObject);

            _text.text = "You are dead";

            Time.timeScale = 0;
        }
    }
}
