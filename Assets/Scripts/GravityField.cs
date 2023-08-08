using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityField : MonoBehaviour
{
    public float slowDuration = 1;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<Player>().isNormalGravity = false;
            // StartCoroutine(slowTime(slowDuration));
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<Player>().isNormalGravity = true;
            // StartCoroutine(slowTime(slowDuration));
        }
    }


    private IEnumerator slowTime(float time)
    {
        Time.timeScale = .5f;
        Time.fixedDeltaTime = 0.02f * Time.timeScale;

        yield return new WaitForSeconds(time);

        Time.timeScale = 1;
        Time.fixedDeltaTime = 0.02f;

        yield return null;
    }
}
