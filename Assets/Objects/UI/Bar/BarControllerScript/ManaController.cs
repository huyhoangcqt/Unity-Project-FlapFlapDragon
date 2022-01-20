using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaController : MonoBehaviour
{
    private int maxMP = 100;
    private int crrMP = 0;
    [SerializeField] private ManaBar manaBar;
    private Animator manaBarAnim;
    [SerializeField]private Stats stats;        //stats of target

    // Start is called before the first frame update
    void Start()
    {
        maxMP = stats.mp;
        crrMP = maxMP;
        manaBar.SetMaxMana(maxMP);
        manaBar.SetCurrentMana(crrMP);

        manaBarAnim = manaBar.gameObject.GetComponent<Animator>();
    }

    public void RecoveryMana(int mp){
        crrMP += mp;
        if (crrMP > maxMP){
            crrMP = maxMP;
        }
        manaBar.SetCurrentMana(crrMP);
        manaBarAnim.SetBool("isRecover", true);
        StartCoroutine(RecoveryAnimationEnd());
    }

    private IEnumerator RecoveryAnimationEnd(){
        yield return new WaitForSeconds(0.2f); //default time for mp recover animation
        manaBarAnim.SetBool("isRecover", false);
    }

    public void ConsumeMana(int mp){
        crrMP -= mp;
        if (crrMP < 0) crrMP = 0;
        manaBar.SetCurrentMana(crrMP);
        Debug.Log("Consume Mana: " + mp);
    }

    public bool CheckingMana(int mp){
        if (crrMP >= mp){
            return true;
        }
        else {
            return false;
        }
    } 
}
