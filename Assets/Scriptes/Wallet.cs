using UnityEngine;
using TMPro;

[RequireComponent (typeof(Player))]
public class Wallet : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text;

    private int _amount;
    private Player _player;

    private void Start()
    {
        _player = GetComponent<Player>();

        _player.CoinTaken.AddListener(TakeCoin);
    }

    private void TakeCoin()
    {
        _amount++;

        _text.text = "Collected coins: " + _amount.ToString();
    }
}
