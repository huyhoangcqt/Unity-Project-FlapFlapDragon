using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmberSkillManager : Singleton<EmberSkillManager>
{
    [SerializeField] private float bulletSpeed;

    //Shooting variables
    [SerializeField] private GameObject bulletSrc;
    [SerializeField] private GameObject bullet;

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
    }

    public void OnEmberEnd(){
        anim.SetBool("isAttack", false);
        head.transform.rotation = temp_rotation;
    }
}
