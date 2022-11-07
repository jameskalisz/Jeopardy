using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Return : MonoBehaviour
{

    public GameObject answerImage;
    public GameObject questionImage;
    public GameObject dailyDouble;

    // Start is called before the first frame update
    public void OnClick()
    {
        // if (dailyDouble.activeSelf && !questionImage.activeSelf) {
        //     questionImage.SetActive(true);
            
        // }
        if (dailyDouble.activeSelf) {
            dailyDouble.SetActive(false);
        }
        else {
            questionImage.SetActive(false);
            answerImage.SetActive(false);
        }
    }
}
