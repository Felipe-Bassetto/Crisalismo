using UnityEngine;
using TMPro;

public class TutorialManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textoDoTutorial;

    private int passoAtual = 0;

    private string[] passos =
    {
        "",
        "Utilize A e D para mover a câmera.",
        "Essa é sua quantidade de Sparkle.",
        "Esse é o botão de construção. Vamos tentar!",
        "Escolha Palco de Teatro e a posicione no tabuleiro.",
        "Escolha Palco de Teatro e a posicione no tabuleiro.",
        "Essas são as crianças que estão brincando no forte.",
        "Cada criança também gera Sparkles com o tempo.",
        "Construa a primeira decoração.",
        "Veja as necessidades das outras crianças.",
        "Inicie uma interação com a criança.",
        "Esse é seu vínculo com a criança. Há diversas maneiras de se aumentar o vínculo com uma criança.",
        "Inicie um minigame com a criança para aumentar seu vínculo.",
        "Ao anoitecer, as crianças brincam automaticamente.",
        "O Forte está vivo, as crianças brincando, os objetos são transformados pela imaginação! O tutorial está completo."
    };

    private string[] falas =
    {
        "Oi, está aí? Está conseguindo enxergar?",
        "Todo Forte começa pequeno, mas quando várias crianças brincam juntas, ele pode se tornar o mundo inteiro para elas.",
        "Quando a gente imagina junto, as coisas ganham vida!",
        "Olha, o pessoal está chegando! Quanto maior o forte, mais crianças querem brincar aqui!",
        "Poxa, o Forte parece vazio.",
        "Você vai continuar vindo brincar aqui amanhã?",
        "Venha, vamos jogar um jogo!",
        "Agora esse lugar é especial!"
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
        if (passoAtual == 0 && (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space)))
        {
            ProximoPasso();
        }

        if (passoAtual == 1 && Input.GetKeyDown(KeyCode.Space))
        {
            // falas[1]
            // colocar png do tutorial para mostrar o sparkle
            ProximoPasso();
        }

        if (passoAtual == 2
            // && detectar botao de construcao precionado detectar objeto de construcao criado
            )
        {
            // falas[2]
            // ativar botão de construção
            // colocar png no botão de construção 
            ProximoPasso();
        }

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
            // && detectar botão de palco criado
            )
        {
            // tirar png botao do palco 
            ProximoPasso();
        }
        if (passoAtual == 5
            // && objeto palco criado
            )
        {
            // spawnar criancas
            // falas[3]
            ProximoPasso();
        }
        if (passoAtual == 6 && (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
            )
        {
            // colocar png botao do palco 
            ProximoPasso();
        }
        if (passoAtual == 7
            // && detectar objeto de construcao criado
            )
        {
            // colocar png botao do palco 
            ProximoPasso();
        }
        if (passoAtual == 8
            // && detectar objeto de construcao criado
            )
        {
            // colocar png botao do palco 
            ProximoPasso();
        }
        if (passoAtual == 9
            // && detectar objeto de construcao criado
            )
        {
            // colocar png botao do palco 
            ProximoPasso();
        }
        if (passoAtual == 10
            // && detectar objeto de construcao criado
            )
        {
            // colocar png botao do palco 
            ProximoPasso();
        }
        if (passoAtual == 11
            // && detectar objeto de construcao criado
            )
        {
            // colocar png botao do palco 
            ProximoPasso();
        }
        if (passoAtual == 12
            // && detectar objeto de construcao criado
            )
        {
            // colocar png botao do palco 
            ProximoPasso();
        }
        if (passoAtual == 13
            // && detectar objeto de construcao criado
            )
        {
            // colocar png botao do palco 
            ProximoPasso();
        }
        if (passoAtual == 14
            // && detectar objeto de construcao criado
            )
        {
            // colocar png botao do palco 
            ProximoPasso();
        }
    }
}
