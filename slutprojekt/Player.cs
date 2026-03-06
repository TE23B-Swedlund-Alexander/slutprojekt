using System.Runtime;

public class Player
{
    private int hp;
    private int armor;
    private int effectivArmor;
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