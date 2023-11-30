using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    public Sprite Active;
    private Sprite Inactive;
    private SpriteRenderer SR;
    private void Start()
    {
        SR = GetComponent<SpriteRenderer>();
        Inactive = SR.sprite;
    }
    private void Update()
    {
        if (Player.CheckPointPos == (Vector2)transform.position)
        {
            SR.sprite = Active;
        }
        else
        {
            SR.sprite = Inactive;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Player.CheckPointPos = transform.position;
        }
    }
}
