using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public TextMeshProUGUI  countdown;
    public ArrowControl     arrow;

    void Start()
    {
        StartCoroutine(StartLevelCR());
    }

    private void Update()
    {
        var coins = FindObjectsByType<Coin>(FindObjectsSortMode.None);
        if (coins.Length == 0)
        {
            SceneManager.LoadScene("TheEnd");
        }
    }

    private IEnumerator StartLevelCR()
    {
        countdown.gameObject.SetActive(true);
        countdown.text = "3";
        yield return new WaitForSeconds(1.0f);
        countdown.text = "2";
        yield return new WaitForSeconds(1.0f);
        countdown.text = "1";
        yield return new WaitForSeconds(1.0f);
        countdown.gameObject.SetActive(false);

        arrow.Activate();
    }
}
