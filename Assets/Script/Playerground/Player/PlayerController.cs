using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerStatus{
    Invincible,
    Normal,
    Inactive,
}

public class PlayerController : MonoBehaviour
{
    private PlayerStatus _status;
    public PlayerStatus status{
        get { return _status; }
        set { 
            _status = value; 
            print("player status change " + status);
        }
    }

    public static bool onGround = false;
    private bool inputEnabled = true;
    private Animator anim;
    // public TutorialManager tutorialManager;

    public float jumpForce, moveForce, deltaTime; //deltaTime must be >= Time.deltaTime;
    public float additionalJumpForce, additionalMoveForce;

    private float duration;
    private float tempJumpForce, tempMoveForce;
    private float subJumpForce, subMoveForce;
    private bool isHoldingOnLeft;

    [SerializeField]private float dashForce, dragForce;

    private Rigidbody2D rgbd2D;
    // Start is called before the first frame update
    private void Start()
    {
        rgbd2D = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>(); 
        InitializeParameters();
    }

    private void InitializeParameters(){
        onGround = false;
        status = PlayerStatus.Inactive;
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
    private void Update()
    {
        InputDectection();
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

    public void EnableInputGetting(){
        inputEnabled = true;
    }

    public void DisableInputGetting(){
        inputEnabled = false;
    }

    void InputDectection(){
        if (inputEnabled){
            if (Input.touchCount > 0){
                Touch[] myTouches = Input.touches;
                foreach (Touch touch in myTouches){
                    /* 
                    * * If Touch on left side*/
                    if (touch.position.x < Screen.width *2/5){
                        if (touch.phase == TouchPhase.Began){
                            //process here;
                            isHoldingOnLeft = true;
                            status = PlayerStatus.Normal;
                            anim.SetBool("isActive", true);

                            // tutorialManager.SetIndex(-1);//Passed step 1;
                            
                            //Set Force;
                            tempJumpForce = jumpForce;
                            tempMoveForce = moveForce;
                            rgbd2D.velocity = new Vector2(0, 0);
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
                            EmberSkillManager.instance.Process(touch);
                        }
                    }
                };
            }
        }
    }

    void Moving(){
        if (status == PlayerStatus.Normal){
            rgbd2D.AddForce(new Vector2(tempMoveForce, tempJumpForce));
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

    private float tempGravityScale;
    public void PreDashMovement(){
        DisableInputGetting();

        rgbd2D.velocity = Vector3.zero;
        tempGravityScale = rgbd2D.gravityScale;
        rgbd2D.gravityScale = 0f;

        rgbd2D.AddForce(new Vector2(50, 0f));
    }

    public void DashMovementOn(){
        rgbd2D.AddForce(new Vector2(dashForce, 0f));
    }

    public void DashMovementOff(){
        EnableInputGetting();

        rgbd2D.gravityScale = tempGravityScale;
    }

    public void DashMovementLastMove(){
        rgbd2D.AddForce(new Vector2 (-dragForce, 0f));
    }
}
