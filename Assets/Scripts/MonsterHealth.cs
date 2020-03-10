using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterHealth : MonoBehaviour
{
    private Slider slider;
    private float hp;
    private float MaxHp;

    // Start is called before the first frame update
    void Start()
    {
        MaxHp = GetComponentInParent<CrawlerNPC>().Health;
        slider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log(hp);
        hp = GetComponentInParent<CrawlerNPC>().Health;
        slider.value = hp/MaxHp ;
    }
}
