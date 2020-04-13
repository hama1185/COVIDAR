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
    private GameObject Japan = null;
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
                    if(getWeb.data.area[i].npatients > 0){
                        prefecture.localScale = new Vector3(0.1f, 0.001f * getWeb.data.area[i].npatients,0.1f);
                    }
                    else{
                        prefecture.localScale = new Vector3(0, 0, 0);
                    }
                    prefecture.localPosition = new Vector3(prefecture.localPosition.x, 0.0005f * getWeb.data.area[i].npatients, prefecture.localPosition.z);
                }
                else{
                    Debug.Log("getWeb" + getWeb.data.area[i].name);
                    Debug.Log("object" + transform.GetChild(i).name);
                }
            }
        }
    }
    public void delete(){
        Destroy(Japan);
        Japan = null;
    }
    //累計感染者
    public bool modePatients(){
        if(Japan != null){
            for(int i = 0;i < Japan.transform.childCount; i++){
                if(Japan.transform.GetChild(i).name == getWeb.data.area[i].name){
                    var prefecture = Japan.transform.GetChild(i).GetComponent<Transform>();
                    if(getWeb.data.area[i].npatients > 0){
                        prefecture.localScale = new Vector3(0.1f, 0.001f * getWeb.data.area[i].npatients,0.1f);
                    }
                    else{
                        prefecture.localScale = new Vector3(0, 0, 0);
                    }
                    prefecture.localPosition = new Vector3(prefecture.localPosition.x, 0.0005f * getWeb.data.area[i].npatients, prefecture.localPosition.z);
                }
                else{
                    Debug.Log("getWeb" + getWeb.data.area[i].name);
                    Debug.Log("object" + transform.GetChild(i).name);
                }
            }
            return true;
        }
        else{
            return false;
        }
    }
    //現在感染者
    public bool modeCurrentpatients(){
        if(Japan != null){
            for(int i = 0;i < Japan.transform.childCount; i++){
                if(Japan.transform.GetChild(i).name == getWeb.data.area[i].name){
                    var prefecture = Japan.transform.GetChild(i).GetComponent<Transform>();
                    if(getWeb.data.area[i].ncurrentpatients > 0){
                        prefecture.localScale = new Vector3(0.1f, 0.001f * getWeb.data.area[i].ncurrentpatients,0.1f);
                    }
                    else{
                        prefecture.localScale = new Vector3(0, 0, 0);
                    }
                    prefecture.localPosition = new Vector3(prefecture.localPosition.x, 0.0005f * getWeb.data.area[i].ncurrentpatients, prefecture.localPosition.z);
                }
                else{
                    Debug.Log("getWeb" + getWeb.data.area[i].name);
                    Debug.Log("object" + transform.GetChild(i).name);
                }
            }
            return true;
        }
        else{
            return false;
        }
    }
    //退院者
    public bool modeExits(){
        if(Japan != null){
            for(int i = 0;i < Japan.transform.childCount; i++){
                if(Japan.transform.GetChild(i).name == getWeb.data.area[i].name){
                    var prefecture = Japan.transform.GetChild(i).GetComponent<Transform>();
                    if(getWeb.data.area[i].nexits > 0){
                        prefecture.localScale = new Vector3(0.1f, 0.001f * getWeb.data.area[i].nexits,0.1f);
                    }
                    else{
                        prefecture.localScale = new Vector3(0, 0, 0);
                    }
                    prefecture.localPosition = new Vector3(prefecture.localPosition.x, 0.0005f * getWeb.data.area[i].nexits, prefecture.localPosition.z);
                }
                else{
                    Debug.Log("getWeb" + getWeb.data.area[i].name);
                    Debug.Log("object" + transform.GetChild(i).name);
                }
            }
            return true;
        }
        else{
            return false;
        }
    }
    //死者
    public bool modeDeaths(){
        if(Japan != null){
            for(int i = 0;i < Japan.transform.childCount; i++){
                if(Japan.transform.GetChild(i).name == getWeb.data.area[i].name){
                    var prefecture = Japan.transform.GetChild(i).GetComponent<Transform>();
                    if(getWeb.data.area[i].ndeaths > 0){
                        prefecture.localScale = new Vector3(0.1f, 0.001f * getWeb.data.area[i].ndeaths,0.1f);
                    }
                    else{
                        prefecture.localScale = new Vector3(0, 0, 0);
                    }
                    prefecture.localPosition = new Vector3(prefecture.localPosition.x, 0.0005f * getWeb.data.area[i].ndeaths, prefecture.localPosition.z);
                }
                else{
                    Debug.Log("getWeb" + getWeb.data.area[i].name);
                    Debug.Log("object" + transform.GetChild(i).name);
                }
            }
            return true;
        }
        else{
            return false;
        }
    }
}
