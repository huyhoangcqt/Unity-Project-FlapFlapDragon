using System.Collections;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public GameObject blood;
    private PlayerController pController;
    private int objectGUID = 0;
    private PlayerStatus status;
    void Start()
    {
        pController = GetComponent<PlayerController>();
        status = pController.status;
    }

    void Update(){
        status = pController.status;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Enemy" || other.gameObject.tag == "Obstacle"){
            // print("Player is collising");
            if (status == PlayerStatus.Normal){
                // print("Player is collising with normal status");
                StartCoroutine(ReCollisionWaiting1s());
                //Make collision only 1 time with an object.
                int temp = other.gameObject.GetInstanceID();
                if (temp == objectGUID){
                    return;
                }
                objectGUID = temp;
                //caculator dmg
                Stats stat = other.gameObject.GetComponent<Stats>();
                int dmg = 0;
                if (stat != null){
                    dmg = stat.dmg;
                }
                HealthController.instance.TakeDamage(dmg);
                //Add blood effect
                SpawnBloodEffect();
            }
        }
        /*
        * * Important: Save Point - backup
        */
        // else if (other.gameObject.tag == "CheckPoint"){
        //     int temp = other.gameObject.GetInstanceID();
        //     if (temp != objectGUID){
        //         CheckPoint.SavedPosition(other.transform.position);
        //         objectGUID = temp;
        //     }
        // }
    }

    private void SpawnBloodEffect(){
        Instantiate(blood, transform.position, Quaternion.identity);
    }

    private IEnumerator ReCollisionWaiting1s(){
        yield return new WaitForSeconds(1f);
        objectGUID = 0;
    }
}
