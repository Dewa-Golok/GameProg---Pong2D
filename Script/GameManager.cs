using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int PlayerScoreL;
    public int PlayerScoreR;

    [Header("Text Score")]
    public TMP_Text txtPlayerScoreL;
    public TMP_Text txtPlayerScoreR;

    [Header("Panel PlayerR Win")]
    public GameObject panelWin;
    public TMP_Text playerWin;

    public Button restartButton;


    // Start is called before the first frame update
    public static GameManager instance;
    public SceneManagement sm;
    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        panelWin.SetActive(false);
    }

    public void Score (string wallID) 
    {
        if (wallID == "Line Left")
        {
            //Debug.Log("Kena Line L");
            PlayerScoreR = PlayerScoreR + 10;
            txtPlayerScoreR.text = PlayerScoreR.ToString();
            ScoreCheck();
        }
        else
        {
            //Debug.Log("Kena Line R");
            PlayerScoreL = PlayerScoreL + 10;
            txtPlayerScoreL.text = PlayerScoreL.ToString();
            ScoreCheck();
        }
    }

    public void ScoreCheck()
    {
        if (PlayerScoreL == 10)
        {
            panelWin.SetActive(true);
            playerWin.text = "Player L Win!!";
            Debug.Log("kepanggil 0");
            Invoke("ChangeTheScene", 2f);
        }
        else if (PlayerScoreR == 10)
        {
            panelWin.SetActive(true);
            playerWin.text = "Player R Win!!";
            Debug.Log("kepanggil 0");
            Invoke("ChangeTheScene", 2f);
        }
    }

    public void ChangeTheScene()
    {
        Debug.Log("kepanggil 1");
        //this.gameObject.SendMessage("ChangeTheScene", "Main Menu");
        sm.ChangeScene("Main");
    }
}
