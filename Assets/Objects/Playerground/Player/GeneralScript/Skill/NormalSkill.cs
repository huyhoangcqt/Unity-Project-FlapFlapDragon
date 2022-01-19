using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalSkill : MonoBehaviour
{
    private bool isActive = true;

    public void SetActive(bool value){
        this.isActive = value;
    }

    //Player;
    private Animator anim;
    // private float shootAngle;
    
    //UI;
    public VariableJoystick variableJoystick;

    //bullet;
    public Transform bulletSource;//Head here
    public GameObject bullet;
    private float bulletSpeed;
    private Vector2 direction, savedDirection;
    
    void Start()
    {
        anim = GetComponent<Animator>();
        // shootAngle = GetComponent<Stats>().shootAngle;
    }

    // Update is called once per frame
    void Update()
    {
        direction = new Vector2(variableJoystick.Horizontal, variableJoystick.Vertical);
        Vector2 zero = new Vector2(0, 0);

        if (! direction.Equals(zero) && isActive){
            //run anim attack
            anim.SetBool("isAttack", true);
            savedDirection = direction;
            //Debug.Log("Direction: " + direction.x + ", " +  direction.y);
        }
        else {
            //stop anim attack;
            anim.SetBool("isAttack", false);
        }
    }

    public void ShootBullet(){
        //Player shooter Angle;
        // float saRadian = shootAngle * Mathf.PI / 180;
        // float saSin = Mathf.Sin(saRadian);
        // float saCos = Mathf.Cos(saRadian);

        Vector2 newDirection = savedDirection;

        GameObject bulletInstance = Instantiate(bullet, bulletSource.position, Quaternion.identity);
        BulletStats bulletStats = bulletInstance.GetComponent<BulletStats>();

        float x = savedDirection.x;
        float y = savedDirection.y;
        float hypotenuse = Mathf.Sqrt(x*x + y*y);
        float cos = Mathf.Abs(x / hypotenuse);
        float degree = Mathf.Acos(cos) * 180 / Mathf.PI;
        while (degree > 180){
            degree -= 180;
        }
        // if (degree > shootAngle){
        //     degree = shootAngle;
        //     newDirection = new Vector2(saCos, saSin);
        //     if (y < 0){
        //         newDirection.y *= -1;
        //     }
        // };
        if (y < 0){
            degree *= -1;
        }
        bulletInstance.transform.rotation = Quaternion.Euler(0, 0, degree);

        float bulletSpeed = bulletStats.speed;
        Vector2 velocity = newDirection * bulletSpeed/newDirection.x;
        bulletInstance.GetComponent<Rigidbody2D>().velocity = velocity;

        
        if (bulletStats != null){
            bulletStats.AssignPlayerDmg(GetComponent<Stats>().dmg);
        }
        else {
        }
    }
}
