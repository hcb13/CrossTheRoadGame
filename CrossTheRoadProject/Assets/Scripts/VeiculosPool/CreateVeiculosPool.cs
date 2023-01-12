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
    private int amountPerLane = 2;

    [SerializeField]
    private float gapInstantiate = 3f;

    private void Start()
    {
        InitializePool();
        InvokeRepeating("GetVeiculoFromPool", 0.2f, gapInstantiate);
    }

    private void InitializePool()
    {
        int target = 0;
        for(int i = 0; i < amountPerLane; i++)
        {
            for (int waypointTarget = 0; waypointTarget < waypoints.Count; waypointTarget++)
            {
                target = Random.Range(0, prefabs.Count);

                AddVeiculoToPool(target, waypointTarget);
            }
        }
    }

    private void AddVeiculoToPool(int target, int waypointTarget)
    {
        GameObject gameObject = Instantiate(prefabs[target], waypoints[waypointTarget].GetWaypointInitial.position, Quaternion.identity, waypoints[waypointTarget].transform);
        if(gameObject.transform.position.x > 0)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }
        gameObject.GetComponent<MoveVeiculo>().Waypoints = waypoints[waypointTarget];
        gameObject.SetActive(false);
    }

    private GameObject GetVeiculoFromPool()
    {
        MoveVeiculo veiculo = null;

        for (int i = 0; i < waypoints.Count; i++)
        {
            for(int j = 0; j < waypoints[i].transform.childCount; j++)
            {
                veiculo = waypoints[i].transform.GetChild(j).GetComponent<MoveVeiculo>();
                if(veiculo != null)
                {
                    if (!veiculo.gameObject.activeSelf)
                    {
                        break;
                    }
                }
            }
            if(veiculo != null)
            {
                if (!veiculo.gameObject.activeSelf)
                {
                    veiculo.transform.position = veiculo.Waypoints.GetWaypointInitial.position;
                    veiculo.gameObject.SetActive(true);
                }
            }
        }

        

        return veiculo.gameObject;
    }

}
