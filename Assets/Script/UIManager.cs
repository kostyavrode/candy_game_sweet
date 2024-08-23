using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject[] uiPanels;
    [SerializeField] private TMP_Text moneyBar;
    [SerializeField] private TMP_Text scoreBar;
    [SerializeField] private TMP_Text bestScoreBarLose;
    [SerializeField] private TMP_Text scoreBarWin;
    [SerializeField] private TMP_Text timeWin;
    [SerializeField] private TMP_Text timeLose;
    [SerializeField] private TMP_Text timeBar;
    [SerializeField] private TMP_Text levelBar;
    private GameManager gameManager;
    private GameInfoHandler gameInfoHandler;
    private AudioManager audioManager;
    private void Start()
    {
        gameInfoHandler = ServiceLocator.GetService<GameInfoHandler>();
        gameManager= ServiceLocator.GetService<GameManager>();
        audioManager = ServiceLocator.GetService<AudioManager>();
        ShowMoney();
        GameManager.onGameStateChange += CheckGameState;
    }
    private void OnDisable()
    {
        GameManager.onGameStateChange -= CheckGameState;
    }
    private void CheckGameState(GameState state)
    {
        switch (state)
        {
            case GameState.OFF:
                break;
            case GameState.PLAYING:
                ShowScore();
                ShowLevel();
                break;
            case GameState.PAUSED:
                break;
            case GameState.FINISHED:
                //bestScoreBar.text = gameInfoHandler.GetBestScore().ToString();
                //uiPanels[3].SetActive(true);
                //uiPanels[2].SetActive(false);
                break;
            case GameState.END:
                break;
        }
    }
    public void ShowWinMenu()
    {
        uiPanels[4].SetActive(true);
        uiPanels[2].SetActive(false);
        timeWin.text = timeBar.text;
        scoreBarWin.text = scoreBar.text;
    }
    public void ShowLoseMenu()
    {
        uiPanels[3].SetActive(true);
        uiPanels[2].SetActive(false);
        bestScoreBarLose.text = scoreBar.text;
        //timeLose.text= timeBar.text;
    }
    public void ShowMoney()
    {
        moneyBar.text = gameInfoHandler.GetMoney().ToString();
    }
    public void ShowLevel()
    {
        int lvl = PlayerPrefs.GetInt("Level");
        levelBar.text = "Level " + lvl;
    }
    public void ShowTime(string time)
    {
        timeBar.text = "00:"+time;
    }
    public void ShowScore()
    {
        scoreBar.text= gameInfoHandler.GetScore().ToString();
    }
    public void ShowBestScore()
    {
        bestScoreBarLose.text=gameInfoHandler.GetBestScore().ToString();
    }
    public void StartButton()
    {
        ServiceLocator.GetService<GameManager>().StartGame();
    }
    public void PauseButton()
    {
        ServiceLocator.GetService<GameManager>().PauseGame();
    }
    public void ContinueButton()
    {
        gameManager.StartGame();
    }
    public void EndGameButton()
    {
        ServiceLocator.GetService<GameManager>().EndGame();
    }
    public void SoundOnButton()
    {
        ServiceLocator.GetService<AudioManager>().ChangeSoundState(SoundState.ON);
    }
    public void SoundOffButton()
    {
        ServiceLocator.GetService<AudioManager>().ChangeSoundState(SoundState.OFF);
    }
    public void MusicOffButton()
    {
        audioManager.ChangeMusicState(SoundState.OFF);
    }
    public void MusicOnButton()
    {
        audioManager.ChangeMusicState(SoundState.ON);
    }
    public void VibroOnButton()
    {
        ServiceLocator.GetService<VibrationManager>().ChangeVibroState(VibroState.ON);
    }
    public void VibroOffButton()
    {
        ServiceLocator.GetService<VibrationManager>().ChangeVibroState(VibroState.OFF);
    }
}
