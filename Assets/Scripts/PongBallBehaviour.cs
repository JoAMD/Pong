using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PongBallBehaviour : MonoBehaviour
{

    [SerializeField] private float ballVelocity = 3f;
    [SerializeField] private Rigidbody2D rigidbody2D;
    private bool hasGameStarted = false;
    private Vector2 initialPosition;

    private void Start()
    {
        initialPosition = transform.position;
    }

    public void StartGame()
    {
        //choose direction of initial pong ball velocity
        transform.position = initialPosition;
        int randomAngle = Random.value > 0.5 ? Random.Range(-45, 45) : Random.Range(90 + 45, 180 + 45);
        Vector2 initialDirection = Quaternion.AngleAxis(randomAngle, Vector3.forward) * Vector2.right;
        hasGameStarted = true;
        rigidbody2D.freezeRotation = true;
        rigidbody2D.velocity = initialDirection * ballVelocity;
    }

    private void FixedUpdate()
    {
        if (hasGameStarted)
        {
            //rigidbody2D.velocity = rigidbody2D.velocity.normalized * ballVelocity;
        }
        //print("vel = " + rigidbody2D.velocity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    Vector2 rbVelocity = rigidbody2D.velocity;
    //    print("triggered!");
    //    if (collision.tag.StartsWith("Collider"))
    //    {
    //        Vector2 normal = Vector2.zero;
    //        char direction = collision.tag[collision.tag.Length - 1];
    //        switch (direction)
    //        {
    //            case 'N':
    //                normal = Vector2.down;
    //                break;
    //            case 'E':
    //                normal = Vector2.left;
    //                break;
    //            case 'S':
    //                normal = Vector2.up;
    //                break;
    //            case 'W':
    //                normal = Vector2.right;
    //                break;
    //            default:
    //                break;
    //        }

    //        float angle = 180 - Vector2.Angle(rbVelocity, normal);
    //        print("angle = " + angle);
    //        float angleToRotateBy = 180 - 2 * angle;
    //        Debug.DrawRay(transform.position, rbVelocity, Color.red);
    //        print(rbVelocity);
    //        rigidbody2D.velocity = Quaternion.AngleAxis(angleToRotateBy, Vector3.forward) * rbVelocity;
    //        Debug.DrawRay(transform.position, rbVelocity, Color.red);
    //        print(rbVelocity);
    //    }
    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (BasesManager.instance.IsTriggerBase(collision))
        {
            //restart
            StartGame();
            return;
        }
        Vector2 rbVelocity = rigidbody2D.velocity;
        //print("triggered!");
        if (collision.tag.StartsWith("Collider"))
        {
            Vector2 newVelocity = rbVelocity;
            char direction = collision.tag[collision.tag.Length - 1];
            switch (direction)
            {
                case 'N':
                    newVelocity.y *= -1;
                    break;
                case 'E':
                    newVelocity.x *= -1;
                    break;
                case 'S':
                    newVelocity.y *= -1;
                    break;
                case 'W':
                    newVelocity.x *= -1;
                    break;
                default:
                    break;
            }

            //TODO: give nudge according to place where ball hits

            //float angle = 180 - Vector2.Angle(rbVelocity, normal);
            //print("angle = " + angle);
            //float angleToRotateBy = 180 - 2 * angle;
            //Debug.DrawRay(transform.position, rbVelocity, Color.red, 4f);
            //print(rbVelocity);
            rigidbody2D.velocity = newVelocity;
            //Debug.DrawRay(transform.position, rbVelocity, Color.red, 4f);
            //print(rbVelocity);
        }
    }

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    Vector2 rbVelocity = rigidbody2D.velocity;
    //    print(rbVelocity);
    //    // no need of contacts actually, use tags to find which we collided with and then automatically find the normal
    //    print("collided");
    //    Vector2 normal = collision.contacts[0].normal;
    //    float angle = 180 - Vector2.Angle(rbVelocity, normal);
    //    float angleToRotateBy = 180 - 2 * angle;
    //    Debug.DrawRay(transform.position, rbVelocity, Color.red);
    //    rigidbody2D.velocity = Quaternion.AngleAxis(angleToRotateBy, Vector3.forward) * rbVelocity;
    //    Debug.DrawRay(transform.position, rbVelocity, Color.red);
    //}
}
