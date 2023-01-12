using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateVeiculosPool : MonoBehaviour
{

    [SerializeField]
    private List<GameObject> prefabs;

    [SerializeField]
    private List<WaypointsVeiculos> waypoints;

    [SerializeField]
    private int amount = 1;

    private void Start()
    {
        InitializePool();
    }

    private void InitializePool()
    {
        int target = 0;
        int waypointTarget = 0;
        for(int i = 0; i < amount; i++)
        {
            target = Random.Range(0, prefabs.Count);
            waypointTarget = Random.Range(0, waypoints.Count);
            AddVeiculoToPool(target, waypointTarget);
        }
    }

    private void AddVeiculoToPool(int target, int waypointTarget)
    {
        GameObject gameObject = Instantiate(prefabs[target], waypoints[waypointTarget].GetWaypointInitial.position, Quaternion.identity, transform);
        if(gameObject.transform.position.x > 0)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }
        gameObject.GetComponent<MoveVeiculo>().Waypoints = waypoints[waypointTarget];
    }

}
