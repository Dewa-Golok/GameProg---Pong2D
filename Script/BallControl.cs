using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour
{
    private Rigidbody2D rb2d;
    public float rand;
    
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        Invoke("GoBall", 2);
    }

    // Update is called once per frame
    void GoBall()
    {
        float rand = Random.Range(2, 10);
        if (rand < 1)
        {
            rb2d.velocity = new Vector2(5, -5);
        }
        else
        {
            rb2d.velocity = new Vector2(-5, -5);
        }
    }

    void ResetBall() //ini kita buat nilai transform jadi 0
    {
        rb2d.velocity = Vector2.zero;
        transform.position = Vector2.zero;
    }

    void RestartGame()
    {
        //Debug.Log("Restart!");
        //Debug.Log("dua");
        ResetBall();
        Invoke("GoBall", 1);
    }

    void OnCollisionEnter2D(Collision2D coll)
    {

        if (coll.collider.CompareTag("Player")) //jika terkena player
        {

            // StartCoroutine(FireTriggger());
            Vector2 vel;
            vel.x = rb2d.velocity.x;
            vel.y = (rb2d.velocity.y / 2) + (coll.collider.attachedRigidbody.velocity.y / 3); //mengambil nilai velocity player
            rb2d.velocity = vel;

        }
    }
}
