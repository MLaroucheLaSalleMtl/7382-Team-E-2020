using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChoiceScript : MonoBehaviour
{
    public GameObject QuestionBox;
    public GameObject Choice01;
    public GameObject Choice02;
    public GameObject Choice03;
    public int ChoiceMade;

    public void ChoiceOption1 ()
    {
        QuestionBox.GetComponent<Text>().text = "No! he is a main programmer! Get out!";
        GameObject.Find("Player").GetComponent<Rigidbody2D>().AddForce(new Vector2(20f, -5f), ForceMode2D.Impulse);
        ChoiceMade = 1;

    }

    public void ChoiceOption2()
    {
        QuestionBox.GetComponent<Text>().text = "Correct! press 'F', then you will see something!";
        ChoiceMade = 2;

    }

    public void ChoiceOption3()
    {
        QuestionBox.GetComponent<Text>().text = "Nope! He was taking care SOUND part! get out!!!";
        GameObject.Find("Player").GetComponent<Rigidbody2D>().AddForce(new Vector2(20f, -5f), ForceMode2D.Impulse);
        ChoiceMade = 3;

    }

    void Update()
    {
        
    }
}
