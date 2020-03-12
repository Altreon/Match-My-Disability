using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SongBarSetting : MonoBehaviour
{

    [SerializeField] private int m_songScale = 10;
    [SerializeField] private Slider m_songSlider;
    private float m_deltat;
    private float m_volume;



    private void Start()
    {
        m_deltat = 100.0f / (float)m_songScale;
        m_volume = 100f;
        //Debug.Log("m_deltat = " + m_deltat);
    }


    public void DecreaseVolume()
    {
        if (m_volume > 0)
        {
            m_volume -= m_deltat;
            m_songSlider.value = m_volume / 100f;
            Debug.Log("Song decreases: " + m_volume);
        }
        else
        {
            m_volume = 0f;
            Debug.Log("Song can't be decreased");
        }
    }

    public void IncreaseVolume()
    {
        if (m_volume < 100)
        {
            m_volume += m_deltat;
            m_songSlider.value = m_volume / 100f;
            Debug.Log("Song increases: " + m_volume);
        }
        else
        {
            m_volume = 100f;
            Debug.Log("Song can't be increased");
        }
    }

    public float GetVolume()
    {
        return m_volume / 100f;
    }


    
    // Update is called once per frame
    void Update()
    {
        //transform.localScale
        if (Input.GetKeyDown(KeyCode.A))
        {
            IncreaseVolume();
        }
        else if (Input.GetKeyDown(KeyCode.Z))
        {
            DecreaseVolume();
        }
    }
    




    // Start is called before the first frame update
    /*
    void Start()
    {
        m_deltat = new Vector3(1.0f / (float) m_songScale, 0.0f, 0.0f);
    }
    

    // Update is called once per frame
    void Update()
    {
        //transform.localScale
        if (Input.GetKeyDown(KeyCode.A))
        {
            UpdateSongBar(false);
        }
        else if (Input.GetKeyDown(KeyCode.Z))
        {
            UpdateSongBar(true);
        }
    }

    private void UpdateSongBar(bool shouldIncrease)
    {
        if (shouldIncrease && (transform.localScale.x + m_deltat.x <= 1.0f))
        {
            transform.localScale += m_deltat;
            Debug.Log("Song increases: " + transform.localScale.x);
        }
        else if (shouldIncrease && transform.localScale.x + m_deltat.x > 1.0f)
        {
            //transform.localScale = new Vector3(1.0f, 0.0f, 0.0f);
            Debug.Log("Song can't be increased: " + transform.localScale.x);
        }
        else if (!shouldIncrease && transform.localScale.x - m_deltat.x >= 0.0f)
        {
            transform.localScale -= m_deltat;
            Debug.Log("Song decreases: " + transform.localScale.x);
        }
        else
        {
            Debug.Log("Song can't be changed: " + transform.localScale.x);
        }
    }
    */
}
