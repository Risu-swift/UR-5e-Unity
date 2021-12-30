using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

public class TransformRead : MonoBehaviour
{
    public TextAsset csv;
    private List<String> rows;
    private int index = 1;
    [SerializeField]private float timeDelay = 0.16f;
    private float time = 0f;
    [SerializeField]private MultiCmd _multiCmd;
    private List<double> pos = new List<double>();

  
    void Start()
    {
        string s = csv.text.Replace(" ", ",");
        rows = TextAssetToList(s);
        Debug.Log("Done");
        
    }


    public void replayUpdate()
    {
        String temp = null;
        while (index < rows.Count-1)
        {
            
                List<String> columns = ReadCSV(rows[index]);
                temp += "\nmovej([" + columns[1]+ "," + columns[2] +","+ columns[3]+ "," + columns[4]+ "," + columns[5]+ "," + columns[6] +
                        "],a=0.15,v=0.16,r=0.01)";
                index++;
                
        }
        Debug.Log(index);
        _multiCmd.MultiParse(temp,timeDelay);
        index = 0;
        

    }
    
    List<String> ReadCSV(String Row)
    {
         String[] dataValue = Row.Split(',');
         return dataValue.ToList();
    }
    
    private List<String> TextAssetToList(string ta) {
        return new List<string>(ta.Split('\n'));
    }


}
