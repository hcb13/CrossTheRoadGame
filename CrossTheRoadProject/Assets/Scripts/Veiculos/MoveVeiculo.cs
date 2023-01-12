using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveVeiculo : MonoBehaviour
{
    [SerializeField]
    private WaypointsVeiculos waypoints;

    public WaypointsVeiculos Waypoints
    {
        get { return waypoints; }
        set { waypoints = value; }
    }



}
