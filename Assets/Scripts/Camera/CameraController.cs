using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    /*[SerializeField] Transform followTarget;*/

    [SerializeField] float speed = 10f;

    private void Start()
    {
    }

    private void Update()
    {
        if (Input.GetAxis("Horizontal") != 0)
        {
            transform.Translate(Vector3.right * (speed * Time.deltaTime));
        }
        if (Input.GetAxis("Vertical") != 0)
        {
            transform.Translate(Vector3.forward * (speed * Time.deltaTime));
        }
    }
}
