using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManage : MonoBehaviour
{
    // Start is called before the first frame update

    public Text UpdateTime;
    // public Text TouchText;
    public Text MainMode;
    public Text NextMode;
    public Text PreviousMode;
    public GameObject WebManager;
    GetWeb getWeb;
    flickDetection flickdetection;
    List<string> modeList = new List<string>{"通常","累計感染者","現在感染者","退院者","死者"};
    void Start(){
        flickdetection = this.GetComponent<flickDetection>();
        getWeb = WebManager.GetComponent<GetWeb>();
        PreviousMode.text = modeList[4];
        MainMode.text = modeList[0];
        NextMode.text = modeList[1];
    }
    void Update(){
        // TouchText.text = flickdetection.direction;
        if(getWeb.finishFlag){
            UpdateTime.text = "このデータは " + getWeb.data.lastUpdate.ToString() + " のものです";
        }
        changedMode();
    }
    void changedMode(){
        //左方向にフリック
        //次に進む
        if(flickdetection.direction == "left"){
            switch(MainMode.text){
                case "通常":
                    PreviousMode.text = modeList[0];
                    MainMode.text = modeList[1];
                    NextMode.text = modeList[2];
                    break;
                case "累計感染者":
                    PreviousMode.text = modeList[1];
                    MainMode.text = modeList[2];
                    NextMode.text = modeList[3];
                    break;
                case "現在感染者":
                    PreviousMode.text = modeList[2];
                    MainMode.text = modeList[3];
                    NextMode.text = modeList[4];
                    break;
                case "退院者":
                    PreviousMode.text = modeList[3];
                    MainMode.text = modeList[4];
                    NextMode.text = modeList[1];
                    break;
                case "死者":
                    PreviousMode.text = modeList[4];
                    MainMode.text = modeList[1];
                    NextMode.text = modeList[2];
                    break;
            }
        }
        //右向きにフリック
        //前に戻る
        else if(flickdetection.direction == "right"){
           switch(MainMode.text){
                case "通常":
                    PreviousMode.text = modeList[3];
                    MainMode.text = modeList[4];
                    NextMode.text = modeList[0];
                    break;
                case "累計感染者":
                    PreviousMode.text = modeList[4];
                    MainMode.text = modeList[0];
                    NextMode.text = modeList[1];
                    break;
                case "現在感染者":
                    PreviousMode.text = modeList[0];
                    MainMode.text = modeList[1];
                    NextMode.text = modeList[2];
                    break;
                case "退院者":
                    PreviousMode.text = modeList[1];
                    MainMode.text = modeList[2];
                    NextMode.text = modeList[3];
                    break;
                case "死者":
                    PreviousMode.text = modeList[2];
                    MainMode.text = modeList[3];
                    NextMode.text = modeList[4];
                    break;
            }
        }
    }
}
