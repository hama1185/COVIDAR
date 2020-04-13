﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Manager : MonoBehaviour
{
    string currentMode = "通常";
    private bool modeFlag = true;
    public Text MainMode;
    public GameObject GameManager;
    ARImage arImage;
    // Start is called before the first frame update
    void Start(){
        arImage = GameManager.GetComponent<ARImage>();
    }

    // Update is called once per frame
    void Update(){
        // modeCheck();
        // modeChange();
    }
    void modeCheck(){
        if(currentMode != MainMode.text){
            modeFlag = true;
            currentMode = MainMode.text;
        }
    }
    void modeChange(){
        if(MainMode.text == "通常"){
            arImage.delete();
            arImage.enabled = false;
        }
        else if(MainMode.text == "累計感染者"){
            arImage.delete();
            arImage.enabled = true;
            if(modeFlag && arImage.Japan != null){
                arImage.modePatients();
                modeFlag = false;
            }
        }
        else if(MainMode.text == "現在感染者"){
            arImage.delete();
            arImage.enabled = true;
            if(modeFlag && arImage.Japan != null){
                arImage.modeCurrentpatients();
                modeFlag = false;
            }
        }
        else if(MainMode.text == "退院者"){
            arImage.delete();
            arImage.enabled = true;
            if(modeFlag && arImage.Japan != null){
                arImage.modeExits();
                modeFlag = false;
            }
        }
        else if(MainMode.text == "死者"){
            arImage.delete();
            arImage.enabled = true;
            if(modeFlag && arImage.Japan != null){
                arImage.modeDeaths();
                modeFlag = false;
            }
        }
    }
}
