using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    private int deathLimit = 3;
    private int deathCount = 0;

    private int maxHP = 100;
    private int crrHP = 0;
    public HealthBar healthBar;

    public GameObject healthBarFill;
    private Animator healthBarAnim, playerAnim;
    [SerializeField] private Stats stats;
    // Start is called before the first frame update
    void Start()
    {
        maxHP = stats.hp;
        crrHP = maxHP;
        healthBar.SetMaxHealth(maxHP);
        healthBar.SetCurrentHealth(crrHP);

        healthBarAnim = healthBarFill.gameObject.GetComponent<Animator>();
        playerAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (crrHP <= 0){
            GeneralInfor.isDead = true;
            GeneralInfor.deadCount += 1;

            playerAnim.SetBool("isDie", true);
        }
    }

    // //Move to in popup, click Revive
    // private void Revive(){
    //     if (deathCount > deathLimit){
    //         //ExitRound();
    //     }
    //     else {
    //         transform.position = CheckPoint.GetLastPosition();
    //         //Enemies, Serializer, stats
    //     }
    // }

    public void RecoveryHealth(int hp){
        crrHP += hp;
        if (crrHP > maxHP){
            crrHP = maxHP;
        }
        healthBar.SetCurrentHealth(crrHP);
    }

    public void TakeDamage(int dmg){
        crrHP -= dmg;
        if (crrHP < 0){
            crrHP = 0;
        }
        healthBar.SetCurrentHealth(crrHP);

        healthBarAnim.SetBool("isTakeDmg", true);
        Debug.Log("Target Dmg: " + dmg);
    }

    public int getCurrentHealthPoint(){
        return crrHP;
    }
}
