using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.Networking;

public class GameScene : Singleton<GameScene>
{
    // static public > public > private 순서로 작성

    public bool isPlaying { get; private set; }

    [SerializeField]
    private SpawnManager spawnManager;

    protected override void Awake()
    {
        base.Awake();

        TableLoader.LoadAllData();

        SetPlayComponet(false);
    }

    public void StartGame()
    {
        var playerPrefab = Resources.Load("Prefabs/Player") as GameObject;
        var playerObject = Instantiate(playerPrefab);
        playerObject.GetComponent<Player>().enabled = false;
        MainMenu.Instance.gameObject.SetActive(false);
        var fireSequence = DOTween.Sequence();
        fireSequence.Append(playerObject.transform.DOMoveY(-5.0f, 2f).SetEase(Ease.InCirc, 2f));
        fireSequence.AppendCallback(() =>
        {
            isPlaying = true;
            playerObject.GetComponent<Player>().enabled = true;
            SetPlayComponet(true);
        });
    }

    public void GameOver()
    {
        StartCoroutine(SendScore());
        isPlaying = false;
        SetPlayComponet(false);
    }

    private void SetPlayComponet(bool isOn)
    {
        spawnManager.enabled = isOn;
        GameHUD.Instance.gameObject.SetActive(isOn);
        MainMenu.Instance.gameObject.SetActive(!isOn);
    }

    private IEnumerator SendScore()
    {
        var form = new WWWForm();
        form.AddField("name", SystemInfo.deviceName);
        form.AddField("score", GameHUD.Instance.Score);

        var request = UnityWebRequest.Post("http://localhost:3000/registerScore", form);

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