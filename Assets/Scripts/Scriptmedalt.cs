using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;
using System.Threading;


public class Scriptmedalt : MonoBehaviour
 {
    string dataPath;
    string streamingTextFile;
    int filenumber = 0;

    public TextMeshProUGUI xValue;
    public TextMeshProUGUI yValue;
    public TextMeshProUGUI zValue;
    public TextMeshProUGUI buttonText;


    public List<Vector3> dataList = new List<Vector3>();

    void Awake()
    {
        Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
        dataPath = Application.persistentDataPath + "/Player_Data/";
        Debug.Log(dataPath);
        NewDirectory();
        streamingTextFile = dataPath + "Streaming_Save_Data.txt";
    }

    private void Start()
    {
        buttonText.text = "Start";
    }

    private void OnEnable()
    {
        EventManager.Recording += CaptureInputs;
        EventManager.StopRec += SaveInputs;
    }

    private void OnDisable()
    {
        EventManager.Recording -= CaptureInputs;
        EventManager.StopRec -= SaveInputs;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        xValue.text = RecordAccelrometerValues().x.ToString();
        yValue.text = RecordAccelrometerValues().y.ToString();
        zValue.text = RecordAccelrometerValues().z.ToString();
    }

    public void CaptureInputs()
    {
        dataList.Add(RecordAccelrometerValues());
        Debug.Log("not flat");
        buttonText.text = "Recording";
    }

    public void SaveInputs()
    {
        Debug.Log("is flat");
        buttonText.text = "Start";
        WriteToStream(streamingTextFile, dataList);
        filenumber++;
        streamingTextFile = dataPath + "Streaming_Save_Data" + filenumber.ToString() + ".txt";
    }
    

    public void WriteToStream(string filename, List<Vector3> list)
    {
        if (!File.Exists(filename))
        {
            using (StreamWriter newStream = File.CreateText(filename))
            {             
                Debug.Log("New file created");
            }

        }
        
        StreamWriter streamWriter = File.AppendText(filename);
      
        streamWriter.WriteLine("x; y; z");
        
        
        for (int i = 0; i < list.Count; i++)
        {
            streamWriter.WriteLine(list[i].x + ";" + list[i].y + ";" +
                            list[i].z);
        }
        streamWriter.Close();

        Debug.Log("File contents updated");
    }
    public void NewDirectory()
    {
        if (Directory.Exists(dataPath))
        {
            Debug.Log("Directory already exists");
            return;
        }
        Directory.CreateDirectory(dataPath);
        Debug.Log("New directory created");
    }

    public Vector3 RecordAccelrometerValues()
    {
        return Input.acceleration;
    }
}



