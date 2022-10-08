using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpController : MonoBehaviour
{
    // 체력바
    public Slider HpSlider;

    public Text HpText;

    // 플레이어 체력
    private float MaxHp;

    public float CurrentHp;

    // Start is called before the first frame update
    void Start()
    {
        MaxHp = 100f;
        CurrentHp = 100f;
    }

    // Update is called once per frame
    void Update()
    {
        // 체력바 비율
        HpSlider.value = CurrentHp / MaxHp;

        HpText.text = CurrentHp + " / " + MaxHp;
    }
}
