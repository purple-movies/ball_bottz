using UnityEngine;
using System.Collections;

//[RequireComponent (typeof(Rigidbody2D))]

public class BouncePad : MonoBehaviour
{
    [SerializeField]
    BallBot player;

    Rigidbody2D body;
    Vector2 force = new Vector2(0, 100);

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            player.applyBouncerForce(force);
        }
    }
}
