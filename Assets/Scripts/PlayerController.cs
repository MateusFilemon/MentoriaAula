using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;
    public float moveSpeed;
    public float jumpForce;

    //bool binario = Dois tipos de info, Verdadeiro ou Falso;
    //int numeroInteiro;
    //float numeroQuebrado;
    //Vector2 vetores = Vetores XY;
    //Transform transformacao = Escala, rotação, direção, local do personagem...;
    //GameObject objeto = Acessar as propriedades (visibilidade etc) de um objeto de jogo;
    //private = so pode ser acessado por este script;
    //Variaveis começam com letra minuscula
    //metodos são funçoes dentro do script;
    //Start(quando o jogo começa) e Update(uma atualização a cada frame, sempre chamando);
    //Awake = tela de carregamento, bem no começo. Antes do jogo começar;
    
    private void Awake()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rb.velocity = new Vector2(Input.GetAxis("Horizontal") * moveSpeed, rb.velocity.y);
        //rb.velocity = new Vector2(Input.GetAxis("Horizontal") * moveSpeed, Input.GetAxis("Vertical") * moveSpeed);


    }

    //public void SetSpeed()
    //{
        //moveSpeed = Time.deltaTime;
        //Time.deltaTime = tempo em jogo, segundos em que o jogo ta rodando
    //}
}
