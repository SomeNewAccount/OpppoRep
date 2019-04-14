using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SingIn : MonoBehaviour
{
    public string login;
    public string pass;

    public Text statusText;
    public string status { set { statusText.text = value; } }
    public GameObject MainCanvas;

    public Text loginFild;
    public Text passFild;

    public void clickOnSignIn()
    {
        StartCoroutine(SignIn());
    }

    private IEnumerator SignIn()
    {
        login = loginFild.text;
        pass = passFild.text;

        WWWForm form = new WWWForm();
        form.AddField("login", login);
        form.AddField("pass", pass);

        WWW url = new WWW("http://opppo.b99944p9.beget.tech/login", form);
        yield return url;
        if (url.error != null)
        {
            status = "Error: " + url.error;
            Debug.Log("Error: " + url.error);
        }
        status = "Answer: " + url.text;
        Debug.Log("Answer: " + url.text);
        if (url.text == "Успешный вход!")
            MainCanvas.SetActive(false);
    }
}
