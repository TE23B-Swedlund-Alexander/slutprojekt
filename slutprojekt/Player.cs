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
    public List<Weapon> weaponsInInventory = [];
    public List<Armor> armorInInventory = [];
    private List<Weapon> equipedWeapon = [];
    private List<Armor> equipedArmor = [];
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
    

    public void RemoveFromWeaponInventory(int i)
    {
        weaponsInInventory.Remove(weaponsInInventory[i]);
    }
    public void RemoveFromArmorInventory(int i)
    {
        armorInInventory.Remove(armorInInventory[i]);
    }

    public void AddWeaponToInventory(Weapon thingy)
    {

Weapon toAdd = new Weapon();
toAdd=thingy;

        weaponsInInventory.Add(toAdd);
    }
    public int WeaponInventoryCount()
    {
      int n =  weaponsInInventory.Count;
        return n;
    }
    public void AddArmorToInventory(Armor thingy)
    {
        armorInInventory.Add(thingy);
    }

    public void EquipWeapon(int w)
    {
        
if (equipedWeapon.Count > 0)
        {
            
        equipedWeapon.Remove(equipedWeapon[0]);
        }
        equipedWeapon.Add(weaponsInInventory[w]);
        Console.WriteLine($"equiped: {equipedWeapon[0].name}");
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