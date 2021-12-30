using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
using UnityEngine;

public static class CommandParse 
{
    static string toBeSearched = "movej";
    
    enum error_level 
    {
        MISSING_JOINT_PARAMETER = -1,
        MISSING_ACCELERATION= -2,
        MISSING_VELOCITY= -3,
        MISSING_TIME= -4,
        MISSING_BLEND_RADIUS= -5,
        SUCCESS = 1
    }

    
   
    public static List<double> CmdParse(String cmd , out Dictionary<char,float> parameterDictionary)
    {
        List<double> jointPos = new List<double>();

        Dictionary<char,float> finalparams = new Dictionary<char, float>();
        
        StringBuilder stringBuilder = new StringBuilder();

        string temp, param = null;
        String[] parameters;
        
        int ix = cmd.IndexOf(toBeSearched);

        if (ix != -1) 
        {
            string code = cmd.Substring(ix + toBeSearched.Length);

            foreach (char ctx in code)
            {
                if (ctx == '(' || ctx == ')')
                {
                    continue;
                }

                if (ctx == '[')
                {
                    continue;
                }

                if (char.IsNumber(ctx))
                {
                    stringBuilder.Append(ctx);
                    continue;
                }
                
                if (ctx == ']')
                {
                    param = code.Substring(code.IndexOf(ctx));
                    Debug.Log("DONE");
                    break;
                }

                if  (char.IsPunctuation(ctx))
                {
                    stringBuilder.Append(ctx);
                    continue;
                }
            }

            if (param != null)
            {
                parameters = param.Split(',');
                foreach (var ctx in parameters)
                {
                    Match match = Regex.Match(ctx,@"[-+]?\d+(\.\d+)?", RegexOptions.IgnorePatternWhitespace);
                    Match charmatch = Regex.Match(ctx, @"[a-z]+", RegexOptions.IgnorePatternWhitespace);
                    if (match.Success && charmatch.Success)
                    {
                        
                        char.TryParse(charmatch.ToString(), out char c);
                        float.TryParse(match.ToString(), out float value);
                        finalparams.Add(c,value);
                    }
                }
            }
            else
            {
                Debug.Log("Error in Parameter parsing");
            }
            
            
            temp = stringBuilder.ToString();
            String[] positions = temp.Split(',');
            
            foreach (var ctx in positions)
            {
                double.TryParse(ctx,out double tmp);
                jointPos.Add(tmp);
            }
        }
        else
        {
            Debug.Log("Missing MoveJ command in the provided command string !");
        }

        parameterDictionary = finalparams;
        
        LinkRotator.setJointPos(jointPos);
        return jointPos;
    }

    
}
