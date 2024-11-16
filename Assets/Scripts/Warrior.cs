using UnityEngine;

public class Warrior : MonoBehaviour
{
    private const float DistanceChecker = 0.2f;
    private const float DegreesInOneRadian = 180f;

    [SerializeField] private Waypoint[] _waypoints;
    [SerializeField] private float _speed;
    [SerializeField] private float _rotationSpeed;

    private int _currentWayPointIndex;

    private Vector3 CurrentWaypoint => _waypoints[_currentWayPointIndex].gameObject.transform.position;
    private float DistanceToCurrentWaypoint => Mathf.Sqrt(Mathf.Pow(transform.position.x - CurrentWaypoint.x, 2) + Mathf.Pow(transform.position.z - CurrentWaypoint.z, 2));
    private bool IsWaypointReached => DistanceToCurrentWaypoint < DistanceChecker;

    private void Start()
    {
        _currentWayPointIndex = 0;
    }

    private void LateUpdate()
    {
        Move();

        if (IsWaypointReached)
        {
            ToggleToNextWaypoint();
        }
    }

    private void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, CurrentWaypoint, _speed * Time.deltaTime);
        transform.LookAt(CurrentWaypoint);
    }

    private void ToggleToNextWaypoint()
    {
        _currentWayPointIndex = (_currentWayPointIndex + 1) % _waypoints.Length;
    }
}
