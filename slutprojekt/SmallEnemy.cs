public class SmallEnemy : Enemy
{
   BossEnemy leader;
    public void SmallEnemyTick() // special small enemy end of round event were it escapes if the boss is dead
    {
        if (leader.isAlive == false)
        {
            RunAway();
        }
        TimeTick();
    }
    private void RunAway()
    {
        xpReward = 0;
        lootRarityMod = 0;
        hp = 0;
    }
}