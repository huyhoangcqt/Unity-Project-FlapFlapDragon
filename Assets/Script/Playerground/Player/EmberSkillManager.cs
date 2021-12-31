using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmberSkillManager : Singleton<EmberSkillManager>
{
    [SerializeField] private float bulletSpeed;

    //Shooting variables
    [SerializeField] private GameObject bulletSrc;
    [SerializeField] private GameObject bullet;

    // Start is called before the first frame update

    public void Process(Touch touch){
        Vector3 transform_pos = Camera.main.ScreenToWorldPoint(touch.position);
        Vector3 direction = new Vector3(transform_pos.x, transform_pos.y, 0)
            - bulletSrc.transform.position;
        direction.z = 0;
        direction = direction.normalized;

        Quaternion rotation = Quaternion.LookRotation(direction, Vector3.right);

        // rotation = Quaternion.Euler(0, 30, 0);
        // print(rotation);

        GameObject bullet_instance = Instantiate(bullet, bulletSrc.transform.position, rotation);
        bullet_instance.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
        Destroy(bullet_instance, 2f);
    }
}
