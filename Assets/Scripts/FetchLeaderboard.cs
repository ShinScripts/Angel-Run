using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class FetchLeaderboard : MonoBehaviour
{
    public Text outputArea;
    public string url;
    public GameObject refreshButton;

    private void Start()
    {
        run();
    }

    public void run() => StartCoroutine(getData());

    private IEnumerator disableButton()
    {
        refreshButton.SetActive(false);

        yield return new WaitForSeconds(1);

        refreshButton.SetActive(true);

    }

    private IEnumerator getData()
    {
        StartCoroutine(disableButton());

        using (UnityWebRequest request = UnityWebRequest.Get(url))
        {
            outputArea.text = "Loading leaderboard...";

            if (Application.internetReachability == NetworkReachability.NotReachable)
            {
                outputArea.text = "No internet connection!";
                yield break;
            }

            request.SetRequestHeader("Content-Type", "application/json");
            request.SetRequestHeader("Authorization", "aliensarereal");

            yield return request.SendWebRequest();

            if (request.isDone)
            {
                string data = request.downloadHandler.text;
                int iter = 0;
                string outputText = "";

                foreach (var value in data.Split('/'))
                {
                    outputText += $"{++iter}. {value.Split(':')[0]} ({value.Split(':')[1]} meters)\n";
                }

                outputArea.text = outputText;
            }
        }
    }
}
