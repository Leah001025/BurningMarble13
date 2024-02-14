using DG.Tweening.Plugins;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MarbleSkill : MonoBehaviour
{
    private Marble marble;

    public MarbleType type;

    private Status[] setStatus = new Status[10];

    public enum MarbleType
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
        Light
    }

    public struct Status
    {
        public int attack;
        public float attackSpeed;
        public float attackRange;

        public Status(int atk, float atkSpeed, float atkRange)
        {
            attack = atk;
            attackSpeed = atkSpeed;
            attackRange = atkRange;
        }
    }

    private void Awake()
    {
        marble = GetComponent<Marble>();
    }

    private void Start()
    {
        SetStatus();

        marble.SetMarbleStatus(type, setStatus);

    }

    private void SetStatus()
    {
        setStatus[0] = new Status(1, 1, 5);
        setStatus[1] = new Status(1, 1, 5);

        setStatus[2] = new Status(5, 0.25f, 5);

        setStatus[3] = new Status(1, 1, 5);
        setStatus[4] = new Status(1, 1, 5);
        setStatus[5] = new Status(1, 1, 5);
        setStatus[6] = new Status(1, 1, 5);
        setStatus[7] = new Status(1, 1, 5);
        setStatus[8] = new Status(1, 1, 5);
        setStatus[9] = new Status(1, 1, 5);
    }
}
