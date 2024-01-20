using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rbPlayer;
    // Start is called before the first frame update
    void Start()
    {
        rbPlayer = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float dirX = Input.GetAxis("Horizontal");
        rbPlayer.velocity = new Vector2(dirX * 7f, rbPlayer.velocity.y);
        if (Input.GetKeyDown("space"))
        {
            rbPlayer.velocity = new Vector2(rbPlayer.velocity.x, 14f);
        }
    }
}
