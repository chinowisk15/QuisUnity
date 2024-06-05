using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThemeInfo : MonoBehaviour
{
    public int _idTheme;
    public GameObject star1;
    public GameObject star2;
    public GameObject star3;

    private int finalGrade;
    
    void Start()
    {
        star1.SetActive(false);
        star2.SetActive(false);
        star3.SetActive(false);

        finalGrade = PlayerPrefs.GetInt("finalGrade" + _idTheme.ToString());

        if (finalGrade >= 10)
        {
            star1.SetActive(true);
            star2.SetActive(true);
            star3.SetActive(true);
        }
        else if (finalGrade >= 8)
        {
            star1.SetActive(true);
            star2.SetActive(true);
        }
        else if (finalGrade >= 6)
        {
            star1.SetActive(true);
        }
    }
    void Update()
    {
        
    }
}
