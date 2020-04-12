using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleARCore;

public class ARImage : MonoBehaviour
{
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
                    prefecture.localScale = new Vector3(0.1f, 0.1f * getWeb.data.area[i].npatients, 0.1f);
                    prefecture.position = new Vector3(i * 0.1f, 0.05f * getWeb.data.area[i].npatients, 0.0f);
                }
                else{
                    Debug.Log("getWeb" + getWeb.data.area[i].name);
                    Debug.Log("object" + transform.GetChild(i).name);
                }
            }
        }
    }
}
