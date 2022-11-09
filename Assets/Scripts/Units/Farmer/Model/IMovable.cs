using UnityEngine;
using Pathfinding;
using UnityEngine.Events;
using System.Collections.Generic;

public interface IMovable
{
    public event UnityAction<GameObject> IsBedVisited;
    public IReadOnlyList<Transform> MoveTargets { get; }
    public bool IsTargetReached { get; }
    public bool IsHomeReached { get; }
    public void MoveToPoint(AIDestinationSetter aiDestinationSetter);
    public void MoveToHome(AIDestinationSetter aiDestinationSetter);
    public void AddMovingPoint(Transform point);
}