using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCollision : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        //print(GameManager.instance.points_number);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("BallBumper"))
        {
            GameManager.instance.PointSystem(10);
        }

        if (other.CompareTag("TriangleBumper"))
        {
            GameManager.instance.PointSystem(15);
        }
    }
}
