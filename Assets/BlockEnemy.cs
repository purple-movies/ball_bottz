using UnityEngine;
using System.Collections;

public class BlockEnemy : MonoBehaviour
{
    public int walkDirection = -1;
    float walkSpeed = 4f;
    Rigidbody2D body;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        body.velocity = createWalkVector();
    }

    void Update ()
    {
        body.AddForce(createWalkVector());

        if (Mathf.Abs(body.velocity.x) < .1f)
        {
            walkDirection = walkDirection * -1;
            var walkVector = createWalkVector();
            body.velocity = walkVector;
            body.AddForce(walkVector);
        }

        //Debug.Log("enemy velocity : " + body.velocity.ToString());
    }

    private Vector2 createWalkVector()
    {
        return new Vector2(getWalkValue(), 0);
    }

    private float getWalkValue()
    {
        return walkDirection * walkSpeed;
    }
}
