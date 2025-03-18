using System.Collections;
using UnityEngine;
using UnityEngine.UI;


/**
 * * Normal attack
*/
public class EmberSkillManager : Singleton<EmberSkillManager>
{
	private PlayerController mPlayer;
	private EmberSkillEffect emberEffect;
    [SerializeField] private float clipLength; //Default time: 0.15 = duration time of animation Attack
    private bool isAttackCompleted = false;
    private bool onHolding = false;
    private Vector3 touchPos = Vector3.zero;

	/*
	    - à, hiểu rồi: duration là thời gian animation attack của con rồng. Đáng ra phải gán animation clip vào đây, rồi tự lấy "clip length"
	    - Thế thì => bắt đầu start => chạy animation (OnEmberStart), chạy xong animation thì gọi OnEmberEnd();
	    - Cải tiến lại xíu.

        - 2 cách:
        1. OnEmberStart => đánh dấu => OnEmberStart Courtine waitForSecond(clipLength) => OnEmberEnd;
        2. OnEmberStart => OnEmberStart bình thường => đánh dấu.
            Có gắn keyFrame Animation end vào con rồng. // hook đăng ký event on clip Complete (nếu) có
            => gọi về OnEmberEnd
     */


	private void Start()
	{
		mPlayer = GetComponent<PlayerController>();
		emberEffect = GetComponent<EmberSkillEffect>();
        clipLength = 0.15f;
		isAttackCompleted = true;
		onHolding = false;
		touchPos = Vector3.zero;
	}

    private void Update()
    {
		bool isAttackEnabled = mPlayer == null ? false : mPlayer.AttackInputEnabled;
		Debug.Log($"[EmberSkillManager] isAttackEnabled: {isAttackEnabled} -  onHolding: {onHolding} - isAttackCompleted: {isAttackCompleted}");

		if (isAttackEnabled && onHolding && isAttackCompleted)
        {
            StartEmber();
        }
    }


	// Start is called before the first frame update
	public void TryAttack(Vector3 touchPos, bool isDown)
	{
		this.touchPos = touchPos;
		if (isDown)
		{
			onHolding = true;
		}
		else
		{
			onHolding = false;
		}
	}

	public void StartEmber()
	{
		emberEffect.Process(touchPos);
		OnEmberStart();
	}

    protected void OnEmberStart(){
		isAttackCompleted = false;
        emberEffect.OnEmberStart();

		StartCoroutine(_WaitUntilAnimationEnd(clipLength));
	}

    private IEnumerator _WaitUntilAnimationEnd(float clipLength)
    {
        yield return new WaitForSeconds(clipLength);
        OnEmberEnd();
    }

	protected void OnEmberEnd()
	{
		emberEffect.OnEmberEnd();
		isAttackCompleted = true;
	}
}
