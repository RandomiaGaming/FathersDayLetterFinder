using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(SpriteRenderer))]
public class Player_Animator : MonoBehaviour
{
    public enum Player_Animation_State { Idle, Jump_Up, Run, Jump_Down };
    public Player_Animation_State Animation_State = Player_Animation_State.Idle;
    private float Animation_Timer = 0;
    private int Sprite_Index = 0;
    private SpriteRenderer SR;

    public List<Sprite> Idle_Sprites;
    public List<Sprite> Run_Sprites;
    public Sprite Jump_Up;
    public Sprite Jump_Down;

    void Start()
    {
        SR = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        if (Animation_State == Player_Animation_State.Run)
        {
            Animation_Timer += Time.deltaTime;
            while (Animation_Timer > 0.1f)
            {
                Animation_Timer -= 0.1f;
                Sprite_Index += 1;
            }
            while (Sprite_Index >= Run_Sprites.Count)
            {
                Sprite_Index -= Run_Sprites.Count;
            }
            SR.sprite = Run_Sprites[Sprite_Index];
        }
        else if (Animation_State == Player_Animation_State.Idle)
        {
            Animation_Timer += Time.deltaTime;
            while (Animation_Timer > 0.1f)
            {
                Animation_Timer -= 0.1f;
                Sprite_Index += 1;
            }
            while (Sprite_Index >= Idle_Sprites.Count)
            {
                Sprite_Index -= Idle_Sprites.Count;
            }
            SR.sprite = Idle_Sprites[Sprite_Index];
        }
        else if (Animation_State == Player_Animation_State.Jump_Up)
        {
            SR.sprite = Jump_Up;
            Animation_Timer = 0;
            Sprite_Index = 0;
        }
        else if (Animation_State == Player_Animation_State.Jump_Down)
        {
            SR.sprite = Jump_Down;
            Animation_Timer = 0;
            Sprite_Index = 0;
        }
        else
        {
            SR.sprite = null;
            Animation_Timer = 0;
            Sprite_Index = 0;
        }
    }
}
