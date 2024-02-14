using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    private int wayPointCount;
    private Transform[] wayPoints;
    private int currentIndex = 0;
    private MonsterMovement movement;
    //**private WaveSystem waveSystem;    

    //[HideInInspector]
    public GameManager.MobType mobType;
    
    public float hp = 0;
    //왜째서 나는 0으로 저장했건만

    [HideInInspector]
    public static int goalMonster = 0;

    private void Awake()
    {
        //**waveSystem = GameManager.Instance.GetComponent<WaveSystem>();
    }

    private void Update()
    {
        //Damage();//kill대신 자동damge
    }

    public void Setup(Transform[] spawnPoints)
    {
        movement = GetComponent<MonsterMovement>();

        this.wayPoints = spawnPoints;
        wayPointCount = spawnPoints.Length;

        transform.position = wayPoints[currentIndex].position;

        StartCoroutine("OnMove");
    }


    private IEnumerator OnMove()
    {
        NextMoveTo();

        while (true)
        {
            if (Vector3.Distance(transform.position, wayPoints[currentIndex].position) < 0.02f * movement.MoveSpeed)
            {
                NextMoveTo();
            }
            yield return null;
        }
    }

    private void NextMoveTo()
    {
        if (currentIndex < wayPointCount - 1)
        {
            transform.position = wayPoints[currentIndex].position;
            currentIndex++;
            Vector3 direction = (wayPoints[currentIndex].position - transform.position).normalized;
            movement.MoveTo(direction);
        }
        else
        {
            goalMonster++; //몬스터골에
            GameManager.killMonster++; // 하트가 삭제되면 KillMonster 1증가
            GameManager.Instance.Life(goalMonster - 1);
            // 목숨 오브젝트도 한개씩 삭제
            // 경섭님 GameScene UI 만들어주세요! 필요해요! 하트포함! 목숨 은 하나씩 삭제할수있게
            // 만듬

            if (goalMonster == 3)
            {
                Debug.Log("GAMEOVER");
                StopAllCoroutines();
                Time.timeScale = 0;
                GameManager.Instance.GameOverUIOpen();//임시 GameOverUI

                goalMonster = 0;
            }
            Destroy(gameObject);               
            
            Debug.Log(goalMonster);
        }
    }

    public void Damage()//kill대신 자동damge
    {
        hp -= (5 * Time.deltaTime);
        if(hp <= 0)
        {
            GameManager.killMonster++;
            GameManager.Instance.PlusGold(mobType);
            Debug.Log(GameManager.killMonster);            
            Destroy(gameObject);
        }
    }
}
