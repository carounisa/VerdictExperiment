using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class RecordPlayerData : MonoBehaviour
{
    private int timesViewed;
    private float distanceToEvidence;
    private bool viewed;
    private string json;
    private RecordTransform record;

    private void Awake()
    {

        record = new RecordTransform();

        if(PlayerPrefs.GetInt("Recording") == 1)
        {
            Debug.Log("Logging to file: ");
            File.WriteAllText(Application.dataPath + "saveFile.json", json);
        }

        record.PlayerSettings();

    }

    private void Update()
    {
        record.UpdateHeadPosition();
        json = JsonUtility.ToJson(record, true);
        File.AppendAllText(Application.dataPath + "saveFile.json", json);

    }

    private struct RecordTransform
    {
        public float headPosX;
        public float headPosY;
        public float headPosZ;
        public Vector3 headposition;

        public int pNumber;
        public string condition;

        public void UpdateHeadPosition()
        {
            headPosX = Camera.main.transform.position.x;
            headPosY = Camera.main.transform.position.y;
            headPosZ = Camera.main.transform.position.z;
            headposition = Camera.main.transform.position;

        }

        public void PlayerSettings()
        {
            pNumber = PlayerPrefs.GetInt("Participant Number");
            condition = PlayerPrefs.GetString("Condition");
        }

    }

  



}
