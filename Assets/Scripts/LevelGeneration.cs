using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class LevelGeneration : MonoBehaviour
{
    public GameObject player;

    [Header("Levels")]
    public GameObject[] levels;
    public GameObject levelHolder;
    private GameObject currentLevel;
    public GameObject prevLevel;
    private int iter = 1;

    [Header("GravityField")]
    public GameObject gravityField;
    public GameObject gravityFieldHolder;
    public bool gravFieldExists = false;
    public int time;
    public float minDistance;
    public float maxDistance;

    [Header("Obstacles")]
    public GameObject obstacle;
    public GameObject obstacleHolder;
    public float minObstacleY;
    public float maxObstacleY;
    public float minObstacleSpacing;
    public float maxObstacleSpacing;

    [SerializeField] private GameObject postProcessingController;


    [Header("Powerups")]
    public GameObject[] powerups;

    private void Start()
    {
        currentLevel = levels[Random.Range(0, levels.Length - 1)];

        StartCoroutine(spawnAntiGrav(time, minDistance, maxDistance));
        StartCoroutine(spawnObstacle());
        StartCoroutine(spawnPowerup());
    }

    private void Update()
    {
        if (player.transform.position.x > currentLevel.transform.position.x)
        {
            GameObject nextLevel = Instantiate(levels[Random.Range(0, levels.Length)]);
            nextLevel.transform.position += new Vector3(76 * iter++, 0, 0);
            nextLevel.transform.parent = levelHolder.transform;

            prevLevel = currentLevel;
            currentLevel = nextLevel;

            //            (postProcessingController.GetComponent<Volume>())

          //  ((WhiteBalance)postProcessingController.GetComponent<VolumeParameter<WhiteBalance>>()).temperature.value = 1;

        }
    }

    private IEnumerator spawnAntiGrav(int time, float minDistance, float maxDistance)
    {
        while (true && !player.GetComponent<Player>().isDead)
        {
            yield return new WaitForSeconds(time);

            if (Random.Range(0, 4) == 0)
            {
                if (!gravFieldExists)
                {
                    gravFieldExists = true;

                    GameObject o = Instantiate(gravityField);
                    ParticleSystem ps = o.GetComponent<ParticleSystem>();
                    BoxCollider2D collider = o.GetComponent<BoxCollider2D>();
                    GameObject trigger = o.GetComponentInChildren<Rigidbody2D>().gameObject;

                    var sh = ps.shape;
                    float xSize = Random.Range(5, 60) * (player.GetComponentInParent<Camera>().speed / 4);

                    trigger.transform.position = new Vector3(xSize * 1.6f, 24, 0);

                    sh.scale = new Vector3(xSize, 1, 1);
                    collider.size = new Vector3(xSize * 2, collider.size.y, 1);
                    o.transform.position = new Vector3(player.transform.position.x + Random.Range(xSize, xSize + maxDistance), -20, 0);
                    o.transform.parent = gravityFieldHolder.transform;
                }
            }
        }
    }

    private IEnumerator spawnObstacle()
    {
        while (true && !player.GetComponent<Player>().isDead)
        {
            yield return new WaitForSeconds(Random.Range(1, 5));

            GameObject o = Instantiate(obstacle);
            o.transform.position = new Vector3(player.transform.position.x + 10 + Random.Range(minObstacleSpacing, maxObstacleSpacing), Random.Range(minObstacleY, maxObstacleY), 0);
            o.transform.parent = obstacleHolder.transform;
        }
    }

    private IEnumerator spawnPowerup()
    {
        while (true && !player.GetComponent<Player>().isDead)
        {
            // yield return new WaitForSeconds(Random.Range(20, 60));
            yield return new WaitForSeconds(2);

            if (Random.Range(0, 5) == 0 && player.GetComponent<Player>().lives < 2)
            {
                GameObject o = Instantiate(powerups[Random.Range(0, powerups.Length)]);
                o.transform.position = new Vector3(player.transform.position.x + 20, Random.Range(minObstacleY, maxObstacleY), 0);
                o.GetComponent<ParticleSystem>().Stop();
            }
        }
    }
}
