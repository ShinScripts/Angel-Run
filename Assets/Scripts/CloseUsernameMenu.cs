using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CloseUsernameMenu : MonoBehaviour
{
    public GameObject menuToClose;
    public GameObject menuToOpen;
    public InputField usernameField;
    public bool hasChanged = false;

    private void Start()
    {
        if (PlayerPrefs.HasKey("username"))
        {
            menuToClose.SetActive(false);
            menuToOpen.SetActive(true);
        }
    }
    public void SaveUsernameAndOpenMenu()
    {
        if (usernameField.text.Length == 0)
        {
            hasChanged = false;
            StartCoroutine(flashText());
            return;
        }

        PlayerPrefs.SetString("username", usernameField.text);
        menuToClose.SetActive(false);
        menuToOpen.SetActive(true);
    }

    private IEnumerator flashText()
    {
        while (!hasChanged)
        {
            usernameField.placeholder.GetComponent<Text>().color = new Color(255, 0, 0, .5f);

            yield return new WaitForSeconds(.5f);

            usernameField.placeholder.GetComponent<Text>().color = new Color(0, 0, 0, .5f);

            yield return new WaitForSeconds(.5f);
        }
    }
}
