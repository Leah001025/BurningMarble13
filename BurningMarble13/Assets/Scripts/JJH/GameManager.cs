using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [SerializeField]
    private GameObject Road1;
    [SerializeField]
    private GameObject Road2;
    [SerializeField]
    private GameObject Road3;
    [SerializeField]
    private GameObject Road4;

    [HideInInspector]
    public long gold = 0;

    // Start is called before the first frame update
    void Start()
    {
        int random = Random.Range(1, 4);
        Debug.Log(random);

        switch(random)
        {
            case 1:
                Road1.SetActive(true);
                break;
            case 2:
                Road2.SetActive(true);
                break;
            case 3:
                Road3.SetActive(true);
                break;
            case 4:
                Road4.SetActive(true);
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        /*if(���� ������ ü���� 0�� �Ǿ��� ��)
        {
            PlusGold();
        }*/
    }

    /* public void PlusGold()
    {
         switch(���� ����(Ÿ��))
            {
                case ����:
                    gold += 10;
                    break;
                case ����:
                    gold += 20;
                    break;
                case ����:
                    gold += 30;
                    break;
            }   
    }*/
}
