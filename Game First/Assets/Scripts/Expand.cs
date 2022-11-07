using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Expand : MonoBehaviour
{

    bool flag;
    bool flag2;
    RectTransform myRectTransform;

    float posX;
    float posY;
    float t;
    
    // Start is called before the first frame update
    void OnEnable()
    {
        flag = true;
        flag2 = true;
        myRectTransform = GetComponent<RectTransform>();
        myRectTransform.transform.localScale = new Vector3(0.159f, 0.157f, 0);
        t = 0;

        //Set posX -> Not resetting?

    }

    // Update is called once per frame
    void Update()
    {
        if (flag2) {
            posX = myRectTransform.localPosition.x;
            posY = myRectTransform.localPosition.y;
            flag2 = false;
        }
        if (flag)  {

            t += Time.deltaTime;
            myRectTransform.localPosition = new Vector3(Mathf.Lerp(posX, 0f, t*1.5f), Mathf.Lerp(posY, 0f, t*1.5f), 0);
            myRectTransform.localScale = new Vector3(Mathf.Lerp(0.159f, 1f, t*1.5f), Mathf.Lerp(0.157f, 1f, t*1.5f), 0);
            
            if (myRectTransform.transform.localScale.x >= 1 && myRectTransform.transform.localScale.y >= 1 && myRectTransform.localPosition.x == 0 && myRectTransform.localPosition.y == 0) {
                flag = false;
            }
        }



    }
}