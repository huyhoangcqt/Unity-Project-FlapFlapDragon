using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMovement : MonoBehaviour
{
    private Rigidbody2D rgbd;
    [SerializeField] private float force, speed;
    [SerializeField] private Vector3 distance;

    private void Start(){
        rgbd = GetComponent<Rigidbody2D>();
    }

    private void MovingRight(){
        Vector3 newPos = transform.position + distance;
        transform.position = newPos;
    }

    private void MovingLeft(){
        Vector3 newPos = transform.position - distance;
        transform.position = newPos;
    }

    private void Update(){
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        rgbd.velocity = new Vector2(horizontal, vertical) * speed;

        if (Input.GetMouseButtonDown(0)){
            MovingLeft();
        }
        if (Input.GetMouseButtonDown(1)){
            MovingRight();
        }
    }
}
