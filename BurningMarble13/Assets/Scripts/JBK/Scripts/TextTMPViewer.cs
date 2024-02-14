using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextTMPViewer : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI textWave;
    [SerializeField]
    private TextMeshProUGUI textGold;

    [SerializeField]
    private WaveSystem waveSystem;

    void Update()
    {
        TextWave();
        TextGold();
    }

    private void TextWave()
    {
        // ���Ǵ�Ƽ��带 �����ϸ� MaxWave�� ???�� ����(�ӽ�)
        // ���Ǵ�Ƽ ��尡 int�� �ִ밪�̶� 100�̻����� ����(�ӽ�)
        if(waveSystem.MaxWave >= 100)
        {
            textWave.text = "WAVE " + (WaveSystem.currentWave) + " / ???";
        }
        else
        {
            textWave.text = "WAVE " + (WaveSystem.currentWave) + " / " + waveSystem.MaxWave;
        }
        
    }
    private void TextGold()
    {
        int gold = GameManager.Instance.gold;

        textGold.text = gold.ToString();
    }
}