using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerBallz : MonoBehaviour
{
    [SerializeField] Text coinsText;
    [SerializeField] Transform deathZone;

    public bool updateEnabled = true;

    JointMotor2D jointMotor;
    HingeJoint2D wheelJoint;
    Rigidbody2D body;
    float rollSpeed = 1f;
    float motorSpeed = 800f;
    float travelDir = 0f;
    int coinsCollected = 0;
    Vector3 startPoint;

    void Start()
    {
        startPoint = transform.position;
        body = GetComponent<Rigidbody2D>();
        jointMotor = new JointMotor2D();
        jointMotor.maxMotorTorque = 10000f;
        wheelJoint = GetComponent<HingeJoint2D>();
        wheelJoint.useMotor = true;
        //wheelJoint.motor = jointMotor;
    }

    void FixedUpdate()
    {
        if ( ! updateEnabled)
            return; // Allows controls to be disabled while in modals. 

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            jointMotor.motorSpeed = -motorSpeed;
            //travelDir = 1;
            //torqueMe();
        }
        else
        if (Input.GetKey(KeyCode.RightArrow))
        {
            jointMotor.motorSpeed = motorSpeed;
            //travelDir = -1;
            //torqueMe();
        }
        else
        {
            wheelJoint.useMotor = false;
            jointMotor.motorSpeed = 0;
        }
        wheelJoint.motor = jointMotor;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (body.velocity.y < .1f)
            {
                body.AddForce(new Vector2(0, 6), ForceMode2D.Impulse);
            }
        }

        if (Input.GetKey(KeyCode.B))
        {
            //var cp = transform.position;
            //transform.position = new Vector3(cp.x, cp.y + .1f, cp.z);
            torqueMe(5);
        }

        if (transform.position.y <= deathZone.position.y)
        {
            restartOnDeath();
        }

        Debug.Log("rot velocity : " + body.angularVelocity.ToString()
            + ", rot : " + body.rotation.ToString());
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        var go = collision.gameObject;
        if (go.tag == "coin")
        {
            coinsCollected++;
            coinsText.text = coinsCollected + " Coins";
            GameObject.Destroy(go);
        }
    }

    float getRollSpeed()
    {
        return rollSpeed * travelDir;
    }

    void restartOnDeath()
    {
        transform.position = startPoint;
        transform.rotation = Quaternion.identity;
        body.velocity = Vector3.zero;
        body.Sleep();
        body.WakeUp();
    }

    void torqueMe()
    {
        torqueMe(.2f);
    }

    void torqueMe(float muliplier)
    {
        body.AddTorque(getRollSpeed() * muliplier);
    }
}
