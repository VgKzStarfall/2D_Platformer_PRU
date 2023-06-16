using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class IOFIle : MonoBehaviour
{
    String path = "E:/2D_Platformer_PRU/data.txt";

    public void dataFileWriter(int finalScore, int finalDiamondValue)
    {

        StreamWriter output = null;
        FileInfo fileInfo = new FileInfo(path);
        string result = "{\"Score\":\"" + finalScore + "\",\"Diamonds\":\"" + finalDiamondValue + "\"}";
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
