public class Weapon : Item
{
    private int dmg;

public void sSetStats(int dmgg , int rarityy , string namee)
    {
        dmg = dmgg;
        setStats (namee,rarityy);
    }

    public int GetDmg()
    {
        return dmg;
    }

}