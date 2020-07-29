using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class VRGazeMenu : MonoBehaviour
{
    public Image imgGaze;//referencia do componente de circulo do Gaze
    bool gvrStatus; // estado se o gaze foi ativado ou não
    float gvrTimer; // tempo de referencia inicial
    public UnityEvent GVRClick;

    public float tempoTotal = 2;//tempo em segundos para a execução do efeito

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Verificar se o gaze foi ativado
        if (gvrStatus) {
            gvrTimer += Time.deltaTime; //tempo inicial quando é ativado
            imgGaze.fillAmount = gvrTimer / tempoTotal; //variação do preenchimento do efeito ao longo do tempo
        }

        //Invocar o clique quando completar o carregamento do Gaze
        if(gvrTimer > tempoTotal) {
            GVRClick.Invoke();
        }
    }

    //função para disparar o Gaze
    public void GVROn() {
        gvrStatus = true;
    }

    //Função para desligar o Gaze
    public void GVROff() {
        gvrStatus = false;
        gvrTimer = 0;
        imgGaze.fillAmount = 0;
    }
}
