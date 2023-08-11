using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCollision : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
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
    }
}
