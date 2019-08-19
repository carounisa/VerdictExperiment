using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using UnityEngine;

public class DataHandler : MonoBehaviour
{
    [HideInInspector]
    public PlayerData playerData;
    [HideInInspector]
    public PlayerData.Evidence evidenceData;

    private PlayerData.HeadData _head;
    private Stopwatch _stopwatch;
    private string _logFile;
    private string _logFilePath;
    private string _logDir;

    private float _interval = 1f;
    private float _currentTime = 0f;
    private bool _isRecording;


    private static DataHandler _instance;
    public static DataHandler instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<DataHandler>();
            }
            return _instance;
        }
    }

    private void Awake()
    {
        if (PlayerPrefs.GetInt("Recording") == 1)
            _isRecording = true;

        UnityEngine.Debug.Log(_isRecording);

        _logDir = Path.Combine(Application.dataPath, "PlayerRecordings");

        if (!Directory.Exists(_logDir))
            Directory.CreateDirectory(_logDir);

        playerData = new PlayerData();
        playerData.headDataList = new List<PlayerData.HeadData>();
        playerData.evidenceList = new List<PlayerData.Evidence>();
        playerData.pNumber = PlayerPrefs.GetInt("Participant Number");
        playerData.condition = PlayerPrefs.GetString("Condition");

        _logFile = string.Format("log{0}-PNum{1}_Con_{2}.json",
            System.DateTime.Now.ToString("dd-MM-yyyy"), 
            playerData.pNumber, playerData.condition);
        _logFilePath = Path.Combine(_logDir, _logFile);

        _stopwatch = new Stopwatch();
        _head = new PlayerData.HeadData();
        evidenceData = new PlayerData.Evidence();

        UnityEngine.Debug.Log("Log files stored to: " + _logDir);

    }

    private void Update()
    {
        if(_isRecording) {
            _currentTime += Time.deltaTime;
            // record every second
            if (_currentTime >= _interval)
            {
                _head.headPosition = Camera.main.transform.position;
                _head.direction = Camera.main.transform.forward;
                playerData.headDataList.Add(_head);
                _currentTime = _currentTime % _interval;

            }
        }
    }

    public void startTimer()
    {
        _stopwatch.Start();
    }

    public void stopTimer()
    {
        _stopwatch.Stop();
        System.TimeSpan elapsed = _stopwatch.Elapsed;
        evidenceData.elapsedTime = string.Format("{0:00}:{1:00}:{2:00}", elapsed.Minutes, elapsed.Seconds, elapsed.Milliseconds);
    }

    private void WriteToFile()
    {
            string json = JsonUtility.ToJson(playerData, true);
            File.WriteAllText(_logFilePath, json);
    }

    private void OnApplicationQuit()
    {
        if (_isRecording)
        {
            UnityEngine.Debug.Log("Exiting application and writing to file.");
            WriteToFile();
        }

    }
}
