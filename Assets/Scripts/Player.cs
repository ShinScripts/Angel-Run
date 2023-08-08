using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public Animator animator;
    public bool isNormalGravity = true;
    public bool isDead = false;
    public float force = 50;
    private Rigidbody2D rb;
    private float gravScale = 1.5f;
    public int lives = 1;

    [Header("UI")]
    public Text distanceText;
    public int distance = 0;

    private ParticleSystem ps;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        ps = gameObject.GetComponentInChildren<ParticleSystem>();
        ps.Stop();
    }

    private void Update()
    {
        distance = (int)(transform.position.x + 6);
        distanceText.text = $"Distance: {distance}m";

        if (Input.GetMouseButtonDown(0) && !isDead)
        {
            if (isNormalGravity)
            {
                rb.velocity = new Vector3(0, force, 0);
                animator.SetBool("Jump", true);
                FindObjectOfType<AudioManager>().Play("WingFlap");
            }
            else
            {
                rb.velocity = new Vector3(0, -force, 0);
            }
        }

        if (isNormalGravity)
        {
            rb.gravityScale = gravScale;
            GetComponent<SpriteRenderer>().flipY = false;
        }
        else
        {
            rb.gravityScale = -gravScale;
            GetComponent<SpriteRenderer>().flipY = true;
        }

        if (lives > 1)
        {
            ps.Play();
        }
        else
        {
            ps.Stop();

        }

        if (!isDead)
        {
            //Changing yVelo in the animator
            animator.SetFloat("yVelocity", rb.velocity.y);
        }
    }
}
