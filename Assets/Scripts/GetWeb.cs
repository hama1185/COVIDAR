using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using MiniJSON;
public class GetWeb : MonoBehaviour{
    // Start is called before the first frame update
    public void onClick(){
        StartCoroutine(getWeb());
    }

    IEnumerator getWeb(){
        //リクエスト文
        //jigさんからのjsonを使用する
        var webRequest = UnityWebRequest.Get("https://app.sabae.cc/api/covid19japan.json");
        //通信
        yield return webRequest.SendWebRequest();
        //エラー検出
        if(webRequest.isHttpError || webRequest.isNetworkError){
            Debug.Log(webRequest.error);
        }
        switch(webRequest.downloadProgress){
            case 1:
                COVIDList data = JsonUtility.FromJson<COVIDList>(webRequest.downloadHandler.text);
                Debug.Log(data.area[0].name);
                break;
            case 0.5f:
                Debug.Log("connecting... downloadHandler is null");
                break;
            case -1:
                Debug.Log("Send is no call");
                break;
                
        }
    }
    
}