using UnityEngine;
using TMPro;

public class TutorialManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textoDoTutorial;

    private int passoAtual = 0;

    private string[] passos =
    {
        "", //0
        "Utilize A e D para mover a câmera.", //1
        "Essa é sua quantidade de Sparkle.", //2
        "Esse é o botão de construção. Vamos tentar!", //3
        "Escolha Palco de Teatro e a posicione no tabuleiro.", //4
        "Escolha Palco de Teatro e a posicione no tabuleiro.", //5
        "Essas são as crianças que estão brincando no forte.", //6
        "Essas são as crianças que estão brincando no forte.", //7
        "Construa a primeira decoração.", //8
        "Construa a primeira decoração.", //9
        "Construa a primeira decoração.", //10
        "Construa a primeira decoração.", //11
        "Veja as necessidades das outras crianças.", //12
        "Inicie uma interação com a criança.", //13
        "Esse é seu vínculo com a criança. Há diversas maneiras de se aumentar o vínculo com uma criança.", //14
        "Esse é seu vínculo com a criança. Há diversas maneiras de se aumentar o vínculo com uma criança.", //15
        "Inicie um minigame com a criança para aumentar seu vínculo.", //16
        "Inicie um minigame com a criança para aumentar seu vínculo.", //17
        "Inicie um minigame com a criança para aumentar seu vínculo.", //18
        "Inicie um minigame com a criança para aumentar seu vínculo.", //19
        "Ao anoitecer, as crianças brincam automaticamente.", //20
        "O Forte está vivo, as crianças brincando, os objetos são transformados pela imaginação! O tutorial está completo." //21
    };

    private string[] falas =
    {
        "Oi, está aí? Está conseguindo enxergar?", //0
        "Todo Forte começa pequeno, mas quando várias crianças brincam juntas, ele pode se tornar o mundo inteiro para elas.", //1
        "Quando a gente imagina junto, as coisas ganham vida!", //2
        "Olha, o pessoal está chegando! Quanto maior o forte, mais crianças querem brincar aqui!", //3
        "Cada criança também gera Sparkles com o tempo.", //4
        "Poxa, o Forte parece vazio.", //5
        "Você vai continuar vindo brincar aqui amanhã?", //6
        "Venha, vamos jogar um jogo!", //7
        "Agora esse lugar é especial!" //8
    };

    void Start()
    {
        // setar a câmera com X 38, Y -190, Z -257
        // falas[0]
        MostrarPasso();
    }

    public void ProximoPasso()
    {
        passoAtual++;

        if (passoAtual >= passos.Length)
        {
            textoDoTutorial.gameObject.SetActive(false);
            return;
        }

        MostrarPasso();
    }

    private void MostrarPasso()
    {
        textoDoTutorial.text = passos[passoAtual];
    }

    void Update()
    {
        // ir para o passo 1 quando clicar com o mouse
        if (passoAtual == 0 && (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space)))
        {
            ProximoPasso();
        }

        // ir para o passo 2 quando detectar o andar
        if (passoAtual == 1 
            // && detectar A ou D
            )
        {
            // setar camera de novo para o centro e travar o A e D
            // falas[1]
            // colocar png do tutorial para mostrar o sparkle
            ProximoPasso();
        }

        // ir para o passo 3 ao clicar  
        if (passoAtual == 2 && (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space)))
        {
            // falas[2]
            // ativar botão de construção
            // colocar png no botão de construção 
            ProximoPasso();
        }

        // ir para o passo 4 ao clicar no botao de construcao
        if (passoAtual == 3
            // && detectar botão de construção
            )
        {
            // tirar png do botão de construcao
            // dar adoleta.QuantidadeDeSpark para o jogador
            // colocar png botao do palco 
            ProximoPasso();
        }
        if (passoAtual == 4
            // && detectar botão de palco clicado
            )
        {
            // tirar png botao do palco 
            // criar adoleta com opacidade baixa no canto para o jogador colocar a adoleta em cima 
            ProximoPasso();
        }
        if (passoAtual == 5
            // && adoleta com baixa opacidade clicada
            )
        {
            // criar adoleta no lugar da que tem baixa opacidade 
            // spawnar criancas
            // falas[3]
        }
        if (passoAtual == 6 && (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
            )
        {
            // falas[4]
            ProximoPasso();
        }
        if (passoAtual == 7 && (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
            )
        {
            // falas[5]
            ProximoPasso();
        }
        if (passoAtual == 8 && (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
            )
        {
            // colocar png botao de construcao 
            ProximoPasso();
        }
        if (passoAtual == 9
            // && botao de construcao clicado
            )
        {
            // tirar png botao de construcao 
            // colocar png na aba de decoracoes
            ProximoPasso();
        }
        if (passoAtual == 10
            // && botao de decoracao clicado
            )
        {
            // tirar png da aba de decoracoes
            ProximoPasso();
        }
        if (passoAtual == 11
            // && detectar objeto de decoracao criado
            )
        {
            // falas[6]
            ProximoPasso();
        }
        if (passoAtual == 12 && (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
            )
        {
            ProximoPasso();
        }
        if (passoAtual == 13
            // && detectar conversa com alguma crianca terminada
            )
        {
            // colocar png botao de construcao 
            ProximoPasso();
        }
        if (passoAtual == 14
            // && botao de construcao clicado
            )
        {
            // tirar png botao de construcao
            // colocar png na aba de criancas
            ProximoPasso();
        }

        if (passoAtual == 15
            // && aba de criancas clicada
            )
        {
            // tirar png na aba de criancas
            ProximoPasso();
        }
        if (passoAtual == 16
            // && janela fechada
            )
        {
            // falas[7]
            ProximoPasso();
        }
        if (passoAtual == 17 && (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
            )
        {
            // colocar png na adoleta que já foi previamente estipulada de onde estaria
            ProximoPasso();
        }
        if (passoAtual == 18
            // && adoleta clicada
            )
        {
            // tirar png na adoleta que já foi previamente estipulada de onde estaria
            ProximoPasso();
        }
        if (passoAtual == 19
            // && minigame concluido
            )
        {
            // falas[8]
            ProximoPasso();
        }
        if (passoAtual == 20 && (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
            )
        {
            // afastar a camera para o padrao normal 
            ProximoPasso();
        }
        if (passoAtual == 21 && (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
            )
        {
            // iniciar cena de jogo
        }
    }

    private void ColocarPNG(int x, int y)
    {

    }

    private void TirarPNG()
    {

    }
}
