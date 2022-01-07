using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmberSkillManager : Singleton<EmberSkillManager>
{
    //Shooting variables
    [SerializeField] private float bulletSpeed;
    [SerializeField] private GameObject bulletSrc, bullet;
    [SerializeField] private ButtonControl button;
    [SerializeField] private float cooldownTime;

    private Animator anim;
    private GameObject head;
    public void Start(){
        anim = GetComponent<Animator>();
        head = GameObject.Find("BabyDragon/Head");
        if (head == null){
            Debug.LogError("Dragon don't exist head");
        }
    }

    // Start is called before the first frame update
    private Quaternion rotation;
    private Vector3 direction;
    public void Process(Touch touch){
        OnEmberStart();

        Vector3 transform_pos = Camera.main.ScreenToWorldPoint(touch.position);
        direction = new Vector3(transform_pos.x, transform_pos.y, 0)
            - bulletSrc.transform.position;
        direction.z = 0;
        direction = direction.normalized;
        rotation = Quaternion.LookRotation(direction, Vector3.right);
        
    }

    public void Shooter(){
        GameObject bullet_instance = Instantiate(bullet, bulletSrc.transform.position, rotation);
        bullet_instance.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
        Destroy(bullet_instance, 2f);
    }

    private Quaternion temp_rotation;
    public void OnEmberStart(){
        anim.SetBool("isAttack", true);
        temp_rotation = head.transform.rotation;
        head.transform.rotation = rotation;

        CooldownStart();
    }

    private  IEnumerator StartCooldown(float time){
        button.UpdateCooldownText(time, "N0");
        while (time > 1f){
            yield return new WaitForSeconds(1f);
            time -= 1f;
            button.UpdateCooldownText(time, "N0");
        }
        while (time > 0f){
            yield return new WaitForSeconds(0.1f);
            time -= 0.1f;
            button.UpdateCooldownText(time, "N1");
        }
        CooldownEnd();
    }

    internal void CooldownEnd(){
        button.ActiveButton();
    }

    private void CooldownStart(){
        button.CooldownEffectStart(cooldownTime);
        StartCoroutine(StartCooldown(cooldownTime));
    }

    public void OnEmberEnd(){
        anim.SetBool("isAttack", false);
        head.transform.rotation = temp_rotation;
    }
}
