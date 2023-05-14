using UnityEngine;
using DG.Tweening;
using System.Collections;

[RequireComponent(typeof(SpriteRenderer))]
[RequireComponent(typeof(PatrolArea))]
public class Alarm : MonoBehaviour
{
    private readonly float _durationOfColorChange = 0.5f;
    private readonly Color _targetColor = Color.red;

    private Color _originalColor;
    private PatrolArea _patrolArea;
    private SpriteRenderer _spriteRenderer;
    private Coroutine _coroutine;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _patrolArea = GetComponent<PatrolArea>();

        _patrolArea.StateChanged += OnStateChanged;
        _originalColor = _spriteRenderer.color;
    }

    private void OnDisable()
    {
        _patrolArea.StateChanged -= OnStateChanged;
    }

    private void OnStateChanged(bool isChanged)
    {
        if (_coroutine != null)
        {
            StopCoroutine(_coroutine);
            _spriteRenderer.DOColor(_originalColor, _durationOfColorChange);
        }

        _coroutine = StartCoroutine(ChangeTransparency(isChanged));
    }

    private IEnumerator ChangeTransparency(bool isInArea)
    {
        while (isInArea)
        {
            _spriteRenderer.DOColor(_targetColor, _durationOfColorChange);
            yield return new WaitForSeconds(_durationOfColorChange);

            _spriteRenderer.DOColor(_originalColor, _durationOfColorChange);
            yield return new WaitForSeconds(_durationOfColorChange);
        }
    }
}
