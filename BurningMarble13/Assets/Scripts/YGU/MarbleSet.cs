using DG.Tweening.Plugins;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MarbleSet : MonoBehaviour
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
        public float attack;
        public float attackSpeed;
        public float attackRange;

        public Status(float atk, float atkSpeed, float atkRange)
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
        setStatus[(int)MarbleType.Fire] = new Status(1, 1, 5);
        setStatus[(int)MarbleType.Electricity] = new Status(1, 1, 5);

        setStatus[(int)MarbleType.Wind] = new Status(5, 0.25f, 5);

        setStatus[(int)MarbleType.Poison] = new Status(1, 1, 5);
        setStatus[(int)MarbleType.Ice] = new Status(1, 1, 5);
        setStatus[(int)MarbleType.Iron] = new Status(10, 1, 5);
        setStatus[(int)MarbleType.Stone] = new Status(1, 1, 5);

        setStatus[(int)MarbleType.Bow] = new Status(5, 0.5f, 5);

        setStatus[(int)MarbleType.Laser] = new Status(1, 1, 5);
        setStatus[(int)MarbleType.Light] = new Status(1, 1, 5);
    }
}
