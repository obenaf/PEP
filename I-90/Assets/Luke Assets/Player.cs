
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{

    private int nextLevel;
    private int currentLevel;
    public bool allowAttack = true;

    public SoldierMovement closestEnemyMovementScripts;

    void Awake()
    {
        //maxHealth = 10;
        //attack = 5;
        //accuracy = 50;
        movement = 5;
        //armor = 0;
        range = 2;
        experience = 0;
        nextLevel = currentLevel * 100;
        isRanged = true;
    }
    void Start()
    {
        levelManager = GameObject.FindGameObjectWithTag("level0Manager");
        levelManagerScripts = levelManager.GetComponent<Level0Manager>();

        attackOptions = GameObject.FindGameObjectWithTag("Attacks");
        attackScripts = attackOptions.GetComponent<Attacks>();
        
        //enemy = GameObject.FindGameObjectWithTag("Enemy");
        //SoldierMovement = GameObject.FindGameObjectWithTag("Enemy");
        allEnemies = GameObject.FindObjectsOfType<Enemy>();

        playerMovement = GameObject.FindGameObjectWithTag("Player");
        playerMovementScripts = playerMovement.GetComponent<PlayerMovement>();

        currentHealth = maxHealth;
  
    }

    
    void FixedUpdate()
    {
        float attackInput;
        //Look to simplify these if statements
        if (levelManagerScripts.turnManager() == true && allowAttack == true){
            attackInput = Input.GetAxisRaw("Fire1");
            if (attackInput == 1){
                allowAttack = false;
                attackInput = 0;
                findClosestEnemy();
                enemyMovementScripts = closestEnemy.GetComponent<SoldierMovement>();
                enemyScripts = closestEnemy.GetComponent<Enemy>(); 

                if ((isRanged == true) && (attackPossible(range) == true))
                {
                    
                    attackScripts.spawnArrow();    
                    missles = GameObject.FindGameObjectWithTag("Missle");
                    missleScripts = missles.GetComponent<Missle>(); 
                    levelManagerScripts.changeTurn();             
                                             
                }
                if ((isRanged == false) && (attackPossible(range) == true))
                {
                    int damage;
                    damage = attackScripts.getMeleeDamage(attack, accuracy);
                    enemyScripts.damageEnemy(damage);
                    levelManagerScripts.changeTurn();                    
                } 
                StartCoroutine(changeAllowAttack());            
            }
            
        }
        if (currentHealth <= 0)
        {
            playerDies();
        }
        if (missleScripts.wasHitSuccesful() == true)
        {
            int damage;
            damage = attackScripts.getRangeDamage(attack, accuracy);
            enemyScripts.damageEnemy(damage); 
            Destroy(missles);
            missles = null;
            missleScripts = null; 
        }
    }

    public float getMovement()
    {
        return movement;
    }
    protected override bool attackPossible(float range)
    {
        return base.attackPossible(range);
    }
    public void gainExperience(int newExp)
    {
        experience = experience + newExp;
        if (experience > nextLevel)
        {
            gainLevel();
        }
    }
    public void gainLevel()
    {
        currentLevel++;
        maxHealth = maxHealth + 5;
        currentHealth = currentHealth +5;
        attack++;
        armor = armor + 2;
    }
    public void findEnemies()
    {
        allEnemies = GameObject.FindObjectsOfType<Enemy>();
    }
    public void damagePlayer(int damage)
    {
        currentHealth = currentHealth - damage;
        Debug.Log("Player Damaged");
    }
    public void playerDies()
    {

    }

    public int getHealth()
    {
        return currentHealth;
    }
    IEnumerator changeAllowAttack(){
        yield return new WaitForSeconds(1);
        allowAttack = true;
        Debug.Log("Changed allowAttack");
    }
    public void findClosestEnemy()
    {
        foreach (Enemy currentEnemy in allEnemies)
        {
            if (currentEnemy != null)
            {
                if (closestEnemy == null)
                {
                    closestEnemy = currentEnemy;
                }
                else//determine if current enemy in loop is closer than 'closestEnemy'
                {
                    float currentPosX, currentPosY, closestPosX, closestPosY, closestTotal, currentTotal, myPositionX, myPositionY;
                    closestTotal = 0f;
                    currentTotal = 0f;
                    myPositionX = playerMovementScripts.getPositionX();
                    myPositionY = playerMovementScripts.getPositionY();

                    enemyMovementScripts = currentEnemy.GetComponent<SoldierMovement>();
                    currentPosX = enemyMovementScripts.getPositionX();
                    currentPosY = enemyMovementScripts.getPositionY();
                
                    closestEnemyMovementScripts = closestEnemy.GetComponent<SoldierMovement>();
                    closestPosX = closestEnemyMovementScripts.getPositionX();
                    closestPosY = closestEnemyMovementScripts.getPositionY();

                    closestTotal = Mathf.Sqrt(((closestPosX-myPositionX) * (closestPosX - myPositionX)) + ((closestPosY - myPositionY) * (closestPosY - myPositionY)));
                    currentTotal = Mathf.Sqrt(((currentPosX-myPositionX) * (currentPosX - myPositionX)) + ((currentPosY - myPositionY) * (currentPosY - myPositionY)));
                    
                    if (currentTotal < closestTotal)
                    {                        
                        closestEnemy = currentEnemy;
                    }
                }
            }
        }
    }    
}

