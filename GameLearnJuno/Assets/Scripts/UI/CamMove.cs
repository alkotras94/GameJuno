using UnityEngine;
using System.Collections;

public class CamMove : MonoBehaviour
{
    private Transform _camera;

    private void Start()
    {
        _camera = GetComponent<Transform>();
    }
    private void Update()
    {
        if (Input.GetKey("a"))
        {
            _camera.position += new Vector3(-0.1f, 0, 0);
        }
        if (Input.GetKey("d"))
        {
            _camera.position += new Vector3(0.1f, 0, 0);
        }
        if (Input.GetKey("w"))
        {
            _camera.position += new Vector3(0, 0.1f, 0);
        }
        if (Input.GetKey("s"))
        {
            _camera.position += new Vector3(0, -0.1f, 0);
        }
    }

}

