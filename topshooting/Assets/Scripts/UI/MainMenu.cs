using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class MainMenu : UI<MainMenu>
{
    protected override void Awake()
    {
        base.Awake();

        Vars["GameStartButton"].GetComponent<Button>().onClick.AddListener(() =>
        {
            GameScene.Instance.StartGame();
            gameObject.SetActive(false);
        });
        Vars["RankingButton"].GetComponent<Button>().onClick.AddListener(() =>
        {
            StartCoroutine(GetRanking());
        });
    }

    private IEnumerator GetRanking()
    {
        var request = UnityWebRequest.Get("http://localhost:3000/ranking");

        yield return request.SendWebRequest();

        if (request.isNetworkError)
        {
            Debug.Log(request.error);
        }
        else
        {
            Debug.Log("<get>" + request.downloadHandler.text + "</get>");
        }
    }
}