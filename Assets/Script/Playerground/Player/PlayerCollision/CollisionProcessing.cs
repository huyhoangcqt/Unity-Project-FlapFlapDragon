using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionProcessing : MonoBehaviour
{
    public GameObject blood;
    private HealthController healthController;
    // Start is called before the first frame update
    private int objectGUID = 0;
    void Start()
    {
        healthController = GetComponent<HealthController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Enemy" || other.gameObject.tag == "Obstacle"){
            StartCoroutine(ReCollisionWaiting1s());
            int temp = other.gameObject.GetInstanceID();
            if (temp == objectGUID){
                return;
            }
            objectGUID = temp;
            Stats stat = other.gameObject.GetComponent<Stats>();
            int dmg = 0;
            if (stat != null){
                dmg = stat.dmg;
            }
            healthController.TakeDamage(dmg);
            //Add blood effect
            SpawnBloodEffect();
        }
        else if (other.gameObject.tag == "CheckPoint"){
            int temp = other.gameObject.GetInstanceID();
            if (temp != objectGUID){
                CheckPoint.SavedPosition(other.transform.position);
                objectGUID = temp;
            }
        }
    }

    private void SpawnBloodEffect(){
        Instantiate(blood, transform.position, Quaternion.identity);
    }

    private IEnumerator ReCollisionWaiting1s(){
        yield return new WaitForSeconds(1f);
        objectGUID = 0;
    }
}
