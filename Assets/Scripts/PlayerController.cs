using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour {

    public enum FACEDIRECTION { FACELEFT=-1, FACERIGHT=1};

    //which direction is the player facing, left or right
    public FACEDIRECTION Facing = FACEDIRECTION.FACERIGHT;

    // which objects are tagged as ground
    public LayerMask GroundLayer;

    // reference to rigidbody
    private Rigidbody2D ThisBody = null;

    // reference to transform
    private Transform ThisTransform = null;

    // reference to feet collider
    public CircleCollider2D FeetCollider = null;

    // are we touching the ground
    public bool isGrounded = false;

    // what are the main input axis
    public string HorzAxis = "Horizontal";
    public string JumpButton = "Jump";

    // speed variables
    public float MaxSpeed = 50f;
    public float JumpPower = 600f;
    public float JumpTimeOut = 1f;

    // can we jump right now?
    private bool CanJump = true;

    // can we control the player
    public bool CanControl = true;

    public static PlayerController PlayerInstance = null;

    public static float Health
    {
        get
        {
            return _Health;
        }

        set
        {
            _Health = value;

            if (_Health <= 0)
            {
                Die();
            }
        }
    }

    [SerializeField]
    private static float _Health = 100f;


    void Awake()
    {
        // get transform and rigidbody
        ThisTransform = GetComponent<Transform>();
        ThisBody = GetComponent<Rigidbody2D>();

        // set static instance
        PlayerInstance = this;
    }

    // return bool is player on ground
    private bool GetGrounded()
    {
        // check ground
        Vector2 CircleCenter = new Vector2(ThisTransform.position.x, ThisTransform.position.y)+FeetCollider.offset;
        Collider2D[] HitColliders = Physics2D.OverlapCircleAll(CircleCenter, FeetCollider.radius, GroundLayer);
        if (HitColliders.Length > 0) return true;
        return false;
    }

    // flip character direction
    private void FlipDirection()
    {
        Facing = (FACEDIRECTION)((int)Facing * -1f);
        Vector3 LocalScale = ThisTransform.localScale;
        LocalScale.x *= -1f;
        ThisTransform.localScale = LocalScale;
    }

    // engage Jump
    private void Jump()
    {
        // if we are grounded then jump
        if (!isGrounded || !CanJump) return;

        ThisBody.AddForce(Vector2.up * JumpPower);
        CanJump = false;
        Invoke("ActivateJump", JumpTimeOut);
    }

    // activate jump, prevents double jumps
    private void ActivateJump()
    {
        CanJump = true;
    }

    // use fixed update with physics update such as jump, moves
    void FixedUpdate()
    {
        // if we cannot control the character then exit
        if (!CanControl || Health <= 0f) return;

        //update grounded status
        isGrounded = GetGrounded();
        float Horz = CrossPlatformInputManager.GetAxis(HorzAxis);
        ThisBody.AddForce(Vector2.right*Horz*MaxSpeed);

        if (CrossPlatformInputManager.GetButton(JumpButton))
        {
            Jump();
        }

        // clamp velocity
        ThisBody.velocity = new Vector2(Mathf.Clamp(ThisBody.velocity.x, -MaxSpeed,MaxSpeed), Mathf.Clamp(ThisBody.velocity.y, -Mathf.Infinity, JumpPower));

        // flip direction if required 
        if((Horz<0f && Facing !=FACEDIRECTION.FACELEFT) || (Horz>0f && Facing!=FACEDIRECTION.FACERIGHT))
        {
            FlipDirection();
        }
    }

    void OnDestroy()
    {
        PlayerInstance = null;
    }

    static void Die()
    {
        Destroy(PlayerController.PlayerInstance.gameObject);
    }

    // resets player back to defaults
    public static void Reset()
    {
        Health = 100f;
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
