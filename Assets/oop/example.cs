using System;
using oop;
using UnityEngine;

public class example : MonoBehaviour
{
    // Start is called before the first frame update
    private Fighter hero, enemy;
    private Gun knife;
    private StreetFighter gopnik;
    void Start()
    {
        hero = new Fighter(1);
        enemy = new Fighter(1);
        Debug.Log("fight between hero and enemy");
        Fight(hero, enemy);
        
        
        
        enemy = new Fighter(2);
        knife = new Gun(3);
        gopnik = new StreetFighter(1, gun: knife);
        if (gopnik.Damage + knife.Damage < enemy.Damage)
        {
            if (gopnik.TryStrategicRetreat(enemy))
            {
                Debug.Log("Gopnik has been retreat");
            }
            else
            {
                Debug.Log("fight between gopnik and enemy");
                streetFight(gopnik, new StreetFighter(enemy));
            }
        }
        else
        {
            Debug.Log("fight between gopnik and enemy");
            streetFight(gopnik, new StreetFighter(enemy));
        }

    }
//dry
    void streetFight(StreetFighter gopnik, StreetFighter enemy)
    {
        while (enemy.LifeState && gopnik.LifeState)
        {
            enemy.Hit(gopnik);
            gopnik.Hit(enemy);
            Debug.Log($"gopnik's health: {gopnik.Health}/ enemy's health: {enemy.Health}");
        }
    }
    //dry
    void Fight(Fighter hero, Fighter enemy)
    {
        while (enemy.LifeState && hero.LifeState)
        {
            enemy.Hit(hero);
            hero.Hit(enemy);
            Debug.Log($"hero's health: {hero.Health}/ enemy's health: {enemy.Health}");
        }
    }
    
}



