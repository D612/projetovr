using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private GameObject arma; //Declarando a referencia para a arma
    private GameObject spawnPoint; //Declarando a referencia do ponto onde será criado os projeteis
    public float distanciaParaAtirar = 100; //Distancia que o raycast vai detectar objetos
    public float tempoIntervaloTiro = 1; //Tempo do intervalo entre um tiro e o outro
    private bool estaAtirando;//Declarando uma variavel auxiliar para verificar se jogador esta atirando
    public float forcaTiro; //Força do Tiro
    public float tempoDestruicaoTiro; //Tempo em que o tiro será destruido depois de criado

    // Start is called before the first frame update
    void Start()
    {
        arma = this.gameObject.transform.GetChild(1).gameObject; //Definindo as referencias para a arma
        spawnPoint = arma.transform.GetChild(1).gameObject; //Definindo o spawnpoint dos tiros
        estaAtirando = false; //Definindo quando se inicia o jogo, que o jogador não esta atirando, ou seja, falso
    }


    IEnumerator Atirar() {

        estaAtirando = true; //Se estiver atirando, não vai instanciar para atirar continuamente
        GameObject tiro = Instantiate(Resources.Load("Projetil", typeof(GameObject))) as GameObject;
        Rigidbody rb = tiro.GetComponent<Rigidbody>();//Instanciando o rigidbody do tiro e vai fazer com que ele receba o componente
        tiro.transform.position = spawnPoint.transform.position;
        tiro.transform.rotation = spawnPoint.transform.rotation;
        rb.AddForce(spawnPoint.transform.forward * forcaTiro);

        arma.GetComponent<AudioSource>().Play();// Realizando a execução do audio de tiro
        arma.GetComponent<Animation>().Play("CoiceArma");// Realizando animação do coice da arma
        Destroy(tiro, tempoDestruicaoTiro); //Tempo que o tiro será destruido depois de ser criado
        yield return new WaitForSeconds(tempoIntervaloTiro);
        estaAtirando = false;
    }

    // Update is called once per frame
    void Update()
    {
        //Declarando o Raycasthit
        RaycastHit hit;

        // Invocando o raio do spawnpoint na direção para frente do vetor
        if(Physics.Raycast(spawnPoint.transform.position, spawnPoint.transform.forward, out hit, distanciaParaAtirar)) {
            //Debug.DrawLine(transform.position, hit.point, Color.red);
            // verificar se o raycast atingiu um objeto do tipo Inimigo, se for verdadeiro vai atirar
            if (hit.collider.gameObject.tag.Equals("Inimigo")) {
                //Debug.Log("Alvo Inimigo Detectado");
                if (!estaAtirando) { 
                    StartCoroutine("Atirar");
                }
            }
        }
    }
}
