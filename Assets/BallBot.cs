using UnityEngine;
using System.Collections;

public class BallBot : MonoBehaviour
{
    private const float HORIZONTAL_FORCE = 14;
    [SerializeField] GameObject boxObject;
    [SerializeField] GameObject ballObject;
    [SerializeField] GameObject boxGraphic;
    [SerializeField] GameObject ballGraphic;
    [SerializeField] Transform deathPoint;

    Rigidbody2D body;
    Vector3 startPoint;
    float deathY;
    bool rolling = false;

    Vector2 myPos;
    Vector2 groundCheckPos;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        startPoint = transform.position;
        deathY = deathPoint.position.y;
    }

    void addHorizontalForce(float theForce)
    {
        body.AddForce(new Vector2(theForce, 0));
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            if (rolling)
            {
                GameObject.Destroy(collision.gameObject);
            }
            else
            {
                restartOnDeath();
            }
        }
    }

    void Update()
    {
        if (transform.position.y < deathY)
        {
            restartOnDeath();
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            addHorizontalForce(HORIZONTAL_FORCE);
        }
        else
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            addHorizontalForce(-HORIZONTAL_FORCE);
        }

        rolling = false;
        if (Input.GetKey(KeyCode.DownArrow))
        {
            rolling = true;
        }

        var currentX = transform.position.x;
        var currentY = transform.position.y;
        myPos = new Vector2(currentX, currentY);
        groundCheckPos = new Vector2(currentX, currentY - 1);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded())
        {
            body.AddForce(new Vector2(0, 6), ForceMode2D.Impulse);
        }

        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    if (body.velocity.y < .1f)
        //        body.AddForce(new Vector2(0, 6), ForceMode2D.Impulse);
        //}

        ballObject.SetActive(false);
        boxObject.SetActive(false);
        ballGraphic.SetActive(false);
        boxGraphic.SetActive(false);
        if (rolling)
        {
            ballObject.SetActive(true);
            ballGraphic.SetActive(true);
        }
        else
        {
            boxObject.SetActive(true);
            boxGraphic.SetActive(true);
        }
    }

    bool isGrounded()
    {
        bool result = Physics2D.Linecast(myPos, groundCheckPos, 1 << LayerMask.NameToLayer("ground"));
        Debug.Log("is grounded : " + result.ToString());

        if (result) {
            Debug.DrawLine(myPos, groundCheckPos, Color.green, 0.5f, false);
        } else {
            Debug.DrawLine(myPos, groundCheckPos, Color.red, 0.5f, false);
        }
        return result;
    }

    void restartOnDeath()
    {
        transform.position = startPoint;
        transform.rotation = Quaternion.identity;
        body.velocity = Vector3.zero;
        body.Sleep();
        body.WakeUp();
    }

    public void applyBouncerForce(Vector2 force)
    {
        body.AddForce(force);
    }
}
