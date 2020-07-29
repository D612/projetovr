using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcionarAlavanca : StateMachineBehaviour
{
    //Variavel de referencia do animator controller da minha porta
    public Animator anim;
    // Variavel auxiliar do estado da porta
    public bool estadoPorta;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    //override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        //Atribuição da variavel buscando a Porta1 na cena e instanciando o Animator Controller que esta nela
        anim = GameObject.FindGameObjectWithTag("Porta1").GetComponent<Animator>();
        //variavel auxiliar para verificar o estado da porta entre aberto (true) ou fechado (false)
        estadoPorta = anim.GetBool("EstadoPortaAberta");

        //Se a porta estiver fechada, vai disparar o evento para abrir e vai alternar o estado da variavel auxiliar EstadoPortaAberta para true
        if (estadoPorta == false) { 
            anim.SetTrigger("AbrirPorta");
            anim.SetBool("EstadoPortaAberta", true);
        } else { //Se estiver aberta, vai disparar a animação para fechar e alternar o estado da variavel auxiliar EstadoPortaAberta para falso
            anim.SetTrigger("FecharPorta");
            anim.SetBool("EstadoPortaAberta", false);
        }
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
