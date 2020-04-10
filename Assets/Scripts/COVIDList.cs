using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class COVIDList
{
    // Start is called before the first frame update
    
    public string srcurl_pdf;
    public string srcurl_web;
    public string description;
    public string lastUpdate;
    public int npatients;//stringのほういいかも
    public int nexits;
    public int ndeaths;
    public int ncurrentpatients;
    [System.Serializable]
    public struct areaList{
        public string name;
        public string name_jp;
        public int npatients;
        public int ncurrentpatients;
        public int nexits;
        public int ndeaths;
    }
    public areaList[] area;

    public void print()
    {
        foreach(var item in area)
        {
            Debug.Log("[Name:" + item.name +
                      "][namejp:" + item.name_jp +
                      "][npatients:" + item.npatients +
                      "][ncurrentpatients:" + item.ncurrentpatients + 
                      "][nexits:" + item.nexits +
                      "][ndeaths:" + item.ndeaths + "]");
        }
    }
}
