using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MoveVeiculo : MonoBehaviour
{
    [SerializeField]
    private WaypointsVeiculos waypoints;
    [SerializeField]
    private float speed = 2f;

    public WaypointsVeiculos Waypoints
    {
        get { return waypoints; }
        set { waypoints = value; }
    }

    private Rigidbody2D _rigidbody;
    private bool isGoingRight = false;



    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        Move();
    }

    private void Move()
    {
        if (waypoints.GetWaypointInitial.position.x > 0)
        {
            // going left
            isGoingRight = false;
        }
        else
        {
            isGoingRight = true;
        }
    }

    private void Update()
    {
        if(Vector2.Distance(transform.position, waypoints.GetWaypointEnd.position) < 0.9f)
        {
            gameObject.SetActive(false);
        }
    }

    private void FixedUpdate()
    {
        if (isGoingRight)
        {
            MoveRight();
        }
        else
        {
            MoveLeft();
        }
    }

    private void MoveLeft()
    {

        _rigidbody.velocity = Vector2.left * speed;
    }

    private void MoveRight()
    {

        _rigidbody.velocity = Vector2.right * speed;

    }
}

