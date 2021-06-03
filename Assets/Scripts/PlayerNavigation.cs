using UnityEngine;

public class PlayerNavigation : MonoBehaviour, IPlayerNavigation
{
    [SerializeField] private Transform[] _waypoints;

    private int _currentWaypointIndex = 0;

    public Vector3 GetCurrentWaypoint()
    {
        return _waypoints[_currentWaypointIndex].position;
    }

    public Vector3 GetNextWaypoint()
    {
        if(_currentWaypointIndex + 1 < _waypoints.Length)
        {
            return _waypoints[_currentWaypointIndex + 1].position;
        }
        else
        {
            return _waypoints[_currentWaypointIndex].position;
        }
    }

    public bool TryMoveToNextWaypoint()
    {
        if(_currentWaypointIndex + 1 == _waypoints.Length)
        {
            return false;
        }
        else
        {
            _currentWaypointIndex++;
            return true;
        }
    }
}