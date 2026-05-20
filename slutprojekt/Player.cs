using System.Data;
using System.Runtime;

public class Player
{
    private string name;
    private int hp;
    private int maxHp;
    private int armor=3;
    private int effectivArmor;
    public List<Weapon> weaponsInInventory = [];
    public List<Armor> armorInInventory = [];
    private List<Weapon> equipedWeapon = [];
    private List<Armor> equipedArmor = [];
    private int xp;
    private int xpToLevel;
    private int level;
    int poisonDurationOnPlayer;

    public int GetPlayerHp()
    {
        return hp;
    }

    public void ChangeArmorStat(int amount)
    {
        effectivArmor += amount;
    }
    public void ChangeCurrentHp(int amount)
    {

        hp -= amount-effectivArmor;
      Console.WriteLine($"you took {amount} damage");


    }
    public void resetAfterCombat()
    {
        hp=maxHp;
        effectivArmor=armor;
        poisonDurationOnPlayer=0;
        if (xp >= xpToLevel)
        {
            LevelUp();
            

        }
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

    public void EquipArmor(int w)
    {
        if (equipedArmor.Count > 0)
        {
            
        equipedArmor.Remove(equipedArmor[0]);
        }
        equipedArmor.Add(armorInInventory[w]);
        Console.WriteLine($"equiped: {equipedArmor[0].name}");
        armor=equipedArmor[0].ProtValue();
    }

public void SetStats(int Mhp, string namee)
    {
        maxHp=Mhp;
        hp = maxHp;
        name=namee;
    }

    public void LevelUp()
    {
        maxHp+=10;
        level++;
        xp=0;
        xpToLevel+=20;
        Console.WriteLine($"you leveled up to level {level}");
        
    }

    public void Attack(Enemy target)
    {
      int dmg =  equipedWeapon[0].GetDmg();
        target.TakeDmg(dmg);
    }

    
}