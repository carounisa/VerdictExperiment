using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public int pNumber;
    public string condition;
    public List<HeadData> headDataList;
    public List<Evidence> evidenceList;

    [System.Serializable]
    public class HeadData
    {
        public Vector3 headPosition;
        public Vector3 direction;
    }

    [System.Serializable]
    public class Evidence
    {
        public string name;
        public string startTime;
        public string endTime;
        public string elapsedTime;
    }
}
