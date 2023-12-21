using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] private TextMeshProUGUI points_txt;
    [SerializeField] private TextMeshProUGUI life_txt;

    [SerializeField] private int points_number = 0;
    public int playerLife = 3;

    void Start()
    {
        instance = this;
        life_txt.text = "X" + playerLife.ToString();
    }

    void Update()
    {
        /*points_txt.text = points_number.ToString();*/ // testar depois se fica melhor aqui!
    }

    public void PointSystem(int point)
    {
        points_number += point;
        points_txt.text = points_number.ToString();
    }

    }
