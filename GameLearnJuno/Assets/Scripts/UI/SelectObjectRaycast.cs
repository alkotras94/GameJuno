using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectObjectRaycast : MonoBehaviour
{
    [SerializeField] private Camera _camera;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = _camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Infinity);

            if (hit.collider != null)
            {
                Debug.Log(hit.transform.name);
            }
        }
    }
}
