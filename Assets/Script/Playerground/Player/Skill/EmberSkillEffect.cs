using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmberSkillEffect : MonoBehaviour
{
    
    [SerializeField] private GameObject bulletSrc, bullet;
    [SerializeField] private float bulletSpeed;
    private Quaternion _rotation;
    public Quaternion rotation { 
        get { return _rotation;}
        set { _rotation = value; }    
    }
    private Animator anim;
    private GameObject head;
    private Quaternion temp_rotation;
    void Start(){
        anim = GetComponent<Animator>();
        head = GameObject.Find("BabyDragon/Head");
        if (head == null){
            Debug.LogError("Dragon don't exist head");
        }
    }

    private Vector3 direction;
    public void Process(Touch touch){
        Vector3 transform_pos = Camera.main.ScreenToWorldPoint(touch.position);
            direction = new Vector3(transform_pos.x, transform_pos.y, 0)
                - bulletSrc.transform.position;
            direction.z = 0;
            direction = direction.normalized;
            rotation = Quaternion.LookRotation(direction, Vector3.right);
    }

    public void OnEmberStart(){
        anim.SetBool("isAttack", true);
        temp_rotation = head.transform.rotation;
        head.transform.rotation = rotation;
    }

    public void OnEmberEnd(){
        anim.SetBool("isAttack", false);
        head.transform.rotation = temp_rotation;
    }

    /*
    * * Called in Animation event;
    */
    public void Shooter(){
        GameObject bullet_instance = Instantiate(bullet, bulletSrc.transform.position, rotation);
        bullet_instance.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
        Destroy(bullet_instance, 2f);
    }
}
