using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InimigoFixo : MonoBehaviour
{
    public int vida; //Quantidade de vida do inimigo

    private void OnTriggerEnter(Collider other) {
        if (other.gameObject.CompareTag("Projetil")) {
            vida--; //Variavel vida recebe o valor que tem, menos 1
            Destroy(other.gameObject);// Destruindo projetil que colidiu com Inimigo
            if(vida == 0) { // Se a vida for igual a 0, inimigo será destruido
                Destroy(this.gameObject); 
            }
        }
    }
}
