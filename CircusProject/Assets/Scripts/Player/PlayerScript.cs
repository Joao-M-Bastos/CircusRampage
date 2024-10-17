using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    Rigidbody playerRB;

    private void Awake()
    {
        playerRB = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Vector3 screenVelocity = Vector3.right * GameManager.Instance.ScreenSpeed * Time.deltaTime;
        Vector3 inputVelocity = Input.GetAxisRaw("Horizontal") * screenVelocity;

        Vector3 velocity = screenVelocity + inputVelocity;
        velocity.y = playerRB.velocity.y;

        playerRB.velocity = velocity;
    }
}
