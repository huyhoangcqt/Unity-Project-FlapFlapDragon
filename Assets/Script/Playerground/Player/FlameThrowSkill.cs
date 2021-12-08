using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlameThrowSkill : MonoBehaviour
{
    private Animator anim;
    private Button btn;

    public GameObject flameEffect;
    private GameObject flameInstance;

    private NormalSkill normalAtkController; 
    public Vector3 distance;

    private RageController rageController;
    private bool isThrowing = false;
    private float deltaTime;
    private float duringTime;
    public float duration = 10f;
    private float desRageAmount;

    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("BabyDragon");

        anim = GetComponent<Animator>();
        normalAtkController = GetComponent<NormalSkill>();

        GameObject rageBar = GameObject.Find("RageBar");
        if (rageBar == null){
            Debug.LogWarning("Missing RageBar");
            return;
        }
        else {
            rageController = rageBar.GetComponent<RageController>();
        }

        deltaTime = Time.deltaTime;
        float multi = duration/ deltaTime;
        desRageAmount = rageController.GetMaxRage() / multi;
    }

    // Update is called once per frame
    void Update()
    {
        if (isThrowing){
            Throwing();
        }
    }

    public void StartThrowing(){
        flameInstance = Instantiate(flameEffect, transform.position + distance, flameEffect.transform.rotation);
        flameInstance.GetComponent<FlameStats>().AssignPlayerDmg( player.GetComponent<Stats>().dmg );

        //normal attack set inActive;
        normalAtkController.SetActive(false);

        isThrowing = true;
        duringTime = 0;
    }

    private void Throwing(){
        
        if (EndTime()){
            anim.SetBool("isThrowing", false);
        }
        else {
            duringTime += deltaTime;

            //rageController
            rageController.RageDown(desRageAmount);
        }
    }

    private bool EndTime(){
        if (duringTime >= duration){
            return true;
        }
        return false;
    }

    public void EndThrowing(){
        isThrowing = false;

        Destroy(flameInstance.gameObject);

        normalAtkController.SetActive(true);
    }

}
