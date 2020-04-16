using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class flickDetection : MonoBehaviour
{
    public string direction;
    private Vector2 touchStartPos;
    private Vector2 touchEndPos;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update(){
        Flick();
    }
    void Flick(){
        // if (Input.GetKeyDown(KeyCode.Mouse0)){
        //     touchStartPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z);
        // }

        // if (Input.GetKeyUp(KeyCode.Mouse0)){
        //     touchEndPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, Input.mousePosition.z);
        //     GetDirection();
        // }
        if(Input.touchCount > 0){
            foreach(var t in Input.touches){
                if(t.phase == TouchPhase.Began){
                    touchStartPos = new Vector2(t.position.x, t.position.y);
                }
                else if(t.phase == TouchPhase.Ended){
                    touchEndPos = new Vector2(t.position.x, t.position.y);
                    GetDirection();
                }
            }
        }
        else{
            direction = null;
        }
    }
    void GetDirection(){
        float directionX = touchEndPos.x - touchStartPos.x;
        float directionY = touchEndPos.y - touchStartPos.y;
        

        if (Mathf.Abs(directionY) < Mathf.Abs(directionX)){
            if (30 < directionX){
                //右向きにフリック
                direction = "right";
            }
            else if (-30 > directionX){
                //左向きにフリック
                direction = "left";
            }
                
        }
        else if (Mathf.Abs(directionX)<Mathf.Abs(directionY)){
            if (30 < directionY){
                //上向きにフリック
                direction = "up";
            }
            else if (-30 > directionY){
                //下向きのフリック
                direction = "down";
            }
        }
        else{
            //タッチを検出
            direction = "touch";
        }
    }

}
