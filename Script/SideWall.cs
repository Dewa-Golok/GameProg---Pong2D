using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideWall : MonoBehaviour
{

    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.gameObject.CompareTag("Ball"))
        {
            string wallName = transform.name;
            //Debug.Log("kena dinding" + wallName);
            //Debug.Log("satu");

            GameManager.instance.Score(wallName);
            hitInfo.gameObject.SendMessage("RestartGame", 1, SendMessageOptions.RequireReceiver);
            Debug.Log("trigger");
        }
    }
}
