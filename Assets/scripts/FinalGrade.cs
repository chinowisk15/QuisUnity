using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalGrade : MonoBehaviour
{
    private int _idTheme;

    public TMP_Text txtNote;
    public TMP_Text txtInfoTheme;
    public GameObject star1;
    public GameObject star2;
    public GameObject star3;

    private int _finalGrade;
    private int _hits;

    void Start()
    {
        star1.SetActive(false);
        star2.SetActive(false);
        star3.SetActive(false);

        _idTheme = PlayerPrefs.GetInt("idTheme");
        _finalGrade = PlayerPrefs.GetInt("finalGradeTemp" + _idTheme.ToString());
        _hits = PlayerPrefs.GetInt("hitsTemp" + _idTheme.ToString());

        txtNote.text = _finalGrade.ToString();
        txtInfoTheme.text = "Você acertou " + _hits.ToString() + " de 20 perguntas";

        if (_finalGrade >= 10)
        {
            star1.SetActive(true);
            star2.SetActive(true);
            star3.SetActive(true);
        }
        else if (_finalGrade >= 8)
        {
            star1.SetActive(true);
            star2.SetActive(true);
        }
        else if (_finalGrade >= 6)
        {
            star1.SetActive(true);
        }
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene("T" + _idTheme.ToString());
    }

    void Update()
    {

    }
}