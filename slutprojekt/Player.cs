using System.Data;
using System.Runtime;

public class Player
{
    private int hp;
    private int armor;
    private int effectivArmor;
    private List<Item> inventory;
    private List<Weapon> equipedWeapon;
    private List<Armor> equipedArmor;
    private int xp;
    private int xpToLevel;
    private int level;
    int poisonDurationOnPlayer;

    public void ChangeArmorStat(int amount)
    {
        effectivArmor += amount;
    }
    public void ChangeCurrentHp(int amount)
    {
        hp += amount;
    }
    public void ApplyPoison(int length)
    {
        poisonDurationOnPlayer += length;
    }
    public void TimeTick()
    {
        if (poisonDurationOnPlayer > 0)
        {
            hp -= poisonDurationOnPlayer;
            poisonDurationOnPlayer--;
        }
    }
    

}