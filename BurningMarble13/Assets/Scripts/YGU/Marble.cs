using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Marble : MonoBehaviour
{
    //Fire,Electricity,Wind,Poison,Ice,Iron,Stone,Bow,Laser,Light
    //Fire>몬스터 공격시 타켓 주변에 스플래시 화염데미지
    //Electricity>몬스터 공격시 타겟을 포함한 3개의 몬스터에게각각 전기데미지
    ////////////Wind>몬스터를 빠른속도로 공격
    //Poison>몬스터 공격시 독디버프 초당 독 데미지
    //Ice>몬스터 공격시 얼음디버프를 남겨 이동속도 감소 최대3회 중첩(이동속도 최50퍼 감속)
    //Iron>보스공격시 2배 데미지
    //Stone>15초마다 경로끝에서 시작점까지 이동하는 돌소환(일덩확률로 1초간 기절)
    //Bow>5회 공격 시마다 업그레이드 수 만큼 무작위 타겟에게 화살발사
    //Laser>10회 공격할때마다 일직선 범위의 적을 레이저로 공격
    //Light>범위만큼 공격속도 증가 버프
    //공격,죽이기..?
    //공통:공격력(기본)>바람,돌,활,레이저,빛/공격속도:불,전기,독,얼음,쇠,돌,활,레이저,빛

    int attack = 20;
    float attackSpeed = 1.5f;//총알생성속도
    float attackRange;//총알날라갈수있는범위

    private float totalTime = 0;

    public GameObject bulletprefeb;
    public Transform testMonster;

    private MarbleSkill.MarbleType type;

    void Update()
    {
        //총알 날라가는 범위
        if(testMonster == null)
        {
            return;
        }
        if (Vector3.Distance(transform.position, testMonster.transform.position) > attackRange)
        {
            return;//내위치 몬스터위치 를 총알범위와비교
        }

        totalTime += Time.deltaTime;

        if (totalTime >= attackSpeed)
        {
            switch(type)
            {
                case MarbleSkill.MarbleType.Fire:
                    Attack();
                    Debug.Log("FireAttack");
                    break;
                case MarbleSkill.MarbleType.Electricity:
                    Attack();
                    Debug.Log("ElectricityAttack");
                    break;
                case MarbleSkill.MarbleType.Wind:
                    WindAttack();
                    Debug.Log("WindAttack");
                    break;
                case MarbleSkill.MarbleType.Poison:
                    Attack();
                    Debug.Log("PoisonAttack");
                    break;
                case MarbleSkill.MarbleType.Ice:
                    Attack();
                    Debug.Log("IceAttack");
                    break;
                case MarbleSkill.MarbleType.Iron:
                    Attack();
                    Debug.Log("IronAttack");
                    break;
                case MarbleSkill.MarbleType.Stone:
                    Attack();
                    Debug.Log("StoneAttack");
                    break;
                case MarbleSkill.MarbleType.Bow:
                    Attack();
                    Debug.Log("BowAttack");
                    break;
                case MarbleSkill.MarbleType.Laser:
                    Attack();
                    Debug.Log("LaserAttack");
                    break;
                case MarbleSkill.MarbleType.Light:
                    Attack();
                    Debug.Log("LightAttack");
                    break;

            }
            totalTime = 0;
        }
        
    }
    void Attack()
    {
        //투사체가 생성되고(날라감)
        GameObject go = Instantiate(bulletprefeb);
        //내 위치로 투사체를 가져온다
        go.transform.position = transform.position;
        //Debug.Log("attack");
        Bullet bullet = go.GetComponent<Bullet>();
        bullet.Initialize(testMonster);//잡을몬스터입력
    }

    private void WindAttack()
    {
        GameObject go = Instantiate(bulletprefeb);
        go.transform.position = transform.position;//시작점

        Bullet bullet = go.GetComponent<Bullet>();
        bullet.Initialize(testMonster);//따라갈몬스터입력
    }

    public void SetMarbleStatus(MarbleSkill.MarbleType type, MarbleSkill.Status[] status)
    {
        attack = status[(int)type].attack;
        attackSpeed = status[(int)type].attackSpeed;
        attackRange = status[(int)type].attackRange;

        this.type = type;
    }

}
