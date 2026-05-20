public class BossEnemy : Enemy
{
    public BossEnemy()
    {

        hp = Random.Shared.Next(30, 50);
        armor = Random.Shared.Next(3, 7);
        maxDmg = Random.Shared.Next(10, 15);
        minDmg = Random.Shared.Next(5, 8);
        lootRarityMod = Random.Shared.Next(3, 5);
        xpReward = Random.Shared.Next(20, 30);

    }
     
    public override void PickAttack(Player target)
    {
        base.PickAttack(target);
        int whatAttack = Random.Shared.Next(1, 4);
        if (whatAttack == 1)
        {
            SpecialAttackArmorBreak(target);
        }
        if (whatAttack == 2)
        {
            SpecialAttackPoisonedStrike(target, 3);
        }
        if (whatAttack == 3)
        {
            MultiStrike(target);
        }
    }


    public void SpecialAttackArmorBreak(Player target)
    { // sänker spelarens armor vilket gör alla senare attacker bättre
        float armorBreak = Random.Shared.Next(minDmg, maxDmg);
        armorBreak = armorBreak / 10; //delat på 10 för att det hade varit för op annars
        int armorBroken = Convert.ToInt32(armorBreak);
        Attack(target);
        target.ChangeArmorStat(-armorBroken);
        Console.WriteLine($"your armor got damaged by {armorBroken} points");
    }
    public void SpecialAttackPoisonedStrike(Player target, int lengthOfPoison)
    { //attack that poisons
        Attack(target);
        target.ApplyPoison(lengthOfPoison);
        Console.WriteLine("you were poisoned");
    }
    public void MultiStrike(Player target)
    { // attakerar 3 gånger eftersom att armor stat gör så att 2 attacker är sämre än en attack som gör dubbel skada
        Attack(target);
        Attack(target);
        Attack(target);
    }
}