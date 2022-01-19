using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleCollision : MonoBehaviour
{
    public GameObject _PSFire;
    private EnemyHealthController healthBarController;
    // Start is called before the first frame update
    void Start()
    {
        healthBarController = GetComponent<EnemyHealthController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Bullet"){
            // Debug.Log("Bullet");
            BulletStats bulletStat = other.GetComponent<BulletStats>();
            if (bulletStat == null){
                Debug.Log("Stats null reperences");
            }
            else {
                string ele = bulletStat.element;    
                if (ele == "Fire"){
                    // Take Burn damge per second;
                    float burnDps = bulletStat.burnDps;
                    float duration = bulletStat.duration;
                    StartCoroutine(TakeBurnDamge(burnDps, duration));
                    
                    // Make burn effect;
                    GameObject fire = Instantiate(_PSFire, other.transform.position, Quaternion.identity);
                    fire.transform.SetParent(transform);
                    fire.GetComponent<BurnFireController>().SetDuration(duration);
                }
            }
        }        
    }

    IEnumerator TakeBurnDamge(float dmg, float duration){
        float time = 0;
        float deltaDmg = dmg/5f;
        float deltaTime = 1f/5;
        while (time < duration){
            time += deltaTime;
            healthBarController.TakeDamage(deltaDmg);
            // Debug.Log("Take dmg " + deltaDmg);
            yield return new WaitForSeconds(deltaTime);
        }
    }
}
