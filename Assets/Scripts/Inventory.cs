using UnityEngine;

//Hardcoded inventory
//Yes, i do feel bad because of it
public class Inventory : MonoBehaviour {

    private int knives;
    private int injections;
    private int medicine;
    private int weapons;
    private int bombs;
    private int others;

    public void AddKnifes(int amount)
    {
        knives += amount;
    }

    public void removeKnife()
    {
        if(knives > 0)
            knives--;
    }

    public void AddInjections(int amount)
    {

        injections += amount;
    }

    public void removeInjection()
    {
        if (injections > 0)
            injections--;
    }

    public void AddMedicine(int amount)
    {
        medicine += amount;
    }

    public void RemoveMedicine()
    {
        if (medicine > 0)
            medicine--;
    }

    public void AddWeapons(int amount)
    {
        weapons += amount;
    }

    public void RemoveWeapon()
    {
        if (weapons > 0)
            weapons--;
    }

    public void AddBombs(int amount)
    {
        bombs += amount;
    }

    public void RemoveBomb()
    {
        if (bombs > 0)
            bombs--;
    }

    //ToDo: define this slot with something more usefull
    public void AddOthers(int amount)
    {
        others += amount;
    }

    public void RemoveOthers()
    {
        if (others > 0)
            others--;
    }
}
