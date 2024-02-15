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
    ////////////Iron>보스공격시 2배 데미지
    //Stone>15초마다 경로끝에서 시작점까지 이동하는 돌소환(일덩확률로 1초간 기절)
    ////////////Bow>5회 공격 시마다 업그레이드 수 만큼 무작위 타겟에게 화살발사
    ///임시로 5회공격시 강한공격1회로 바꿈
    //Laser>10회 공격할때마다 일직선 범위의 적을 레이저로 공격
    ////////////Light>범위만큼 공격속도 증가 버프
    ///게임매니저와 협업예정
    ///
    ///맵에 구현이 된 몬스터를 어떻게 알것인지.
    ///맵에 구현되어있는 구슬을 어떻게 알것인지
    ///이걸 우리가 할수있을까..?

    //공격,죽이기..?
    //공통:공격력(기본)>바람,돌,활,레이저,빛/공격속도:불,전기,독,얼음,쇠,돌,활,레이저,빛

    float attack = 20;
    float attackSpeed = 1.5f;//총알생성속도
    float attackRange;//총알날라갈수있는범위
    int attackBullet;//날라간총알

    private float totalTime = 0;

    public GameObject bulletprefeb;
    public GameObject bigPrefab;
    public Monster testMonster;
    //public Transform testMonster;

    private MarbleSet.MarbleType type;

    void Update()
    {
        //총알 날라가는 범위
        if (testMonster == null)
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
            Attack();
            totalTime = 0;
            Debug.Log(type + "Attack");
        }
    }

    private void Attack()
    {
        GameObject go;
        go = Instantiate(bulletprefeb);
        go.transform.position = transform.position;//시작점

        Bullet bullet;

        switch (type)
        {
            case MarbleSet.MarbleType.Fire:
                break;
            case MarbleSet.MarbleType.Electricity:
                break;
            case MarbleSet.MarbleType.Poison:
                break;
            case MarbleSet.MarbleType.Ice:
                break;
            case MarbleSet.MarbleType.Stone:
                break;
            case MarbleSet.MarbleType.Bow:
                if (attackBullet == 5)
                {
                    Destroy(go);
                    go = Instantiate(bigPrefab);
                    go.transform.position = transform.position;
                    attackBullet = 0;
                }
                else
                    attackBullet++;
                bullet = go.GetComponent<Bullet>();
                bullet.Initialize(testMonster, attack);//따라갈몬스터입력
                break;
            case MarbleSet.MarbleType.Laser:
                break;
            case MarbleSet.MarbleType.Light:
                /*
                 if (Vector3.Distance(transform.position, testMonster.transform.position) > attackRange)
        {
            return;//내위치 몬스터위치 를 총알범위와비교

                내위치 마블위치를 비교해서 내 범위보다 작으면
                마블위치->게임매니저에서 만들때마다 배열에 넣기
                배열은 게임매니저만들때 맵별로 마블생성할수있는위치,개수정해서
                만들어두기
                그 배열에 들어있는 마블의 트랜스폼과 비교하면 될듯
        }
                 */
                break;
        }

        
    }

    public void SetMarbleStatus(MarbleSet.MarbleType type, MarbleSet.Status[] status)
    {
        attack = status[(int)type].attack;
        attackSpeed = status[(int)type].attackSpeed;
        attackRange = status[(int)type].attackRange;

        this.type = type;
    }

}
