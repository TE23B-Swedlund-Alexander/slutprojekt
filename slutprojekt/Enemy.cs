using System.Data.Common;

public class Enemy
{
    protected int hp;
    protected int armor;
    protected string name;
    protected int maxDmg;
    protected int minDmg;
    protected int lootRarityMod; // how good the loot will be when i make the enemies drop loot
    protected int xpReward;
    public bool isAlive=true;

    public void SetStats(int hpp, int armorr, int maxdmgg, int mindmgg, int lootrarityy, int xpp, string namee) // extra bokstav för att hålla isär från riktiga variablerna
    {// sets all the stats
        hp = hpp;
        armor = armorr;
        maxDmg = maxdmgg;
        minDmg = maxdmgg;
        lootRarityMod = lootrarityy;
        xpReward = xpp;
        name = namee;
    }
    public void Attack(Player target)
    {//basic attack on the player
        int dmg = Random.Shared.Next(minDmg, maxDmg);
        target.ChangeCurrentHp(dmg);
    }
    public void TimeTick() // will hapen at end of round
    {
        if (hp <= 0)
        {
           isAlive = false;
           Console.WriteLine($"{name} died");
        }

    }
    public void TakeDmg(int amount)
    {
        if (amount > armor)
        {
            
        hp -= amount - armor;
        Console.WriteLine($"you dealt {amount-armor} dmg");
        }
        else Console.WriteLine("your damage was fully blocked");
    }
}