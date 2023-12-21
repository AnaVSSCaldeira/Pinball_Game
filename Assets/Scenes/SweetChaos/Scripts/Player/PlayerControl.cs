using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float speed = 900f;

    [SerializeField] private HingeJoint2D rightFlipper, leftFlipper;
    [SerializeField] private JointMotor2D rightForce, leftForce;

    [SerializeField] private SpringJoint2D springJoint;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float force = 0f;
    public float maxForce = 0.75f;

    public GameObject ball;

    void Start()
    {
        rightFlipper.useLimits = true;
        leftFlipper.useLimits = true;
        
        rightFlipper.useMotor = false;
        leftFlipper.useMotor = false;

        rightForce = rightFlipper.motor;
        leftForce = leftFlipper.motor;

        springJoint.distance = 1f;
    }

    void Update()
    {
        if(GameManager.instance.playerLife > 0) // essa variavel vai pegar do GameManager!!
        {

            PlayerFlippers();
            PlayerPlunger();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            ball.transform.position = new Vector3(-0.4879999f, -3.183585f, 0);
        }

        }


    void PlayerFlippers()
    {
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            rightForce.motorSpeed = speed;
            rightFlipper.useMotor = true;
            rightFlipper.motor = rightForce;
        }
        if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.RightArrow))
        {
            rightFlipper.useMotor = false;
        }

        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            leftForce.motorSpeed = -speed;
            leftFlipper.useMotor = true;
            leftFlipper.motor = leftForce;
        }
        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.LeftArrow))
        {
            leftFlipper.useMotor = false;
        }
    }

    void PlayerPlunger()
    {
        // When the plunger is held down
        if (force <= maxForce && Input.GetKey(KeyCode.Space))
        {
            // retract the springJoint distance and reduce the power
            springJoint.distance = 1f - force;
            rb.AddForce(Vector3.down * 1);
            force += 0.0009f;
        }   

        if (force != 0 && Input.GetKeyUp(KeyCode.Space))
        {
            // release springJoint and power up
            springJoint.distance = 1f;
            rb.AddForce(Vector3.up * 1);
            force = 0;
        }

    }
}
