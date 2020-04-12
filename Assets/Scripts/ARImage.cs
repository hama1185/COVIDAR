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
}
