using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabyDragonShowCase : MonoBehaviour
{
    [SerializeField] private float duration, timeToThrowing, startTime;
    [SerializeField] private GameObject bulletSrc, flameThrow, flameAfter;
    private float deltaTime;
    private Animator anim;

    void Start()
    {
        deltaTime = 0f;
        anim = GetComponent<Animator>();
        StartCoroutine(FirstFlameThrowingIE(startTime));
    }

    IEnumerator FirstFlameThrowingIE(float time){
        yield return new WaitForSeconds(time);
        Throwing();
    }

    void Update()
    {
        if (deltaTime >= timeToThrowing){
            Throwing();
            deltaTime = 0f;
        }
        deltaTime += Time.deltaTime;
    }

    //called in Animation: StartThrow
    private GameObject flame_instance, flame_after;
    public void StartThrowing(){
        Quaternion rotation = Quaternion.Euler(0, 0, 0);
        flame_instance = Instantiate(flameThrow, bulletSrc.transform.position, rotation);
        flame_after = Instantiate(flameAfter, bulletSrc.transform.position, rotation);
        FireLight.instance.Lighten();
    }

    private void Throwing(){
        anim.SetBool("isThrowing", true);
        StartCoroutine(ThrowingIE(duration));
    }

    IEnumerator ThrowingIE(float duration){
        yield return new WaitForSeconds(0.5f);
        anim.SetBool("isThrowingCompleted", true);
        yield return new WaitForSeconds(duration);
        anim.SetBool("isThrowing", false);
        anim.SetBool("isThrowingCompleted", false);
        Destroy(flame_instance);
        FireLight.instance.Darken();
        yield return new WaitForSeconds(0.5f);
        Destroy(flame_after);
    }

}
