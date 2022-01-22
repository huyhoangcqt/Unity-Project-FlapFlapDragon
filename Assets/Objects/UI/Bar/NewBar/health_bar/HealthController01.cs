using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController01 : MonoBehaviour
{
    [SerializeField] private HealthBar01 healthBar;
    [SerializeField] int hp;

    void Start() {
        healthBar.SetMaxHealth((float)hp);
    }

    private void Update() {
        if (Input.GetMouseButtonDown(0)){
            healthBar.TakeDamage(Random.Range(2, 20));
        };
        if (Input.GetMouseButtonDown(1)){
            healthBar.RestoreHealth(Random.Range(2,20));
        }
    }
}
