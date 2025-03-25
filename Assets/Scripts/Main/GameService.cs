using ServiceLocator.Events;
using ServiceLocator.Map;
using ServiceLocator.Player;
using ServiceLocator.Sound;
using ServiceLocator.UI;
using ServiceLocator.Utilities;
using ServiceLocator.Wave;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameService : GenericMonoSingleton<GameService>
{
    public PlayerService playerService { get; private set; }
    public SoundService soundService { get; private set; }
    public MapService mapService { get; private set; }
    public WaveService waveService { get; private set; }

    [SerializeField] private UIService uiService;
    public UIService UIService => uiService;


    [SerializeField] private PlayerScriptableObject playerScriptableObject;
    [SerializeField] private SoundScriptableObject soundScriptableObject;
    [SerializeField] private MapScriptableObject mapScriptableObject;
    [SerializeField] private WaveScriptableObject waveScriptableObject;
    [SerializeField] private AudioSource audioEffects;
    [SerializeField] private AudioSource backgroundMusic;

    // Start is called before the first frame update
    void Start()
    {
        playerService  = new PlayerService(playerScriptableObject);
        soundService  = new SoundService(soundScriptableObject,audioEffects,backgroundMusic);
        mapService = new MapService(mapScriptableObject);
        waveService = new WaveService(waveScriptableObject);
    }

    // Update is called once per frame
    void Update()
    {
        playerService.Update();
    }
}
