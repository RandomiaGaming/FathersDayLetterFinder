using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax_Background : MonoBehaviour
{
    public List<GameObject> Backgrounds;
    public GameObject Player;
    void Update()
    {
        for (int i = 0; i < Backgrounds.Count; i++)
        {
            Backgrounds[i].transform.localPosition = new Vector3(Player.transform.position.x / (i + 2), 0, 0);
        }
    }
}
