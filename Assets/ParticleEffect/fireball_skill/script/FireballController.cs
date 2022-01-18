using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballController : MonoBehaviour
{
    [SerializeField] GameObject destroyEffect;
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

    private void OnBecameInvisible() {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag.Equals("Enemy") || other.gameObject.tag.Equals("Obstacle")
        || other.gameObject.tag.Equals("Ground")){
            print("Fireball collision with " + other.gameObject.tag);
            Vector3 pos = transform.position;
            SpawnDestroyEffect(pos);
            Destroy(gameObject);
        }
    }

    private void SpawnDestroyEffect(Vector3 position){
        Vector3 deviantPos = new Vector3(0.7f, 0, 0);
        Instantiate(destroyEffect, position + deviantPos, Quaternion.identity);
    }
}
