using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using System.Collections;

public class Camera : MonoBehaviour
{
    private bool hasplayed = false;
    public float speed = 5;
    public float increase;
    public FetchLeaderboard fetchLeaderboard;
    public GameObject restart;
    private Player player;

    private void Start()
    {
        player = FindObjectOfType<Player>();
        fetchLeaderboard.run();
        restart.SetActive(false);
    }

    private void Update()
    {
        if (player.isDead)
        {
            if (speed == 0)
                return;


            if (!hasplayed)
            {
                hasplayed = true;
                FindObjectOfType<AudioManager>().Play("PlayerDeath");
            }


            if (speed <= 1)
            {
                speed = 0;
                restart.SetActive(true);

                if (player.distance > PlayerPrefs.GetInt("score"))
                {
                    PlayerPrefs.SetInt("score", player.distance);
                    StartCoroutine(SendScore());
                }

                return;
            }

            if (speed < 5)
            {
                speed -= .8f * Time.deltaTime;
            }

            speed = (speed > 0) ? speed -= (speed / 2) * Time.deltaTime : 0;
        }

        gameObject.transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
        speed += increase * Time.deltaTime;
    }

    private IEnumerator SendScore()
    {
        if (Application.internetReachability == NetworkReachability.NotReachable) yield break;

        using (UnityWebRequest request = UnityWebRequest.Post($"https://AngelRunAPI.shincode.repl.co/postscore?username={PlayerPrefs.GetString("username")}&score={player.distance}", ""))
        {
            request.SetRequestHeader("Content-Type", "application/json");
            request.SetRequestHeader("Authorization", "aliensarereal");

            yield return request.SendWebRequest();
        }
    }

    public IEnumerator Shake(float dur, float amp)
    {

        Vector3 orignalPos = transform.localPosition;

        float time = 0;

        while (time < dur)
        {

            //SHAKES THE CAMERA
            transform.localPosition = new Vector3(Random.Range(-1f, 1f) * amp + orignalPos.x, Random.Range(-1f, 1f) * amp + orignalPos.y, orignalPos.z);

            time += Time.deltaTime;
            yield return null;
        }

        transform.localPosition = orignalPos;
    }
}
