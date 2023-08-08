using System.Collections;
using UnityEngine;

public class BuffSkold : MonoBehaviour
{
    private Player player;
    private AudioSource audioData;
    private ParticleSystem system;

    private void Start()
    {
        player = GameObject.FindObjectOfType<Player>();
        audioData = GetComponent<AudioSource>();
        system = GetComponent<ParticleSystem>();
        system.Stop();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player") && col.GetComponent<Player>().lives < 2 && !player.isDead)
        {
            StartCoroutine(playParticle(col));
        }
    }

    private IEnumerator playParticle(Collider2D col)
    {
        player.lives++;
        audioData.Play();
        system.Play();
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        yield return new WaitForSeconds(2);
        Destroy(this);
    }
}
