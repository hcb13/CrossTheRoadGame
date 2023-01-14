using System;
using UnityEngine;

public class GetInput : MonoBehaviour
{

    public Action<float> OnGetAxisHorizontal = delegate { };
    public Action<float> OnGetAxisVertical = delegate { };

    private void Update()
    {
        OnGetAxisHorizontal?.Invoke(Input.GetAxisRaw("Horizontal"));
        OnGetAxisVertical?.Invoke(Input.GetAxisRaw("Vertical"));
    }

}
