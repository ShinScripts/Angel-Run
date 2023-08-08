using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaDamage : MonoBehaviour
{
    private Camera cam;
    private bool inLava = false;

    private void Start()
    {
        cam = GameObject.FindObjectOfType<Camera>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        inLava = true;
        StartCoroutine(check(other));
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        inLava = false;
    }

    private IEnumerator check(Collider2D other)
    {
        while (true)
        {
            if (!inLava)
                break;

            if (other.CompareTag("Player"))
            {
                Player player = other.GetComponent<Player>();

                player.lives--;

                if (player.lives <= 0)
                {
                    other.GetComponent<Player>().isDead = true;
                    break;
                }
                else
                {
                    cam.speed *= .6f;
                    cam.increase += .1f;
                }
            }
            yield return new WaitForSeconds(1.5f);
        }
    }
}
