using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    private int lives = 3;

    [SerializeField] private List<SpriteRenderer> hearts;
    [SerializeField] private Sprite fullHeart;
    [SerializeField] private Sprite emptyHeart;

    public void UpdateLives(int newLives)
    {
        if(newLives >= 0)
        {
            lives = newLives;
            for (int i = 0; i < hearts.Count; i++)
            {
                if(i < lives)
                {
                    hearts[i].sprite = fullHeart;
                }
                else
                {
                    hearts[i].sprite = emptyHeart;
                }
            }
        }

    }
}
