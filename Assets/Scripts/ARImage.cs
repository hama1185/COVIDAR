using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GoogleARCore;

public class ARImage : MonoBehaviour
{
    public Text DebugText;
    GameObject japan = null;
    public GameObject PrefabJapan;
    public GameObject Japan = null;
    public GameObject WebManager;
    GetWeb getWeb;
    // Start is called before the first frame update
    void Awake() {
        Application.targetFrameRate = 60;    
    }
    void Start() {
        getWeb = WebManager.GetComponent<GetWeb>();
    }
    // Start is called before the first frame update

    // Update is called once per frame
    void Update(){
        List<AugmentedImage> markers = new List<AugmentedImage>();
        if(Session.Status != SessionStatus.Tracking){
            return;
        }
        Session.GetTrackables<AugmentedImage>(markers, TrackableQueryFilter.Updated);
        foreach(AugmentedImage marker in markers){
            if(marker.TrackingState == TrackingState.Tracking){
                if(Japan == null){
                    Anchor anchor = marker.CreateAnchor(marker.CenterPose);
                    Japan = Instantiate(PrefabJapan, anchor.transform);
                }
                else{
                    Japan.transform.position = marker.CenterPose.position;
                    Japan.transform.rotation = marker.CenterPose.rotation;
                }
            }
        }
        
    }
    public void onClick(){
        if(Japan != null){
            for(int i = 0;i < Japan.transform.childCount; i++){
                if(Japan.transform.GetChild(i).name == getWeb.data.area[i].name){
                    var prefecture = Japan.transform.GetChild(i).GetComponent<Transform>();
                    prefecture.localScale = new Vector3(0.1f, 0.1f * getWeb.data.area[i].npatients, 0.1f);
                    prefecture.position = new Vector3(prefecture.position.x, 0.05f * getWeb.data.area[i].npatients, prefecture.position.z);
                }
                else{
                    DebugText.text = getWeb.data.area[i].name;
                    Debug.Log("getWeb" + getWeb.data.area[i].name);
                    Debug.Log("object" + transform.GetChild(i).name);
                }
            }
        }
        else{
            DebugText.text = "null";
        }
    }
    public void delete(){
        Destroy(Japan);
        Japan = null;
    }
    //累計感染者
    public void modePatients(){
        for(int i = 0;i < Japan.transform.childCount; i++){
            if(Japan.transform.GetChild(i).name == getWeb.data.area[i].name){
                var prefecture = Japan.transform.GetChild(i).GetComponent<Transform>();
                prefecture.localScale = new Vector3(0.1f, 0.1f * getWeb.data.area[i].npatients, 0.1f);
                prefecture.position = new Vector3(prefecture.position.x, 0.05f * getWeb.data.area[i].npatients, prefecture.position.z);
            }
            else{
                Debug.Log("getWeb" + getWeb.data.area[i].name);
                Debug.Log("object" + transform.GetChild(i).name);
            }
        }
    }
    //現在感染者
    public void modeCurrentpatients(){
        for(int i = 0;i < Japan.transform.childCount; i++){
            if(Japan.transform.GetChild(i).name == getWeb.data.area[i].name){
                var prefecture = Japan.transform.GetChild(i).GetComponent<Transform>();
                prefecture.localScale = new Vector3(0.1f, 0.1f * getWeb.data.area[i].ncurrentpatients, 0.1f);
                prefecture.position = new Vector3(prefecture.position.x, 0.05f * getWeb.data.area[i].ncurrentpatients, prefecture.position.z);
            }
            else{
                Debug.Log("getWeb" + getWeb.data.area[i].name);
                Debug.Log("object" + transform.GetChild(i).name);
            }
        }
    }
    //退院者
    public void modeExits(){
        for(int i = 0;i < Japan.transform.childCount; i++){
            if(Japan.transform.GetChild(i).name == getWeb.data.area[i].name){
                var prefecture = Japan.transform.GetChild(i).GetComponent<Transform>();
                prefecture.localScale = new Vector3(0.1f, 0.1f * getWeb.data.area[i].nexits, 0.1f);
                prefecture.position = new Vector3(prefecture.position.x, 0.05f * getWeb.data.area[i].nexits, prefecture.position.z);
            }
            else{
                Debug.Log("getWeb" + getWeb.data.area[i].name);
                Debug.Log("object" + transform.GetChild(i).name);
            }
        }
    }
    //死者
    public void modeDeaths(){
        for(int i = 0;i < Japan.transform.childCount; i++){
            if(Japan.transform.GetChild(i).name == getWeb.data.area[i].name){
                var prefecture = Japan.transform.GetChild(i).GetComponent<Transform>();
                prefecture.localScale = new Vector3(0.1f, 0.1f * getWeb.data.area[i].ndeaths, 0.1f);
                prefecture.position = new Vector3(prefecture.position.x, 0.05f * getWeb.data.area[i].ndeaths, prefecture.position.z);
            }
            else{
                Debug.Log("getWeb" + getWeb.data.area[i].name);
                Debug.Log("object" + transform.GetChild(i).name);
            }
        }
    }
}
