public class SmallEnemy : Enemy
{
     
    public SmallEnemy()
    {

        hp = Random.Shared.Next(5, 15);
        armor = Random.Shared.Next(0, 5);
        maxDmg = Random.Shared.Next(5, 9);
        minDmg = Random.Shared.Next(2, 4);
        lootRarityMod = Random.Shared.Next(0, 3);
        xpReward = Random.Shared.Next(3, 12);
    }
private BossEnemy leader;
    public override void PickAttack(Player target)
    {
        base.PickAttack(target);
        Attack(target);
    }

    

    public void setLeader(BossEnemy led)
    {
        leader = led;
    }

    public override void TimeTick() // special small enemy end of round event were it escapes if the boss is dead
    {
            if (hp <= 0)
            {
                isAlive = false;
                Console.WriteLine($"{name} died");
            }
        if (leader.AliveCheck() == false)
        {
            RunAway();
        }

    }
    private void RunAway()
    {
        xpReward = 0;
        lootRarityMod = 0;
        hp = 0;
        isAlive=false;
        ranaway=true;
        Console.WriteLine($"{name} ran away");
    }
}