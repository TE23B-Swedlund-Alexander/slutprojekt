using System.Data;
using System.Runtime;

public class Player
{
    private string name;
    private int hp;
    private int maxHp;
    private int armor;
    private int bonusDmg;
    private int effectivArmor;
    private List<Item> inventory;
    private List<Weapon> equipedWeapon;
    private List<Armor> equipedArmor;
    private int xp;
    private int xpToLevel;
    private int level;
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
        if (hp <= 0)
        {
            
        }
    }
    
    public void RemoveItemFromInventory(int i)
    {
        inventory.Remove(inventory[i]);
    }

    public void AddItemToInventory(Item thingy)
    {
        inventory.Add(thingy);
    }

    public void EquipWeapon(Weapon W)
    {
        equipedWeapon.Remove(equipedWeapon[0]);
        equipedWeapon.Add(W);
    }

    public void EquipArmor(Armor A)
    {
        equipedArmor.Remove(equipedArmor[0]);
        equipedArmor.Add(A);
    }

public void SetStats(int Mhp, string namee)
    {
        maxHp=Mhp;
        name=namee;
    }

    public void LevelUp()
    {
        maxHp+=10;
        armor+=5;
        xp=0;
        xpToLevel+=20;
        bonusDmg+=5;
    }

    public void Attack(Enemy target)
    {
      int dmg =  equipedWeapon[0].GetDmg();
        target.TakeDmg(dmg);
    }

    
}