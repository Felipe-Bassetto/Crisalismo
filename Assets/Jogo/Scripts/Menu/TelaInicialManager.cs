using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TelaInicialManager : MonoBehaviour
{
    [Header("Objetos")]
    public GameObject opcoes;
    public GameObject btnOpcoes;
    public GameObject btnJogar;
    public GameObject btnSair;
    public GameObject nameGame;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenOpcoes()
    {
        opcoes.SetActive(true);
        btnOpcoes.SetActive(false);
        btnJogar.SetActive(false);
        btnSair.SetActive(false);
        nameGame.SetActive(false);
    }

    public void FecharOpcoes()
    {
        opcoes.SetActive(false);
        btnOpcoes.SetActive(true);
        btnJogar.SetActive(true);
        btnSair.SetActive(true);
        nameGame.SetActive(true);
    }

    public void Jogar()
    {
        nameGame.SetActive(false);
        btnOpcoes.SetActive(false);
        btnJogar.SetActive(false);
        btnSair.SetActive(false);
        SceneManager.LoadScene("Game");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
