using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script was made by Diar Ahmed
public class permanentlyEnableSpriteOnEnter : MonoBehaviour
{

    [SerializeField] private SpriteRenderer sprite;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            sprite.enabled = true;
        }
    }

  
}
