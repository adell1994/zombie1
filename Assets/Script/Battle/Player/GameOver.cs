using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class GameOver : MonoBehaviour
{
    public PlayerParameter playerParameter;
    public Round round;
    public GameObject gameOver;
    public GameObject battleResultR;
    public GameObject battleResultP;
    public GameObject titleBack;
    public TextMeshProUGUI resultRText;
    public TextMeshProUGUI resultPText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Battle.state == Battle.BattleState.End && Input.GetKey(KeyCode.Return))
        {
            SceneManager.LoadScene("TitleScene");
        }
    }
    public void SetGameOver()
    {
        resultPText.text = "最終所持ポイント" + playerParameter.havePoints + "P";
        resultRText.text = "生存R数" + round.roundNum + "R";
        gameOver.SetActive(true);
        battleResultP.SetActive(true);
        battleResultR.SetActive(true);
        titleBack.SetActive(true);
        if(round.roundNum >= 10)
        {
            PlayerPrefs.SetInt("Clear", 1);
            PlayerPrefs.Save();
        }
    }
}
