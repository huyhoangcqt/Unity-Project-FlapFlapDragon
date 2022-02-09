using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCollision : MonoBehaviour
{
    private Collider2D col;
    private bool isCalled = false;
    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<Collider2D>();
    }

    private void Update() {
        if (!isCalled){
            StartCoroutine(ActiveCollider());
            isCalled = true;
        }
    }

    IEnumerator ActiveCollider(){
        yield return new WaitForSeconds(2f);
        //print("Collider Active");
        col.enabled = true;
    }
}
