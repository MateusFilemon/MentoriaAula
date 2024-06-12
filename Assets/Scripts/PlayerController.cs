using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : HealthController
{
    public static PlayerController instance;

    public Rigidbody2D rb;
    public float moveSpeed;
    public float jumpForce;
    private Vector2 direction;

    public Transform foot;
    public LayerMask ground;
    public bool onGround;
    

    public float attackDamage;
    public float attackRange;
    public Transform attackPoint;
    public LayerMask enemyLayers;
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
        currentHealth = maxHealth;
    }

    private void Start()
    {
        healthBar.SetMaxHealth(maxHealth);
    }

    void Update()
    {
        rb.velocity = new Vector2(direction.x * moveSpeed, rb.velocity.y);
        // TOPDOWN: rb.velocity = new Vector2(direction.x * moveSpeed, direction.x * moveSpeed rb.velocity.y);
        //rb.velocity = new Vector2(Input.GetAxis("Horizontal") * moveSpeed, Input.GetAxis("Vertical") * moveSpeed);
        anim.SetFloat("Speed", Mathf.Abs(rb.velocity.x));

        //fazer o sprite mudar de direção
        if ((rb.velocity.x > 0 && transform.localScale.x <0) || (rb.velocity.x < 0 && transform.localScale.x > 0))
        {
            Vector2 _localScale = transform.localScale;
            _localScale.x *= -1f; 
            transform.localScale = _localScale;
        }

        onGround = Physics2D.OverlapCircle(foot.position, .2f, ground);
        anim.SetBool("OnGround", onGround);

      

        if (Input.GetButtonDown("Fire2"))
        {
            isHeavyAttack = true;

            Attack();
        }

    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

    public void MovementAction(InputAction.CallbackContext value) 
    {
        //o valor do vetor x de direction é igual ao vetor x do input
        direction.x = value.ReadValue<Vector2>().x;
        //TOPDOWN: direction = value.ReadValue<Vector2>();
        //direction serve para subir escadas também!
    }

    public void JumpAction(InputAction.CallbackContext value) 
    {
        if(value.performed) 
        {
            if (onGround)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            }

        }

    }

    public void QuickAttack(InputAction.CallbackContext value) 
    { 
        if (value.performed) 
        {
            isHeavyAttack = false;

            Attack();
        }
    }

    public void HeavyAttack(InputAction.CallbackContext value) 
    { 
        if (value.performed)
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

    public void DealDamage()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach (Collider2D enemy in hitEnemies)
        {
            if (isHeavyAttack)
            {
                enemy.GetComponent<HealthController>().TakeDamage(attackDamage * 2);
            }
            else
            {
                enemy.GetComponent<HealthController>().TakeDamage(attackDamage);
            }
        }
    }


}
