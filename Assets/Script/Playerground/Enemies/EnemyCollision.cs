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
        if (other.gameObject.tag == "Bullet"){
            BulletStats bulletStats = other.GetComponent<BulletStats>();
            float dmg = bulletStats.GetDmg();
            healthController.TakeDamage(dmg);
        }

        // if (other.gameObject.tag == "FlameThrow"){  //This method checking in Particle System.
        //     FlameStats flameStats = other.GetComponent<FlameStats>();
        //     float dmg = flameStats.GetDmg();
        //     healthController.TakeDamage(dmg);
        //     // float burnDmg = flameStats.GetBurnDmg();
        //     // StartCoroutine(TakeBurnDamge(burnDmg));
        // }
    }

    // IEnumerator TakeBurnDamge(float dmg){
    //     float time = 0;
    //     float deltaDmg = dmg/5f;
    //     float deltaTime = 1f/5;
    //     while (true){
    //         time += deltaTime;
    //         healthController.TakeDamage(deltaDmg);
    //         yield return new WaitForSeconds(deltaTime);
    //     }
    //     // while (time < duration){
    //     //     time += deltaTime;
    //     //     healthBarController.TakeDamage(deltaDmg);
    //     //     // Debug.Log("Take dmg " + deltaDmg);
    //     //     yield return new WaitForSeconds(deltaTime);
    //     // }
    // }
}
