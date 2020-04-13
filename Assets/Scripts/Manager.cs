using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Manager : MonoBehaviour
{
    public Text MainMode;
    public GameObject GameManager;
    ARImage arImage;
    // Start is called before the first frame update
    void Start(){
        arImage = GameManager.GetComponent<ARImage>();
    }

    // Update is called once per frame
    void Update(){
        ModeChange();
    }
    void ModeChange(){
        if(MainMode.text == "通常"){
            arImage.Delete();
            arImage.enabled = false;
            
        }
        else{
            arImage.enabled = true;
        }
    }
}
