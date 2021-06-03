using UnityEngine;

public interface IPlayerNavigation
{
    Vector3 GetCurrentWaypoint();
    Vector3 GetNextWaypoint();
    bool TryMoveToNextWaypoint();  
}