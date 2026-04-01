using UnityEngine;
using UnityEngine.UI;
public class MinigamePesca : MonoBehaviour
{
    [Header("Referências de UI")]
    public RectTransform BarraPlayer;
    public RectTransform peixeIcon;
    public RectTransform moldura;
    public Slider sliderProgresso;

    [Header("Configurações da Barra Player")]
    public float gravidade = 500f;
    public float forçaImpulso = 800f;
    private float velocidadeBarra = 0f;

    [Header("Configurações do Peixe")]
    public float velocidadePeixe = 3f;
    private float tempoParaTrocarDestino = 0.5f;
    private float destinoYPeixe;

    [Header("Configurações do Jogo")]
    public float velocidadeGanho = 0.2f;
    public float velocidadePerda = 0.15f;

    [Header("Configurações de Limite")]
    private float limiteTopo = 240f;
    private float limiteBase = -290f;

    void Start()
    {
        sliderProgresso.value = 0;
        destinoYPeixe = peixeIcon.anchoredPosition.y;
    }

    void Update()
    {
        ControleBarraPlayer();
        InteligenciaPeixe();
        VerificarCaptura();
    }

    void ControleBarraPlayer()
    {
        if (Input.GetMouseButton(0))
        {
            velocidadeBarra += forçaImpulso * Time.deltaTime;
        }
        else
        {
            velocidadeBarra -= gravidade * Time.deltaTime;
        }

        Vector2 novaPos = BarraPlayer.anchoredPosition;
        novaPos.y += velocidadeBarra * Time.deltaTime;

        float limiteSuperior = (moldura.rect.height / 2) - (BarraPlayer.rect.height / 2);
        float limiteInferior = -limiteSuperior;
        novaPos.y = Mathf.Clamp(novaPos.y, limiteInferior, limiteSuperior);

        if (novaPos.y == limiteSuperior || novaPos.y == limiteInferior) velocidadeBarra = 0;

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
            float margem = 20f;
            float limiteY = (moldura.rect.height / 2) - margem;
            destinoYPeixe = Random.Range(-limiteY, limiteY);
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
        {
            sliderProgresso.value += velocidadeGanho * Time.deltaTime;
        }
        else
        {
            sliderProgresso.value -= velocidadePerda * Time.deltaTime;
        }

        if (sliderProgresso.value >= 1) Debug.Log("Peixe peixcado!");
    }
}