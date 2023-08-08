using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script was made by Diar Ahmed

public class JumpPad : MonoBehaviour
{

    [SerializeField] private float power;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip jumppadSound;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Rigidbody2D>().velocity.y.Equals(0);
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * power, ForceMode2D.Impulse);
            audioSource.PlayOneShot(jumppadSound);
        }
    }

}
