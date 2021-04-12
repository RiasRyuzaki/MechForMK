using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class distance : MonoBehaviour
{
    public Transform player;
    public Text distText;

    // Update is called once per frame
    void Update()
    {
        distText.text = player.position.x.ToString("0");
    }
}
