using System.Data.Common;

public class Enemy
{
    protected int hp;
    protected int armor;
    protected string name;
    protected int maxDmg;
    protected int minDmg;
    protected int lootRarityMod;
    protected int xpReward;
    bool isAlive=true;

    public void SetStats(int hpp, int armorr, int maxdmgg, int mindmgg, int lootrarityy, int xpp, string namee) // extra bokstav för att hålla isär från riktiga variablerna
    {
        hp = hpp;
        armor = armorr;
        maxDmg = maxdmgg;
        minDmg = maxdmgg;
        lootRarityMod = lootrarityy;
        xpReward = xpp;
        name = namee;
    }
    public void Attack(Player target)
    {
        int dmg = Random.Shared.Next(minDmg, maxDmg);
        target.ChangeCurrentHp(dmg);
    }
    public void TimeTick()
    {
        if (hp <= 0)
        {
           isAlive = false;
        }

    }
}