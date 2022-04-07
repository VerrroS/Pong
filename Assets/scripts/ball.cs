using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball : MonoBehaviour
{
    public float speed = 0.5f;
    Vector3 direction;
    GameManager gm;
    audio audio;
    public Rigidbody rb;

    void Start()
    {
        audio = FindObjectOfType<audio>();
        gm = FindObjectOfType<GameManager>();
        ReturnToCenter();
    }
  

    public void ReturnToCenter()
    {
        int velX = Random.Range(1, 3) == 1 ? Random.Range(-4, -7) : Random.Range(4, 7);
        int velZ = Random.Range(1, 3) == 1 ? Random.Range(-4, -7) : Random.Range(4, 7);
        rb.velocity = new Vector3(velX * speed, 0, velZ * speed);
        transform.position = new Vector3(0, 1, 0);
    }

    void OnCollisionEnter(Collision collision)
    {

        if (collision.collider.tag == "Paddle")
        {
            audio.play_audio("paddle");
        }
        if (collision.collider.tag == "Wall")
        {
            audio.play_audio("wall");
        }
        if (collision.collider.tag == "Player1")
        {
            gm.setScore(false);
           audio.play_audio("score");
            ReturnToCenter();
        }
        if (collision.collider.tag == "Player2")
        {
            gm.setScore(true);
            audio.play_audio("score");
            ReturnToCenter();
        }
    }

    public void setSpeed(float newSpeed)
    {
        speed = newSpeed;
        ReturnToCenter();
    }
}
