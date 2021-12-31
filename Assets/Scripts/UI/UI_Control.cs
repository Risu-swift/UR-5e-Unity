/****************************************************************************
MIT License
Copyright(c) 2020 Roman Parak
Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:
The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.
THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
*****************************************************************************
Author   : Roman Parak
Email    : Roman.Parak @outlook.com
Github   : https://github.com/rparak
File Name: main_ui_control.cs
****************************************************************************/

// ------------------------------------------------------------------------------------------------------------------------ //
// ----------------------------------------------------- LIBRARIES -------------------------------------------------------- //
// ------------------------------------------------------------------------------------------------------------------------ //

// -------------------- System -------------------- //

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
// -------------------- Unity -------------------- //
using UnityEngine;
using UnityEngine.UI;
// --------------------- TM ---------------------- //
using TMPro;

public class UI_Control : MonoBehaviour
{
    //-----------------------Text Asset Script Files------------------ //
    public TextAsset script;
    public TextAsset freeHand;
    
    // -------------------- String List --------------------- //
    private List<String> rows;
    [SerializeField]private MultiCmd _multiCmd;
   

    // -------------------- UTF8Encoding -------------------- //
    private UTF8Encoding utf8 = new UTF8Encoding();


    // ------------------------------------------------------------------------------------------------------------------------ //
    // ------------------------------------------------ INITIALIZATION {START} ------------------------------------------------ //
    // ------------------------------------------------------------------------------------------------------------------------ //
    void Start()
    {
        // Robot IP Address

        // Auxiliary first command -> Write initialization position/rotation with acceleration/time to the robot controller
        // command (string value)
        GlobalVariables_TCP_IP_client.aux_command_str = "speedl([0.0,0.0,0.0,0.0,0.0,0.0], a = 0.15, t = 0.03)" + "\n";
        // get bytes from string command
        GlobalVariables_TCP_IP_client.command = utf8.GetBytes(GlobalVariables_TCP_IP_client.aux_command_str);
        
    }

    // ------------------------------------------------------------------------------------------------------------------------ //
    // ------------------------------------------------ MAIN FUNCTION {Cyclic} ------------------------------------------------ //
    // ------------------------------------------------------------------------------------------------------------------------ //
  

    // ------------------------------------------------------------------------------------------------------------------------//
    // -------------------------------------------------------- FUNCTIONS -----------------------------------------------------//
    // ------------------------------------------------------------------------------------------------------------------------//

    // -------------------- Destroy Blocks -------------------- //
    void OnApplicationQuit()
    {
        // Destroy all
        Destroy(this);
    }

    public void TaskOnClick_FreeHand()
    {
        int index = 1;
        string s = freeHand.text.Replace(" ", ",");
        rows = TextAssetToList(s);
        
        String temp = null;
        while (index < rows.Count-1)
        {
            
            List<String> columns = ReadCSV(rows[index]);
            temp += "\nmovej([" + columns[1]+ "," + columns[2] +","+ columns[3]+ "," + columns[4]+ "," + columns[5]+ "," + columns[6] +
                    "],a=0.15,v=0.16,r=0.01)";
            Debug.Log(temp);
            index++;
        }
        
        _multiCmd.MultiParse(temp,0.016f);
    }
    

    public void TaskOnClick_SendScript()
    {
        GlobalVariables_TCP_IP_client.aux_command_str = script.text;
        Debug.Log((GlobalVariables_TCP_IP_client.aux_command_str));
        GlobalVariables_TCP_IP_client.command = utf8.GetBytes(GlobalVariables_TCP_IP_client.aux_command_str);
        GlobalVariables_TCP_IP_client.button_pressed[1] = true;

    }

    // -------------------- Connect Button -> is pressed -------------------- //
    public void TaskOnClick_ConnectBTN(String ipaddr)
    {
        GlobalVariables_Main_Control.ur3_tcpip_read_config_str = ipaddr;
        GlobalVariables_Main_Control.ur3_tcpip_write_config_str = ipaddr;
        GlobalVariables_Main_Control.connect    = true;
        GlobalVariables_Main_Control.disconnect = false;
    }

    // -------------------- Disconnect Button -> is pressed -------------------- //
    public void TaskOnClick_DisconnectBTN()
    {
        GlobalVariables_Main_Control.connect    = false;
        GlobalVariables_Main_Control.disconnect = true;
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
