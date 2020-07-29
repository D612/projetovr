using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporte : MonoBehaviour
{
    private GameObject player; //referencia do jogador
    public float moverEmY = 1.5f; //vai mover em Y 

    private void Start() {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public void MoverJogador() {
        player.transform.position = new Vector3(transform.position.x, transform.position.y + moverEmY, transform.position.z); // realizando a movimentação do jogador e adicionando 1.5 de altura
    }
}
