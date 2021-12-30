using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEditor;

public class TransformRead : MonoBehaviour
{
    public TextAsset csv;
    private List<String> rows;
    private int index = 1;
    [SerializeField] private float timeDelay = 0.16f;
    private float time = 0f;
    public List<string> Commands { get; set; }


    void Start()
    {
        Commands = new List<string>();
        string s = csv.text.Replace(" ", ",");
        rows = TextAssetToList(s);
        Debug.Log("Done");
        Commands = GetCommand().Split('\n').ToList();
    }


    public string  GetCommand()
    { 
        String temp = null;
       
        {
            while (index < rows.Count - 1)
            {
                List<String> columns = ReadCSV(rows[index]);
                temp += "\nmovej([" + (float.Parse(columns[1])*Mathf.Deg2Rad) + "," + (float.Parse(columns[2]) * Mathf.Deg2Rad) + "," + (float.Parse(columns[3]) * Mathf.Deg2Rad) + "," + (float.Parse(columns[4]) * Mathf.Deg2Rad) + "," + (float.Parse(columns[5]) * Mathf.Deg2Rad) + "," + (float.Parse(columns[6]) * Mathf.Deg2Rad) +
                        "],a=0.15,v=0.16,r=0.01)";
                index++;
            }
            index = 0; 
        }
        return temp;
    }

    List<String> ReadCSV(String Row)
    {
        String[] dataValue = Row.Split(',');
        return dataValue.ToList();
    }

    private List<String> TextAssetToList(string ta)
    {
        return new List<string>(ta.Split('\n'));
    }


}
