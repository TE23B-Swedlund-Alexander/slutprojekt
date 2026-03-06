public class BossEnemy : Enemy
{
    public void SpecialAttackArmorBreak(Player target, int armorBroken)
    {
        Attack(target);
        target.ChangeArmorStat(-armorBroken);
    }
    public void SpecialAttackPoisonedStrike(Player target, int lengthOfPoison)
    {
        Attack(target);
        target.ApplyPoison(lengthOfPoison);
    }
    public void DubbleStrike(Player target)
    {
        Attack(target);
        Attack(target);
    }
}