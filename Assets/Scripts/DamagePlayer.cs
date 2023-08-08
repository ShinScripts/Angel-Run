using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour
{
    private Camera cam;

    private void Start()
    {
        cam = GameObject.FindObjectOfType<Camera>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Player player = other.GetComponent<Player>();

            player.lives--;
            FindObjectOfType<AudioManager>().Play("Collision");
            StartCoroutine(cam.Shake(0.05f,0.2f));

            if (player.lives <= 0)
                
            {
                other.GetComponent<Player>().isDead = true;

            }
            else
            {
                cam.speed *= .8f;
                cam.increase += .1f;
            }
        }
    }
}
