using UnityEngine;
public class Ground_Checker : MonoBehaviour
{
    public bool Grounded = false;
    private void FixedUpdate()
    {
        Grounded = false;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            Grounded = true;
        }
    }
}
