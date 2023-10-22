using UnityEngine;
using Zenject;

public class PlayerEntity : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] private Movement movement;

    private IPointsMovementHolder _pointsMovementHolder;
    private IUIBuilder _uiBuilder;
    private IInput _input;

    [Inject]
    public void Construct(IPointsMovementHolder pointsMovementHolder, IInput input, IUIBuilder uIBuilder)
    {
        _pointsMovementHolder = pointsMovementHolder;
        _input = input;
        _uiBuilder = uIBuilder;
    }
    private void Awake()
    {
        Initialize();
    }
    private void Initialize()
    {
        movement.Initialize(_pointsMovementHolder, _uiBuilder, _rigidbody2D);
    }
}
