using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject CoverImage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void onClickstartButton()
    {
        CoverImage.SetActive(false);
    }
}
