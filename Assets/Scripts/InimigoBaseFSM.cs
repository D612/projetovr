using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InimigoBaseFSM : StateMachineBehaviour
{
    public GameObject npc; // Inimigo
    public float precisao = 3.0f; // precisao entre a distancia do npc até o waypoint atual
    public float rotVelocidade = 1.0f; //velocidade da rotação
    public float velocidade = 2.0f; // velocidade de deslocamento para o proximo waypoint
    public GameObject jogador; //referencia do meu jogador na cena

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
        npc = animator.gameObject;
        jogador = GameObject.FindGameObjectWithTag("Player"); //Atribuindo o jogador com base a referencia da tag Player
    }
}
