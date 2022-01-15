using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleController : MonoBehaviour
{
    private ParticleSystem[] particleSystems;
    // Start is called before the first frame update
    void Start()
    {
        particleSystems = gameObject.GetComponentsInChildren<ParticleSystem>();
    }

    public void Play(){
        if (particleSystems != null && particleSystems.Length > 0){
            foreach (ParticleSystem particleSystem in particleSystems){
                particleSystem.Play();
            }
        }
    }

    public void Stop(){
        foreach (ParticleSystem particleSystem in particleSystems){
            particleSystem.Stop();
        }
    }

    public void Restart(){
        Stop();
        Play();
    }
}
