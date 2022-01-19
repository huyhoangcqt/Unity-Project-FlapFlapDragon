using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionColliderActive : MonoBehaviour
{
    private Collider2D[] colliders;
    private bool isCalled = false;
    // Start is called before the first frame update
    private void Start()
    {
        colliders = GetComponentsInChildren<Collider2D>();
    }

    private void Update() {
        if (!isCalled){
            StartCoroutine(ActiveCollider1());
            StartCoroutine(ActiveCollider2());
            isCalled = true;
        }
    }

    IEnumerator ActiveCollider1(){
        yield return new WaitForSeconds(1f);
        print("ActiveCollider1");
        colliders[0].enabled = true;
    }

    IEnumerator ActiveCollider2(){
        yield return new WaitForSeconds(8f);
        print("ActiveCollider2");
        for (int i = 1; i < colliders.Length; i++){
            colliders[i].enabled = true;
        }
    }
}
