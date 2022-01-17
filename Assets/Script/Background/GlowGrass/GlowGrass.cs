using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlowGrass : MonoBehaviour
{
    private Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void Darken(){
        anim.SetBool("isDarken", true);
    }

    public void Recover(){
        anim.SetBool("isDarken", false);
    }
}
