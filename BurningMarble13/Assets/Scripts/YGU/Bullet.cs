using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //총알이 몬스터를 따라가서 쏘게하기
    Transform target;
    public float speed;
    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            // 몬스터 방향으로 이동
            Vector3 direction = (target.position - transform.position).normalized;
            transform.position += direction * speed * Time.deltaTime;

            // 목표에 도달하면 총알 제거
            float distanceToTarget = Vector3.Distance(transform.position, target.position);
            if (distanceToTarget < 0.1f)
            {
                ApplyDamage();
                Destroy(gameObject);
                // 여기서 몬스터에게 데미지를 입히거나 다른 동작을 수행할 수 있습니다.
                
            }
        }
        else
        {
            // 몬스터가 없으면 총알 제거
            Destroy(gameObject);
        }

    }

    protected virtual void ApplyDamage()
    {
        //타켓에게 데미지 주기
        
    }

    public void Initialize(Transform monsterTrans)
    {
        target = monsterTrans;
    }
}
