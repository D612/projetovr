using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VRGazeTeleporte : MonoBehaviour
{
    bool gvrStatus; // estado se o gaze foi ativado ou não
    float gvrTimer;//empo de referencia inicial
    public Image imgGaze;//referencia da imagem de circulo do Gaze
    public float tempoTotal;//tempo em segundos para a execução do efeito
    public int distanciaRaio;//Distancia do raio que percorrerá a partir da camera

    private RaycastHit hit;//Variavel auxiliar para verificar a colisão do raio

    // Update is called once per frame
    void Update()
    {
        //Verificar se o gaze foi ativado e realização do efeito
        if (gvrStatus) {
            gvrTimer += Time.deltaTime;//tempo inicial quando é ativado
            imgGaze.fillAmount = gvrTimer / tempoTotal;
        }

        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f)); //Criação do ponto do raio

        //Verificação se o raio colidiu com a plataforma durante o tempo
        if(Physics.Raycast(ray, out hit, distanciaRaio)) {
            if(imgGaze.fillAmount == 1 && hit.transform.CompareTag("Teleporte")) {
                hit.transform.gameObject.GetComponent<Teleporte>().MoverJogador();
            }
        }
    }

    //Função para disparar o Gaze
    public void GVROn() {
        gvrStatus = true;
    }
    // Função para desligar o Gaze
    public void GVROff() {
        gvrStatus = false;
        gvrTimer = 0;
        imgGaze.fillAmount = 0;
    }
}
