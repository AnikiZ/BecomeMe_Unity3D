using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
  public static int health = 500;
  public static int maxHealth = 500;
  public static float attackRange = 3f;
  public static float speed = 4f;
  public static int damage = 20;

  public static bool willDie = false;

  public static bool DetectAttackRange ()
  {
    Transform player = GameObject.FindGameObjectWithTag("Player").transform;
    Transform monster = GameObject.FindGameObjectWithTag("Monster").transform;
    bool isInAttackRange = (Vector3.Distance(player.position, monster.position) < attackRange);
    return isInAttackRange;
  }
  
  public static void DetectSlash ()
  {
    BoxCollider playerCollider = GameObject.FindGameObjectWithTag("Player").GetComponent<BoxCollider>();
    SkinnedMeshRenderer monsterSwordCollider = GameObject.FindGameObjectWithTag("Monster_Sword").GetComponent<SkinnedMeshRenderer>();
    bool causeDamage = monsterSwordCollider.bounds.Intersects(playerCollider.bounds);
    if (causeDamage)
    {
      FirstPlayer.RemoveHealth(damage);
    }
  }

  public static void RemoveHealth (int damage)
  {
    GameObject Canvas = GameObject.FindGameObjectWithTag("Canvas");
    RectTransform CanvasRC = Canvas.GetComponent<RectTransform>();
    GameObject MonsterHP = GameObject.FindGameObjectWithTag("MonsterHP");
    RectTransform MonsterHPRC = MonsterHP.GetComponent<RectTransform>();
    int actualDamage = health;
    if (health - damage > 0)
    {
      actualDamage = damage;
    }
    float ratio = (float) actualDamage / maxHealth;
    CanvasUtils.ReduceMonsterRight(MonsterHPRC, (float) ratio);
    // MyHPRC.offsetMax = new Vector2(MyHPRC.offsetMax.x - right, MyHPRC.offsetMax.y);
    health = health - actualDamage;
    if (health <= 0)
    {
      Die();
    }
  }

  public static void Die ()
  {
    Monster.willDie = true;
  }
}
