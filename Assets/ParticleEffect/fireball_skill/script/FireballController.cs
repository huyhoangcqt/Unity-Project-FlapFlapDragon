using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballController : MonoBehaviour
{
    private BulletStats stats;
    private Rigidbody2D rgbd;

    private void Start() {
        stats = GetComponent<BulletStats>();
        rgbd = GetComponent<Rigidbody2D>();
        Moving();
    }

    private void Moving(){
        float speed = stats.speed;
        rgbd.velocity = Vector2.right * speed;
    }
}
