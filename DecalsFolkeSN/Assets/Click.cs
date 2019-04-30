using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Click : MonoBehaviour
{
    Camera camera;
    void Start()
    {
        camera = GetComponent<Camera>();
    }
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject.GetComponent<BallBounce>())
                {
                    hit.collider.gameObject.GetComponent<BallBounce>().Bounce(-hit.normal * 100);
                }
            }
        }
    }
}
