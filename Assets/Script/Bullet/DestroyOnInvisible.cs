using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnInvisible : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnBecameInvisible() {
        GameObject parent = transform.parent.gameObject;
        Destroy(parent);
    }
}
