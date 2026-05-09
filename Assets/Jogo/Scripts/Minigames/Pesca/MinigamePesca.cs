using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MinigamePesca : MonoBehaviour
{
    [Header("Referências de UI")]
    public RectTransform BarraPlayer;
    public RectTransform peixeIcon;
    public Slider sliderProgresso;
    public TMP_Text pointUI;

    [Header("Pontuação")]
    private int points = 0;

    [Header("Configurações de Limite")]
    private float limiteTopo = 230f;
    private float limiteBase = -280f;

    [Header("Configurações da Barra Player")]
    public float gravidade = 500f;
    public float forçaImpulso = 800f;
    private float velocidadeBarra = 0f;

    [Header("Configurações do Peixe")]
    public float velocidadePeixe = 3f;
    private float tempoParaTrocarDestino = 0f;
    private float destinoYPeixe;

    [Header("Configurações do Jogo")]
    public float velocidadeGanho = 0.2f;
    public float velocidadePerda = 0.15f;

    [Header("Scripts")]
    private GameManager gm;

    [Header("Timer")]
    [SerializeField] private float maxTime;

    public float counterTime = 0;

    void Start()
    {
        gm = FindFirstObjectByType<GameManager>();

        GameObject canvas = gm.arrCanvasMinigames[gm.indexMinigame];

        Transform pontos = canvas.transform.Find("Points");
        pointUI = pontos.GetComponent<TMP_Text>();

        Transform barra = canvas.transform.Find("BarraPlayer");
        BarraPlayer = barra.GetComponent<RectTransform>();

        Transform peixe = canvas.transform.Find("Peixe");
        peixeIcon = peixe.GetComponent<RectTransform>();

        Transform slider = canvas.transform.Find("Slider");
        sliderProgresso = slider.GetComponent<Slider>();

        pointUI.text = "0";

        ReiniciarMinigame();
    }

    void Update()
    {
        if (counterTime >= maxTime)
        {
            gm.CloseMinigame();
            Destroy(gameObject);
        }
        else counterTime += Time.deltaTime;

        ControleBarraPlayer();
        InteligenciaPeixe();
        VerificarCaptura();
    }

    void ControleBarraPlayer()
    {
        if (Input.GetMouseButton(0))
            velocidadeBarra += forçaImpulso * Time.deltaTime;
        else
            velocidadeBarra -= gravidade * Time.deltaTime;

        Vector2 novaPos = BarraPlayer.anchoredPosition;
        novaPos.y += velocidadeBarra * Time.deltaTime;

        float meioBarra = BarraPlayer.rect.height / 2;
        novaPos.y = Mathf.Clamp(novaPos.y, limiteBase + meioBarra, limiteTopo - meioBarra);

        if (novaPos.y >= limiteTopo - meioBarra || novaPos.y <= limiteBase + meioBarra) 
            velocidadeBarra = 0;

        BarraPlayer.anchoredPosition = novaPos;
    }

    void InteligenciaPeixe()
    {
        tempoParaTrocarDestino -= Time.deltaTime;
        if (tempoParaTrocarDestino <= 0)
        {
            float meioPeixe = peixeIcon.rect.height / 2;
            destinoYPeixe = Random.Range(limiteBase + meioPeixe, limiteTopo - meioPeixe);
            tempoParaTrocarDestino = Random.Range(0.5f, 2f);
        }

        Vector2 posPeixe = peixeIcon.anchoredPosition;
        posPeixe.y = Mathf.Lerp(posPeixe.y, destinoYPeixe, velocidadePeixe * Time.deltaTime);
        
        float meioPeixeIcon = peixeIcon.rect.height / 2;
        posPeixe.y = Mathf.Clamp(posPeixe.y, limiteBase + meioPeixeIcon, limiteTopo - meioPeixeIcon);
        
        peixeIcon.anchoredPosition = posPeixe;
    }

    void VerificarCaptura()
    {
        float distancia = Mathf.Abs(peixeIcon.anchoredPosition.y - BarraPlayer.anchoredPosition.y);
        float areaDeCaptura = BarraPlayer.rect.height / 2;

        if (distancia < areaDeCaptura)
            sliderProgresso.value += velocidadeGanho * Time.deltaTime;
        else
            sliderProgresso.value -= velocidadePerda * Time.deltaTime;

        if (sliderProgresso.value >= 1) 
        {
            GanharPontoERecomecar();
        }
    }

    void GanharPontoERecomecar()
    {
        points++;
        pointUI.text = "" + points;
        ReiniciarMinigame();
    }

    void ReiniciarMinigame()
    {
        sliderProgresso.value = 0;
        velocidadeBarra = 0;

        float meioPeixe = peixeIcon.rect.height / 2;
        float novaPosPeixe = Random.Range(limiteBase + meioPeixe, limiteTopo - meioPeixe);
        peixeIcon.anchoredPosition = new Vector2(peixeIcon.anchoredPosition.x, novaPosPeixe);
        destinoYPeixe = novaPosPeixe;

        float meioBarra = BarraPlayer.rect.height / 2;
        float novaPosBarra = Random.Range(limiteBase + meioBarra, limiteTopo - meioBarra);
        BarraPlayer.anchoredPosition = new Vector2(BarraPlayer.anchoredPosition.x, novaPosBarra);
    }
}