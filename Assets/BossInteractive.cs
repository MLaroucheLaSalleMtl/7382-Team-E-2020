using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Pathfinding;

public class BossInteractive : MonoBehaviour
{
    [SerializeField] private float BossHp = 400;
    private float BossCurHp = 400;
    [SerializeField] private Slider sliderHp;
    private Animator anim;

    private bool trigOnce = false;

    AsyncOperation async;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponentInChildren<Animator>();
        async = SceneManager.LoadSceneAsync("EndScene");
        async.allowSceneActivation = false;
        BossCurHp = BossHp;
    }

    // Update is called once per frame
    void Update()
    {
        sliderHp.value = BossCurHp / BossHp;
        if (BossCurHp <= 0 && !trigOnce)
        {
            anim.SetTrigger("Death");
            Invoke("PlayEnd", 3);
            // async.allowSceneActivation = true;

            GetComponent<AIPath>().enabled = false;
            trigOnce = true;
        }
    }

    private void PlayEnd()
    {
        async.allowSceneActivation = true;
    }

    public void TakeDamage(int damage)
    {
        this.BossCurHp -= damage;
    }
}
