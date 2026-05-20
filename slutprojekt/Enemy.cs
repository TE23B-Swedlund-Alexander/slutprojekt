using System.Data.Common;
using System.Dynamic;

public class Enemy
{
    protected int hp;
    protected int armor;
    public string name;
    protected int maxDmg;
    protected int minDmg;
    public int lootRarityMod; // how good the loot will be when i make the enemies drop loot
    protected int xpReward;
    protected bool isAlive=true;

    
    public bool AliveCheck()
    {
        return isAlive;
    }

    public void Attack(Player target)
    {//basic attack on the player
        int dmg = Random.Shared.Next(minDmg, maxDmg);
        target.ChangeCurrentHp(dmg);
    }
   virtual public void TimeTick() // will hapen at end of round
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