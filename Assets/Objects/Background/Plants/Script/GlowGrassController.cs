using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlowGrassController : Singleton<GlowGrassController>
{
    private GlowGrass[] glowGrasses;
    // Start is called before the first frame update
    void Start()
    {
        glowGrasses = transform.GetComponentsInChildren<GlowGrass>();
    }

    public void Darken(){
        foreach (GlowGrass gg in glowGrasses){
            gg.Darken();
        }
    }

    public void Recover(){
        foreach (GlowGrass gg in glowGrasses){
            gg.Recover();
        }
    }
}
