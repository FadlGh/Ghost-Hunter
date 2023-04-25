using UnityEngine;

public class PatrolAI : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Transform[] _waypoints;
    [SerializeField] private float _stoppingDistance;

    private int _currentWaypointIndex = 0;
    private Rigidbody2D _rb;
    private bool _isPatrolingForward = true;
    private bool _isFacingRight = true;
    private Vector2 _direction;
    private Vector2 _targetPosition;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _targetPosition = _waypoints[0].position;
        _direction = (_targetPosition - (Vector2)transform.position).normalized;
    }

    void FixedUpdate()
    {
        if (Vector2.Distance(transform.position, _targetPosition) < _stoppingDistance)
        {
            _targetPosition = _waypoints[_currentWaypointIndex].position;
            _direction = (_targetPosition - (Vector2)transform.position).normalized;

            if (_isPatrolingForward)
            {
                _currentWaypointIndex++;
                if (_currentWaypointIndex >= _waypoints.Length)
                {
                    _currentWaypointIndex = _waypoints.Length - 2;
                    _isPatrolingForward = false;
                    Flip();
                }
            }
            else
            {
                _currentWaypointIndex--;
                if (_currentWaypointIndex < 0)
                {
                    _currentWaypointIndex = 1;
                    _isPatrolingForward = true;
                    Flip();
                }
            }
        }
        else
        { 
            _rb.velocity = _speed * Time.fixedDeltaTime * _direction;
            print(_rb.velocity.x);
        }
    }

    private void Flip()
    {
        _isFacingRight = !_isFacingRight;
        Vector3 localScale = transform.localScale;
        localScale.x *= -1f;
        transform.localScale = localScale;
    }
}
