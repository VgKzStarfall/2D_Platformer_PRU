using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class IOFIle : MonoBehaviour
{
    String path = "E:/2D_Platformer_PRU/data.txt";

    public void dataFileWriter(int finalScore, int finalDiamondValue, int finalRubyValue, DateTime timePlay)
    {

        StreamWriter output = null;
        FileInfo fileInfo = new FileInfo(path);
        string result = " Scores: " + finalScore + " \n Diamonds: " + finalDiamondValue + "/75 \n Rubies: " + finalRubyValue + " \n " +
            "Time play: " + timePlay + "";
        try
        {
            if (!fileInfo.Exists)
            {
                output = new StreamWriter(File.Open(path, FileMode.Create));
            } else
            {
                output = new StreamWriter(File.Open(path, FileMode.Create));
            }
            //
            output.WriteLine("Last Play: \n");
            output.WriteLine(result);

        } 
        catch(Exception e)
        {
            Debug.Log(e);
        } 
        finally { 
            if (output != null)
            {
                output.Close(); 
            }
        }
    }
}
