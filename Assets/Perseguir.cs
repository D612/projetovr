using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Perseguir : InimigoBaseFSM
{
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);//Passando referencias de animação, estado, para a classe pai
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //Determina a distancia da direção que o npc precisa se deslocar
        var distanciaDirecao = jogador.transform.position - npc.transform.position;

        //Rotaciona o npc para a direção do proximo waypoit com uma velocidade 1 segundo de rotação padrão
        npc.transform.rotation = Quaternion.Slerp(npc.transform.rotation, Quaternion.LookRotation(distanciaDirecao), rotVelocidade * Time.deltaTime);

        npc.transform.Translate(0, 0, velocidade * Time.deltaTime);
    }

}
