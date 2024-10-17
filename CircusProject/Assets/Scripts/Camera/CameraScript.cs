using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    Rigidbody parentRB;

    private void Awake()
    {
        parentRB = GetComponent<Rigidbody>();
    }
    public void MoveCamera(float speed)
    {
        //transform.Translate(Vector3.right * speed * Time.deltaTime);
        parentRB.velocity = Vector3.right * speed * Time.deltaTime;

    }
}
