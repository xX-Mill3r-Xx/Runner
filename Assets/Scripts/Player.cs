using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody rig;
    private bool isJumping;

    public float speedRun;
    public float speedMove;
    public float jump;

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Jump();
    }

    private void FixedUpdate()
    {
        Move();
    }

    void Move()
    {
        rig.velocity = new Vector3(rig.velocity.x, rig.velocity.y, speedRun);

        if (Input.GetKey(KeyCode.A))
        {
            rig.velocity = new Vector2(-speedMove, rig.velocity.y);
        }

        if (Input.GetKey(KeyCode.D))
        {
            rig.velocity = new Vector2(speedMove, rig.velocity.y);
        }
    }

    void Jump()
    {
        if (Input.GetKey(KeyCode.Space) && !isJumping)
        {
            isJumping = true;
            rig.AddForce(new Vector3(0f, jump, jump), ForceMode.Impulse);
        }
        isJumping = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.layer == 3)
        {
            isJumping = false;
        }
    }
}
