using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static MarbleSet;

public class Bullet : MonoBehaviour
{
    //총알이 몬스터를 따라가서 쏘게하기
    //Transform target;
    public float speed;//총알날라가는속도
    public BulletType type;

    private float bulletDamage;

    private Monster monster;
    private Marble marbel;


    public enum BulletType
    {
        Fire = 0,
        Electricity,
        Wind,
        Poison,
        Ice,
        Iron,
        Stone,
        Bow,
        Laser,
        Light,
        Big
    }

    void Update()
    {
        if (monster != null)
        {
            // 몬스터 방향으로 이동
            Vector3 direction = (monster.transform.position - transform.position).normalized;
            transform.position += direction * speed * Time.deltaTime;

            // 목표에 도달하면 총알 제거
            float distanceToTarget = Vector3.Distance(transform.position, monster.transform.position);
            if (distanceToTarget < 0.1f)
            {
                // 여기서 몬스터에게 데미지를 입히거나 다른 동작을 수행할 수 있습니다.
                //충돌작업
                switch (type)
                {
                    case BulletType.Fire:
                        break;
                    case BulletType.Electricity:
                        break;
                    case BulletType.Wind://기본attack
                        Damage();
                        break;
                    case BulletType.Poison:
                        break;
                    case BulletType.Ice:
                        break;
                    case BulletType.Iron://
                        if (monster.mobType == GameManager.MobType.Boss)
                        {
                            Damage(2);
                            Debug.Log("Hit " + monster.mobType);
                        }
                        else
                            Damage();
                        break;
                    case BulletType.Stone:
                        break;
                    case BulletType.Bow://기본attack
                        Damage();
                        break;
                    case BulletType.Laser:
                        break;
                    case BulletType.Light:
                        break;
                    case BulletType.Big://
                        Damage(3);
                        break;
                }
                Destroy(gameObject);
            }
        }
        else
        {
            // 몬스터가 없으면 총알 제거
            Destroy(gameObject);
        }

    }

    public void Initialize(Monster mob, float damage)//따라갈타겟의 transform넘겨주는용
    {
        monster = mob;
        bulletDamage = damage;
    }

    public void Damage(int plusDamage = 1)
    {
        float finalDamage = bulletDamage * plusDamage;
        if (monster.hp - finalDamage <= 0)
        {
            monster.hp = 0;
            Debug.Log("MonsterDead");
            Destroy(monster.gameObject);
        }
        else
        {
            monster.hp -= finalDamage;
            Debug.Log("monsterHp : " + monster.hp + " Damage : " + finalDamage);
        }
    }
}
