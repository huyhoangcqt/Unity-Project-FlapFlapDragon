using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    private EnemyHealthController healthController;
    void Start()
    {
        healthController = GetComponent<EnemyHealthController>();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag.Equals("Bullet")){
            // //print("Enemy OnTriggerEnter2D");
            BulletStats bulletStats = other.GetComponent<BulletStats>();
            if (bulletStats != null){
                float dmg = bulletStats.dmg;
                healthController.TakeDamage(dmg);
            }
        }
    }
}
