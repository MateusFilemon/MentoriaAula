using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    public Rigidbody2D rb;
    public float moveSpeed;
    public float jumpForce;
    public Transform foot;
    public LayerMask ground;
    public bool onGround;

    public bool canAttack;
    public bool isAttacking;
    public bool isHeavyAttack;

    public Animator anim;

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

    // Update is called once per frame
    private void Awake()
    {
        instance = this;
    }

    void Update()
    {
        rb.velocity = new Vector2(Input.GetAxis("Horizontal") * moveSpeed, rb.velocity.y);
        //rb.velocity = new Vector2(Input.GetAxis("Horizontal") * moveSpeed, Input.GetAxis("Vertical") * moveSpeed);
        anim.SetFloat("Speed", Mathf.Abs(rb.velocity.x)) ;

        if ((rb.velocity.x > 0 && transform.localScale.x <0) || (rb.velocity.x < 0 && transform.localScale.x > 0))
        {
            Vector2 _localScale = transform.localScale;
            _localScale.x *= -1f; 
            transform.localScale = _localScale;
        }

        onGround = Physics2D.OverlapCircle(foot.position, .2f, ground);
        anim.SetBool("OnGround", onGround);


        if(Input.GetButtonDown("Jump") && onGround)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        if (Input.GetButtonDown("Fire1"))
        {
            isHeavyAttack = false;

            Attack();
        }

        if (Input.GetButtonDown("Fire2"))
        {
            isHeavyAttack = true;

            Attack();
        }

    }

    //public void SetSpeed()
    //{
        //moveSpeed = Time.deltaTime;
        //Time.deltaTime = tempo em jogo, segundos em que o jogo ta rodando
    //}

    public void Attack()
    {
        if (canAttack)
        {
           isAttacking = true;
           canAttack = false;
        }
        else
        {
            return;
        }
    }
    public void AttackManager()
    {
        if (!canAttack)
        {
            canAttack = true;
        }
        else
        {
            canAttack = false;
        }
    }
 
}
