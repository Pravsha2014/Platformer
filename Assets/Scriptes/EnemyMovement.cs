using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform[] _patrolAreaEdges;

    private int _currentIndex;
    private Vector3 _currentTarget;

    private void Start()
    {
        _currentTarget = _patrolAreaEdges[0].position;
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, _currentTarget, _speed * Time.deltaTime);
        ChangeCurrentIndex();
        Vector2 moveX = _currentTarget - transform.position;
        CheckSide(moveX.x);
    }

    private void CheckSide(float moveX)
    {
        if (moveX == 0) return;

        float scaleX = transform.localScale.x;
        scaleX = moveX < 0 ? Mathf.Abs(scaleX) : Mathf.Abs(scaleX) * -1;

        transform.localScale = new Vector2(scaleX, transform.localScale.y);
    }

    private void ChangeCurrentIndex()
    {
        if(transform.position == _patrolAreaEdges[_currentIndex].position)
        {
            _currentIndex++;

            if (_currentIndex >= _patrolAreaEdges.Length)
            {
                _currentIndex = 0;
            }

            _currentTarget = _patrolAreaEdges[_currentIndex].position;
        }
    }
}
