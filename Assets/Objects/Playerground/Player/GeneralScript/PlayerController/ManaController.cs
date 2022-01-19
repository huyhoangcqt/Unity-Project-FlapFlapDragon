using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaController : MonoBehaviour
{
    private int maxMP = 100;
    private int crrMP = 0;
    public ManaBar manaBar;

    public GameObject manaBarFill;
    private Animator manaBarAnim, playerAnim;
    public Stats stats;
    // Start is called before the first frame update
    void Start()
    {
        maxMP = stats.mp;
        crrMP = maxMP;
        manaBar.SetMaxMana(maxMP);
        manaBar.SetCurrentMana(crrMP);

        manaBarAnim = manaBarFill.gameObject.GetComponent<Animator>();
        playerAnim = GetComponent<Animator>();
    }

    public void RecoveryMana(int mp){
        crrMP += mp;
        if (crrMP > maxMP){
            crrMP = maxMP;
        }
        manaBar.SetCurrentMana(crrMP);
        // manaBarAnim.SetBool("isRecoverMp", true);
    }

    public void ConsumeMana(int mp){
        crrMP -= mp;
        if (crrMP < 0){
            crrMP = 0;
        }
        manaBar.SetCurrentMana(crrMP);
        Debug.Log("Consume Mana: " + mp);
    }

    public int getCurrentManaPoint(){
        return crrMP;
    }
}
