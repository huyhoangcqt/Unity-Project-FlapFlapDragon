using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagePoint : MonoBehaviour
{
    public int rage = 5;
    public float speed = 5f;
    private RageController rageController;
    private Rigidbody2D body;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        body.velocity = Vector3.up * speed;

        GameObject rageBar = GameObject.Find("RageBar");
        if (rageBar == null){
            Debug.LogWarning("Missing RageBar");
            return;
        }
        else {
            rageController = rageBar.GetComponent<RageController>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EndingLifeCycle(){
        rageController.RageUp(rage);
        Destroy(gameObject);
    }
}
