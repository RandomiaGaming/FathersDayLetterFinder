using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Player_Animator))]
public class Player : MonoBehaviour
{
    public static Vector2 CheckPointPos;
    private Rigidbody2D RB;
    private Player_Animator PA;
    private Ground_Checker GC;
    [Header("Movement")]
    public float Move_Force = 10;
    public float Max_Move_Force = 7;
    public float Turn_Around_Force = 20;
    public float Turn_Around_Threshold = 0.5f;
    public float Start_Up_Force = 15;
    public float Start_Up_Threshold = 1;
    public float Jump_Force = 10;
    public float Drag_Force = 5;
    void Start()
    {
        CheckPointPos = transform.position;
        RB = GetComponent<Rigidbody2D>();
        PA = GetComponent<Player_Animator>();
        GC = GetComponentInChildren<Ground_Checker>();
    }
    void Update()
    {
        //Movement
        if (Input.GetKey(KeyCode.D))
        {
            if (RB.velocity.x < -Turn_Around_Threshold)
            {
                RB.velocity += new Vector2(Turn_Around_Force, 0) * Time.deltaTime;
            }
            else if (RB.velocity.x < Start_Up_Threshold)
            {
                RB.velocity += new Vector2(Start_Up_Force, 0) * Time.deltaTime;
            }
            else
            {
                RB.velocity += new Vector2(Move_Force, 0) * Time.deltaTime;
            }
        }
        else if (Input.GetKey(KeyCode.A))
        {
            if (RB.velocity.x > Turn_Around_Threshold)
            {
                RB.velocity -= new Vector2(Turn_Around_Force, 0) * Time.deltaTime;
            }
            else if (RB.velocity.x > -Start_Up_Threshold)
            {
                RB.velocity -= new Vector2(Start_Up_Force, 0) * Time.deltaTime;
            }
            else
            {
                RB.velocity -= new Vector2(Move_Force, 0) * Time.deltaTime;
            }
        }
        else
        {
            if (RB.velocity.x > 0)
            {
                RB.velocity -= new Vector2(Drag_Force, 0) * Time.deltaTime;
                RB.velocity = new Vector2(Mathf.Clamp(RB.velocity.x, 0, float.MaxValue), RB.velocity.y);
            }
            else if (RB.velocity.x < 0)
            {
                RB.velocity += new Vector2(Drag_Force, 0) * Time.deltaTime;
                RB.velocity = new Vector2(Mathf.Clamp(RB.velocity.x, float.MinValue, 0), RB.velocity.y);
            }
        }
        //Velocity Clamp
        RB.velocity = new Vector2(Mathf.Clamp(RB.velocity.x, -Max_Move_Force, Max_Move_Force), RB.velocity.y);
        //Jumping
        if (Input.GetKeyDown(KeyCode.Space) && GC.Grounded)
        {
            RB.velocity = new Vector2(RB.velocity.x, Jump_Force);
        }

        //Animations
        if (!GC.Grounded && RB.velocity.y >= 0)
        {
            PA.Animation_State = Player_Animator.Player_Animation_State.Jump_Up;
        }
        else if (!GC.Grounded && RB.velocity.y < 0)
        {
            PA.Animation_State = Player_Animator.Player_Animation_State.Jump_Down;
        }
        else if (GC.Grounded && Mathf.Abs(RB.velocity.x) > 0.25f)
        {
            PA.Animation_State = Player_Animator.Player_Animation_State.Run;
        }
        else
        {
            PA.Animation_State = Player_Animator.Player_Animation_State.Idle;
        }

        //Scale
        if (RB.velocity.x > 0.25f)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (RB.velocity.x < -0.25f)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Hazzard")
        {
            transform.position = CheckPointPos;
            RB.velocity = Vector2.zero;
        }
    }
}
