using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
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
            //print("player status change " + status);
        }
    }

	public bool AttackInputEnabled { get => attackInputEnabled; set => attackInputEnabled = value; }
	public bool InputEnabled { get => inputEnabled; set => inputEnabled = value; }

	public static bool onGround = false;
    private bool attackInputEnabled = true, inputEnabled = true;
    private Animator anim;
    // public TutorialManager tutorialManager;

    public float jumpForce, moveForce, deltaTime; //deltaTime must be >= Time.deltaTime;
    public float additionalJumpForce, additionalMoveForce;

    private float tempJumpForce, tempMoveForce;
    private float subJumpForce, subMoveForce;
    private float holdingDuration;
    private bool isHoldingOnLeft;

    [SerializeField]private float dashForce, dragForce;
    private EmberSkillManager emberSkillManager;
    private Rigidbody2D rgbd2D;
    private float tempGravityScale;
    
    private void Start()
    {
        rgbd2D = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>(); 
        emberSkillManager = GetComponent<EmberSkillManager>();
        InitializeParameters();
    }

    private void InitializeParameters(){
        status = PlayerStatus.Inactive;
        anim.SetBool("isActive", true);
        
        //Step 1
        // tutorialManager.SetIndex(0);

        holdingDuration = 0f;
        isHoldingOnLeft = false;
        subJumpForce = additionalJumpForce * 0.1f;
        subMoveForce = additionalMoveForce * 0.1f;
        if (deltaTime < Time.deltaTime){
            deltaTime = Time.deltaTime;
        }
    }

    private void Update()
    {
        InputDectection();
        OnHoldingLeftSide();
    }

    /**
     * * Input Dection
    */
    private void OnHoldingLeftSide(){
        if (isHoldingOnLeft){
            holdingDuration += Time.deltaTime;
            if (holdingDuration >= deltaTime){
                holdingDuration -= deltaTime;
                Moving();
            }
        }
    }

    void InputDectection(){
        if (inputEnabled && !PauseController.isPaused)
		{
#if UNITY_EDITOR
			if (EventSystem.current.IsPointerOverGameObject())
			{
                return;
			}

			//Process Moving
			if (Input.GetKeyDown(KeyCode.Space))
            {
                isHoldingOnLeft = true;
                status = PlayerStatus.Normal;
                anim.SetBool("isIdle", false); //onGround = false;

                // tutorialManager.SetIndex(-1);//Passed step 1;

                //Set Force;
                tempJumpForce = jumpForce;
                tempMoveForce = moveForce;
                rgbd2D.velocity = new Vector2(0, 0);
                Moving();
                tempJumpForce = additionalJumpForce;
                tempMoveForce = additionalMoveForce;
            }

            if (Input.GetKeyUp(KeyCode.Space))
            {
                isHoldingOnLeft = false;
                holdingDuration = 0f;
            }


            //Process left mouse clicked => Shooter
            if (Input.GetMouseButtonDown(0))
            {
                var clickPos = Input.mousePosition;
                if (attackInputEnabled)
                {
                    emberSkillManager.TryAttack(clickPos, isDown: true);
                    
                }
            }

            if (Input.GetMouseButtonUp(0))
            {
                var clickPos = Input.mousePosition;
                emberSkillManager.TryAttack(clickPos, isDown: false);
            }



#elif UNITY_ANDROID || UNITY_IOS
            if (Input.touchCount > 0){


                Touch[] myTouches = Input.touches;
                foreach (Touch touch in myTouches){
					/* 
                    * * If Touch on left side => Movement
                    */

					if (EventSystem.current.IsPointerOverGameObject(touch.fingerId))
					{
                        return;
					}

					if (touch.position.x < Screen.width *2/5){
                        if (touch.phase == TouchPhase.Began){
                            isHoldingOnLeft = true;
                            status = PlayerStatus.Normal;
                            anim.SetBool("isIdle", false); //onGround = false;

                            // tutorialManager.SetIndex(-1);//Passed step 1;
                            
                            //Set Force;
                            tempJumpForce = jumpForce;
                            tempMoveForce = moveForce;
                            rgbd2D.velocity = new Vector2(0, 0);
                            Moving();
                            tempJumpForce = additionalJumpForce;
                            tempMoveForce = additionalMoveForce;
                        }
                        if (touch.phase == TouchPhase.Ended){
                            isHoldingOnLeft = false;
                            holdingDuration = 0f;
                        } 
                    }
                    //If Touch at right side => shooting
                    else {
						if (touch.phase == TouchPhase.Began)
						{
						    emberSkillManager.TryAttack(touch.position, isDown: true);
						}
                        else if (touch.phase == TouchPhase.Ended)
						{ 
						    emberSkillManager.TryAttack(touch.position, isDown: false);
						}
                    }
                };
            }
#endif
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.transform.tag.Equals("Ground")){
            anim.SetBool("isIdle", true);
        }
    }

    /**
     * * Enable, Disable
    */
    public void EnableAttack(){
        attackInputEnabled = true;
    }

    public void DisableAttack(){
        attackInputEnabled = false;
    }

    public void EnabledInputGetting(){
        inputEnabled = true;
    }
    public void DisableInputGetting(){
        inputEnabled = false;
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
}
