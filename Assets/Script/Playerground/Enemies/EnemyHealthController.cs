using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthController : MonoBehaviour
{
    private float maxHP = 100;
    private float crrHP = 0;
    private HealthBar healthBar;
    private Canvas hbCanvas;
    private Stats stats;
    public GameObject destroyEff, ragePoint;
    // Start is called before the first frame update
    void Start()
    {
        healthBar = transform.GetChild(0).GetChild(0).GetComponent<HealthBar>();
        // Debug.Log("name of line 16: " + transform.GetChild(0).GetChild(0).name);
        hbCanvas = transform.GetChild(0).GetChild(0).GetComponent<Canvas>();
        hbCanvas.enabled = false;

        stats = GetComponent<Stats>();
        maxHP = stats.hp;
        crrHP = maxHP;
        healthBar.SetMaxHealth(maxHP);
        healthBar.SetCurrentHealth(crrHP);
    }

    // Update is called once per frame
    void Update()
    {
        if (crrHP <= 0){
            Instantiate(destroyEff, transform.position, Quaternion.identity);
            Instantiate(ragePoint, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

    public void RecoveryHealth(float hp){
        crrHP += hp;
        if (crrHP > maxHP){
            crrHP = maxHP;
        }
        healthBar.SetCurrentHealth(crrHP);
    }

    public void TakeDamage(float dmg){
        print("Take Damage " + dmg);
        hbCanvas.enabled = true;
        crrHP -= dmg;
        if (crrHP < 0){
            crrHP = 0;
        }
        healthBar.SetCurrentHealth(crrHP);
        
        //If after 1s, don't take damge => hbCanvas.enabled = false;
        StartCoroutine(HealthBarHiding(crrHP));
    }

    public float getCurrentHealthPofloat(){
        return crrHP;
    }

    IEnumerator HealthBarHiding(float crrHPCaching){
        yield return new WaitForSeconds(1.001f);
        if (crrHP == crrHPCaching){
            hbCanvas.enabled = false;
        }
    }
}
