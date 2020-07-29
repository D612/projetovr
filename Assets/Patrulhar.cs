using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrulhar : InimigoBaseFSM
{
    GameObject[] waypoints;// declaração da lista de waypoints
    int waypointAtual; // variavel auxiliar para identificar o waypoint atual

    private void Awake() {
        waypoints = GameObject.FindGameObjectsWithTag("waypoint"); //Quando iniciar o jogo, vai buscar em toda cena, os objetos que possuem a tag "waypoint" atribuida
    }

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);//Passando referencias de animação, estado, para a classe pai
        waypointAtual = 0; //waypoint atual quando começar, será considerado 0
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (waypoints.Length == 0) return; // Se não existir waypoints na cena, ele retorna sem executar nada

        //Se a distancia entre a posição do waypoint atual e do npc for menor do que o valor de precisao
        if (Vector3.Distance(waypoints[waypointAtual].transform.position, npc.transform.position) < precisao) {
            waypointAtual++; //passa para o proximo waypoint
            if(waypointAtual >= waypoints.Length) {
                waypointAtual = 0; // prevenção de IndexArrayOfBoundException, do codigo tentar indexar ma posição superior que não existe
            }
        }

        //Determina a distancia da direção que o npc precisa se deslocar
        var distanciaDirecao = waypoints[waypointAtual].transform.position - npc.transform.position;

        //Rotaciona o npc para a direção do proximo waypoit com uma velocidade 1 segundo de rotação padrão
        npc.transform.rotation = Quaternion.Slerp(npc.transform.rotation, Quaternion.LookRotation(distanciaDirecao), rotVelocidade * Time.deltaTime);

        npc.transform.Translate(0, 0, velocidade * Time.deltaTime);
    }
}
