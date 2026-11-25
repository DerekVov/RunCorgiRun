using UnityEngine;

public class StartScreen : MonoBehaviour
{
    public UI Ui;
    public GameTimer GameTimer;
    public BeerPlacer BeerPlacer;
    public BonePlacer BonePlacer;
    public PillPlacer PillPlacer;
    public MoonshinePlacer  MoonshinePlacer;
    public WaterBowlPlacer WaterBowlPlacer;
    public Corgi Corgi;
    public Music Music;
    public Sounds Sounds;

    private bool isGameRunning = false;

    public void Start()
    {
        Ui.HideGameOverScreen();
        Ui.ShowStartScreen();
        Music.PlayMenuMusic();
    }
    public void Update()
    {
        if (isGameRunning)
        {
            Ui.ShowTime();
        }
        
    }

    public void StartPlacing()
    {
        BeerPlacer.StartPlacing();
        BonePlacer.StartPlacing();
        PillPlacer.StartPlacing();
        MoonshinePlacer.StartPlacing();
        WaterBowlPlacer.StartPlacing();
    }

    public void StopPlacing()
    {
        BeerPlacer.StopPlacing();
        BonePlacer.StopPlacing();
        PillPlacer.StopPlacing();
        MoonshinePlacer.StopPlacing();
        WaterBowlPlacer.StopPlacing();
    }

    public bool isPlaying()
    {
        return isGameRunning;
    }
    public void OnPlayButtonClicked()
    {
        
        Ui.HideStartScreen();
        Sounds.PlayPoopSound();
        InitializeGame();
    }

    private void InitializeGame()
    {
        isGameRunning = true;
        GameTimer.StartTimer(10, OnTimerDone);
        StartPlacers();
        ScoreKeeper.ResetScore();
        Ui.ResetScore();
        Corgi.Reset();
        Music.PlayGameMusic();
    }

    private void StartPlacers()
    {
        StartPlacing();
    }

    public void OnPlayAgainButtonClicked()
    {
        Ui.HideGameOverScreen();
        Sounds.PlayPoopSound();
        InitializeGame();
    }
    public void OnTimerDone()
    {
        isGameRunning = false;
        Ui.ShowGameOverScreen();
        StopPlacing();
        Music.PlayMenuMusic();
    }
}
