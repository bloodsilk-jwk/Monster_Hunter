using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HpController : MonoBehaviour
{
    // ü�¹�
    public Slider HpSlider;

    public Text HpText;

    // �÷��̾� ü��
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
        // ü�¹� ����
        HpSlider.value = CurrentHp / MaxHp;

        HpText.text = CurrentHp + " / " + MaxHp;
    }
}
