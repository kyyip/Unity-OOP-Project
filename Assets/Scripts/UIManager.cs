using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI ballText;
    [SerializeField] GameObject gameOverScreen;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerMovement.Instance.Balls == 10)
        {
            ballText.text = "Balls: 10 (MAX)";
        }
        else
        {
            ballText.text = "Balls: " + PlayerMovement.Instance.Balls;
        }

        if (!PlayerMovement.Instance.Alive)
        {
            ballText.gameObject.SetActive(false);
            gameOverScreen.SetActive(true);
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
}
