using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleRemover : MonoBehaviour
{
    private LevelGeneration levelGeneration;

    private void Start()
    {
        levelGeneration = GameObject.FindObjectOfType<LevelGeneration>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        switch (other.tag)
        {
            case "Block":
                Destroy(other.transform.parent.gameObject);
                break;

            case "Obstacle":
                Destroy(other.gameObject);
                break;

            case "GravityField":
                Destroy(other.transform.parent.gameObject);
                levelGeneration.gravFieldExists = false;
                break;
        }
    }
}
