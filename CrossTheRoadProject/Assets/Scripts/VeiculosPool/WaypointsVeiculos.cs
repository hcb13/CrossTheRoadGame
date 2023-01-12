using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointsVeiculos : MonoBehaviour
{
    [SerializeField]
    private Transform waypointInitial;

    [SerializeField]
    private Transform waypointEnd;

    public Transform GetWaypointInitial
    {
        get{ return waypointInitial; }
    }

    public Transform GetWaypointEnd
    {
        get { return waypointEnd; }
    }
}
