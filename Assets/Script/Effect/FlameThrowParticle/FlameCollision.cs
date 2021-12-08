using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameCollision : MonoBehaviour
{
    private ParticleSystem ps;
    List<ParticleSystem.Particle> enter = new List<ParticleSystem.Particle>();

    // Start is called before the first frame update
    void Start()
    {
        ps = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
