using UnityEngine;

public class PlayerWalk : MonoBehaviour
{
    [SerializeField]
    private float speed = 1f;

    private Vector2 movement = Vector2.zero;
    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        GetComponent<GetInput>().OnGetAxisVertical += GetVerticalAxis;
        GetComponent<GetInput>().OnGetAxisHorizontal += GetHorizontalAxis;
    }

    private void GetVerticalAxis(float verticalMovement)
    {
        movement.y = verticalMovement;
    }

    private void GetHorizontalAxis(float horizontalMovement)
    {
        movement.x = horizontalMovement;
    }

    private void FixedUpdate()
    {
        _rigidbody.velocity = movement * speed;
    }
}
