using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UnitController : MonoBehaviour
{
	public UnityEvent DestroyedEvent = new UnityEvent();
    private float m_fSpeed;
    private Vector2 m_vec2Dir;

    public void Initialize(float _fSpeed , Vector2 _vec2Dir)
    {
        m_fSpeed = _fSpeed;
        m_vec2Dir = _vec2Dir.normalized;
    }

    void Update()
    {
        transform.Translate(
            m_vec2Dir.x * m_fSpeed * Time.deltaTime,
            m_vec2Dir.y * m_fSpeed * Time.deltaTime,
            0.0f
            );
    }
    private void OnMouseDown()
    {
        Destroy(gameObject);
    }
    private void OnDestroy()
    {
        DestroyedEvent.Invoke();
    }
}
