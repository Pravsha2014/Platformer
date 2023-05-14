using UnityEngine;

[RequireComponent(typeof(Animator), typeof(SpriteRenderer), typeof(Rigidbody2D))]
[RequireComponent (typeof(Player))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;

    private readonly int _hashRun = Animator.StringToHash("Speed");
    private readonly float _jumpForce = 8.0f;

    private Animator _animator;
    private SpriteRenderer _spriteRenderer;
    private Rigidbody2D _rigidbody2D;
    private Player _player;
    private bool _isGrounded;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _player = GetComponent<Player>();

        _player.IsGrounded += OnIsGrounded;
    }

    private void OnDisable()
    {
        _player.IsGrounded -= OnIsGrounded;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            _animator.SetFloat(_hashRun, _speed);
            _spriteRenderer.flipX = true;
            transform.Translate(_speed * Time.deltaTime, 0, 0);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            _animator.SetFloat(_hashRun, _speed);
            _spriteRenderer.flipX = false;
            transform.Translate(_speed * Time.deltaTime * -1, 0, 0);
        }
        else
        {
            _animator.SetFloat(_hashRun, 0);
        }

        if (_isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            _rigidbody2D.AddForce(Vector2.up * _jumpForce, ForceMode2D.Impulse);
        }
    }

    private void FixedUpdate()
    {
        transform.rotation = Quaternion.Euler(0, 0, 0);
    }

    private void OnIsGrounded(bool isGrounded)
    {
        _isGrounded = isGrounded;
    }
}
