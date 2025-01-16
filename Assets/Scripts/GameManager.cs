using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.U2D;
using TMPro;
using UnityEngine.SocialPlatforms.Impl;
using static UnityEngine.Rendering.DebugUI;
using System.Linq;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject PlayArea;
    [SerializeField] GameObject Winner;
    [SerializeField] GameObject Loser;

    public TextMeshProUGUI uiTurns;
    public TextMeshProUGUI uiScore;
    public TextMeshProUGUI uiScoretobeat;
    public TextMeshProUGUI uiMultiplier;

    private int totalValue;

    private int turns;
    private int score;
    private int scoretobeat;
    public int multiplier;

    public List<int> Values = new List<int>();

    public void StartGame()
    {
        score = 0;
        turns = 3;
        scoretobeat = UnityEngine.Random.Range(30, 800);
        multiplier = 0;
    }
    public void PlayedTurn()
    {
        turns--;
        foreach (DominoValue child in PlayArea.GetComponentsInChildren<DominoValue>())
        {
            Values.Add(child.RNGNumber);            
        }
        var s = Values.Sum();
        score = s*multiplier;
        Values.Clear();
        if (score >= scoretobeat)
        {
            GameWon();
        }
        if (turns == 0)
        {
            GameLost();
        }

    }
    public void GameWon()
    {
        Winner.SetActive(true);
        StartGame();
    }
    public void GameLost()
    {
        Loser.SetActive(true);
        StartGame();
    }
    void Awake()
    {
        Buttons.PlayTurn += PlayedTurn;
    }
    void Start()
    {
        StartGame();
        Winner.SetActive(false);
        Loser.SetActive(false);
    }

    void Update()
    {
        uiScore.text = score.ToString();
        uiScoretobeat.text = scoretobeat.ToString();
        string uiMulti = "x" + multiplier;
        uiMultiplier.text = uiMulti;
        string uiString = "Turns: " + turns;
        uiTurns.text = uiString;
    }
}
