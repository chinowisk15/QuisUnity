using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ThemeGame : MonoBehaviour
{
    public Button btnPlay;
    public TMP_Text txtNameTheme;
    
    public GameObject infoTheme;
    public TMP_Text txtInfoTheme;
    public GameObject star1;
    public GameObject star2;
    public GameObject star3;

    public string[] nameTheme;
    public int amountQuestions;

    private int _idTheme;
    
    void Start()
    {
        _idTheme = 0;
        txtNameTheme.text = nameTheme[_idTheme];
        txtInfoTheme.text = "Você acertou x de " + amountQuestions.ToString() + " questões!";
        infoTheme.SetActive(false);
        star1.SetActive(false);
        star2.SetActive(false);
        star3.SetActive(false);
    }

    public void selectTheme(int id)
    {
        AudioManager.Instance.PlayClick();
        _idTheme = id;
        PlayerPrefs.SetInt("idTheme", _idTheme);
        txtNameTheme.text = nameTheme[id];
        int finalGrade = PlayerPrefs.GetInt("finalGrade" + _idTheme.ToString());
        int hits = PlayerPrefs.GetInt("hits" + _idTheme.ToString());
        
        star1.SetActive(false);
        star2.SetActive(false);
        star3.SetActive(false);
        
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

        txtInfoTheme.text = "Você acertou " + hits.ToString() + " de " + amountQuestions.ToString() + " questôes!";
        infoTheme.SetActive(true);
        btnPlay.interactable = true;
    }

    public void play()
    {
        StartCoroutine(WaitBtn());
    }

    IEnumerator WaitBtn()
    {
        AudioManager.Instance.PlayClick();
        yield return new WaitForSeconds(0.3f);
        SceneManager.LoadScene("T" + _idTheme.ToString());
    }
    void Update()
    {
        
    }
}
