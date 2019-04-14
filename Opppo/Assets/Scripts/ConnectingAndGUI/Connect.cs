using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Connect : MonoBehaviour
{
    public string login;
    public string pass;

    public Text loginFiel;
    public Text passFiel;
    public Text confPassFiell;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(RegisterUser());
    }

    private IEnumerator RegisterUser()
    {
        WWWForm form = new WWWForm();
        form.AddField("login", login);
        form.AddField("pass", pass);

        WWW url = new WWW("http://opppo.b99944p9.beget.tech/register", form);
        yield return url;
        if (url.error != null)
            Debug.Log("Error"+url.error);
        Debug.Log("Answer" + url.text);
    }
}

