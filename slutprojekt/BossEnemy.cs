public class BossEnemy : Enemy
{
    public void SpecialAttackArmorBreak(Player target)
    { // special attack variation that lowers player armor making subsequent attacks deal more dmg
        float armorBreak = Random.Shared.Next(minDmg,maxDmg);
        armorBreak = armorBreak/10; //divided by 10 because removing the full damage from the armor is op
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
    { // attack that strikes three times because 2 would be worse than an attack that deal doubble dmg bacause armor is a flat amount
        Attack(target);
        Attack(target);
        Attack(target);
    }
}