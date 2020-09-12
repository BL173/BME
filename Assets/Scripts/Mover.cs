using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] Collider2D ground;
    [SerializeField] Collider2D oppositeEnd;
    public float speed;
    enum Position
    {
        Front, Back
    }
    [SerializeField] Position position;
    private Rigidbody2D rb2d;
    // Update is called once per frame
    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {
        float moveHorizontal = 0;
        float moveVertical = 0;
        if (oppositeEnd.IsTouching(ground))
        {
            if (position.Equals(Position.Front))
            {
                moveHorizontal = Input.GetAxis("HorizontalFront");
                moveVertical = Input.GetAxis("VerticalFront");
            }
            else if (position.Equals(Position.Back))
            {
                moveHorizontal = Input.GetAxis("HorizontalBack");
                moveVertical = Input.GetAxis("VerticalBack");

            }
            Vector2 movement = new Vector2(moveHorizontal, moveVertical);
            rb2d.AddForce(movement * speed);
        }
    }
}

    