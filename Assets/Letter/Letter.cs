using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Letter : MonoBehaviour
{
    private GameObject Canvas;
    private bool Showing_Message = false;
    void Start()
    {
        Canvas = transform.GetChild(0).gameObject;
    }
    void Update()
    {
        if (Showing_Message)
        {
            Canvas.SetActive(true);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Showing_Message = false;
                Time.timeScale = 1;
            }
        }
        else
        {
            Canvas.SetActive(false);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Showing_Message = true;
            Time.timeScale = 0;
        }
    }
}
