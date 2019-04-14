using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Connect : MonoBehaviour
{
    public string login;
    public string pass;

    public Text statusText;
    public string status { set { statusText.text = value; } }

    public Text loginFild;
    public Text passFild;
    public Text confPassFild;
    // Start is called before the first frame update

    public void clickOnCreate()
    {
        if (passFild.text == confPassFild.text)
        {
            Debug.Log(passFild.text+" = "+ confPassFild.text);
            StartCoroutine(RegisterUser());
        }
        else status = "Пароли не совпадают";
    }

    private IEnumerator RegisterUser()
    {
        login = loginFild.text;
        pass = passFild.text;

        WWWForm form = new WWWForm();
        form.AddField("login", login);
        form.AddField("pass", pass);

        WWW url = new WWW("http://opppo.b99944p9.beget.tech/register", form);
        yield return url;
        if (url.error != null)
        {
            status = "Error: " + url.error;
            Debug.Log("Error: " + url.error);
        }
        status = "Answer: " + url.text;
        Debug.Log("Answer: " + url.text);
    }
}

