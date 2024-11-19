using UnityEngine;

public class Warrior : MonoBehaviour
{
    private const float SqrDistanceChecker = 0.2f * 0.2f;

    [SerializeField] private Waypoint[] _waypoints;
    [SerializeField] private float _speed;
    [SerializeField] private float _rotationSpeed;

    private Vector3[] _waypointsPositions;
    private int _currentWaypointIndex;

    private Vector3 CurrentWaypointPosition => _waypointsPositions[_currentWaypointIndex];
    private bool IsWaypointReached => (transform.position- CurrentWaypointPosition).sqrMagnitude < SqrDistanceChecker;

    private void Start()
    {
        _currentWaypointIndex = 0;
        _waypointsPositions = new Vector3[_waypoints.Length];

        for (int i = 0; i < _waypoints.Length; i++)
        {
            _waypointsPositions[i] = _waypoints[i].transform.position;
        }
    }

    private void Update()
    {
        Move();

        if (IsWaypointReached)
        {
            ToggleToNextWaypoint();
        }
    }

    private void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, CurrentWaypointPosition, _speed * Time.deltaTime);
        transform.LookAt(CurrentWaypointPosition);
    }

    private void ToggleToNextWaypoint()
    {
        _currentWaypointIndex = (++_currentWaypointIndex) % _waypoints.Length;
    }
}
