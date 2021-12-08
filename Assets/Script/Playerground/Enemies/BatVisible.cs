using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatVisible : MonoBehaviour
{
    private bool isVisible = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnBecameVisible() {
        isVisible = true;
    }
    private void OnBecameInvisible() {
        isVisible = false;
    }

    public bool GetIsVisible(){
        return isVisible;
    }
}
