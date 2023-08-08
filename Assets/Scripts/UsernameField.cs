using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UsernameField : MonoBehaviour
{
    public Text username;
    public InputField inputField;
    public CloseUsernameMenu closeUsernameMenu;

    public void ReplaceWhiteSpaces()
    {
        closeUsernameMenu.hasChanged = true;

        string inputText = inputField.text;

        if (inputText.Contains(" "))
        {
            inputField.SetTextWithoutNotify(inputText.Replace(" ", "_"));

        }
    }
}
