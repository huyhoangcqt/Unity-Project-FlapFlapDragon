using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static bool onGround = false, isActive = false;
    private Animator anim;
    // public TutorialManager tutorialManager;

    public float jumpForce, moveForce, deltaTime; //deltaTime must be >= Time.deltaTime;
    public float additionalJumpForce, additionalMoveForce;

    private float duration;
    private float tempJumpForce, tempMoveForce;
    private float subJumpForce, subMoveForce;

    private bool isHoldingOnLeft;


    Rigidbody2D body;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        InitializeParameters();
    }

    private void InitializeParameters(){
        onGround = false;
        isActive = false;
        anim.SetBool("isActive", false);
        
        //Step 1
        // tutorialManager.SetIndex(0);

        duration = 0f;
        isHoldingOnLeft = false;
        subJumpForce = additionalJumpForce * 0.1f;
        subMoveForce = additionalMoveForce * 0.1f;
        if (deltaTime < Time.deltaTime){
            deltaTime = Time.deltaTime;
        }
    }

    // Update is called once per frame
    void Update()
    {
        TouchDetection();
        OnHoldingLeftSide();
        // if (CheckingFirstEnemyAppear()){
        //     OnFirstEnemyAppear();
        // }
    }

    private bool CheckingFirstEnemyAppear(){
        return true;
    }

    public void OnFirstEnemyAppear(){
        // tutorialManager.SetIndex(1);
    }

    private void OnHoldingLeftSide(){
        if (isHoldingOnLeft){
            duration += Time.deltaTime;
            if (duration >= deltaTime){
                duration -= deltaTime;
                Moving();
            }
        }
    }

    void TouchDetection(){
        if (Input.touchCount > 0){
            Touch[] myTouches = Input.touches;
            foreach (Touch touch in myTouches){
                //If Touch at left side
                if (touch.position.x < Screen.width/2){
                    if (touch.phase == TouchPhase.Began){
                        //process here;
                        isHoldingOnLeft = true;
                        isActive = true;
                        anim.SetBool("isActive", isActive);

                        // tutorialManager.SetIndex(-1);//Passed step 1;
                        
                        //Set Force;
                        tempJumpForce = jumpForce;
                        tempMoveForce = moveForce;
                        body.velocity = new Vector2(0, 0);
                        Moving();
                        tempJumpForce = additionalJumpForce;
                        tempMoveForce = additionalMoveForce;

                        //OnGround;
                        onGround = false;
                        anim.SetBool("isIdle", false);
                    }
                    if (touch.phase == TouchPhase.Ended){
                        isHoldingOnLeft = false;
                        duration = 0f;
                    }   
                }
                //If Touch at right side => shooting
                else {
                    if (touch.phase == TouchPhase.Ended){
                        EmberSkillManager.Instance.Process(touch);
                    }
                }
            };
            
        }
    }

    void Moving(){
        if (isActive){
            body.AddForce(new Vector2(tempMoveForce, tempJumpForce));
            tempJumpForce -= subJumpForce;
            tempMoveForce -= subMoveForce;

            if (tempJumpForce < 0){
                tempJumpForce = 0;
            }
            if (tempMoveForce < 0){
                tempMoveForce = 0;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Ground"){
            onGround = true;
            anim.SetBool("isIdle", onGround);
        }
    }
}
