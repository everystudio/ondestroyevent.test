using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitGenerator : MonoBehaviour
{
    [Range(1, 10)]
    public int m_iUnitLimit;

    [Range(1.0f,5.0f)]
    public float m_fGenerateInterval;

    [SerializeField]
    private GameObject m_prefUnit;

    public Text m_txtUnitNum;

    private float m_fTime;
    private int m_iUnitNum;

    void Start()
    {
        m_fTime = 0.0f;
        m_iUnitNum = 0;
        ShowUI(m_iUnitNum);
    }

    void Update()
    {
        m_fTime += Time.deltaTime;
        if( m_fGenerateInterval <= m_fTime)
        {
            m_fTime -= m_fGenerateInterval;
            GenerateUnit();
        }
    }
    public void GenerateUnit()
    {
        if( m_iUnitLimit <= m_iUnitNum)
        {
            return;
        }

        UnitController unit = (Instantiate(m_prefUnit) as GameObject)
            .GetComponent<UnitController>();
        unit.Initialize(1.0f, new Vector2(1.0f, 0.0f));
        unit.DestroyedEvent.AddListener(UnitDestroyed);

        // 一定時間後に消える
        Destroy(unit.gameObject, 15.0f);

        m_iUnitNum += 1;
        ShowUI(m_iUnitNum);
        return;
    }
    private void ShowUI(int _iUnitNum)
    {
        m_txtUnitNum.text = string.Format("ユニットの数：{0}", _iUnitNum);
    }
    public void UnitDestroyed()
    {
        m_iUnitNum -= 1;
        ShowUI(m_iUnitNum);
    }
}
