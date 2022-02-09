using System.Collections;
// using System.Collections.Generic;
using UnityEngine;

public class ExplosionController : MonoBehaviour
{
    private Rigidbody2D rgbd2D;
    [SerializeField]private float speed, duration;
    [SerializeField] private GameObject player;
    private Vector3 distanceToPlayer = new Vector3(1.41f, 0.21f, 5f);
    private Animator anim;

    GameObject FindGameObject(string objectName){
        GameObject result = GameObject.Find(objectName);
        if (result == null){
            Debug.LogError("Could not find object '" + objectName + "';");
            return null;
        }
        else return result;
    }

    public void Awake(){
        player = FindGameObject("BabyDragon");
        transform.position = player.transform.position + distanceToPlayer;
        Destroy(gameObject, 12f);
        anim = GetComponent<Animator>();
    }

    public void Start(){
        rgbd2D = GetComponent<Rigidbody2D>();
        MoveOn();
    }

    public void MoveOn(){
        StartCoroutine(Movement());
    }

    private Vector2 vector2Zero = new Vector2(0, 0);
    IEnumerator Movement(){
        rgbd2D.velocity = vector2Zero;
        yield return new WaitForSeconds(2f);
        rgbd2D.velocity = new Vector2(speed/2, 0f);
        yield return new WaitForSeconds(0.5f);
        rgbd2D.velocity = new Vector2(speed, 0f);
        yield return new WaitForSeconds(2f);
        rgbd2D.velocity = new Vector2(speed/2, 0f);
        yield return new WaitForSeconds(0.5f);
        rgbd2D.velocity = vector2Zero;
    }
}
