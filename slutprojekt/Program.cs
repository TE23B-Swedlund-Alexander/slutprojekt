using System.Text.Json;
using System.Net.Http.Json;
using System.Text.Json.Serialization;
using System.Security.Cryptography.X509Certificates;


Player Guy = new Player();
Console.WriteLine("what is your name"); // låter spelaren välja namn
string name = Console.ReadLine();
Guy.SetStats(Random.Shared.Next(20, 40), name); // sätter namn och machp på spelaren

string armorss = File.ReadAllText("armor.json"); //importerar min lista med namnen till alla Armor klasser som jag serialiserade så att jag kan hämta ut dem igen. .json listan ändras automatiskt om jag lägger till fler armor samma med Weapon istan under
string weaponss = File.ReadAllText("weapons.json");
List<Armor> armorSets = [];
List<Weapon> weaponSets = [];

List<string> armorNamesForDeserialization = JsonSerializer.Deserialize<List<string>>(armorss); //här deserialiseras listan
List<string> weaponNamesForDeserialization = JsonSerializer.Deserialize<List<string>>(weaponss);

Dictionary<string, object> weapons = new Dictionary<string, object>();

for (int i = 0; i < armorNamesForDeserialization.Count; i++) // här deserialiseras all Armor och hamnar i lootpoolen
{
    string jsonArmor = File.ReadAllText($"{armorNamesForDeserialization[i]}.json");

    Armor arm = JsonSerializer.Deserialize<Armor>(jsonArmor);
    armorSets.Add(arm);

}
for (int i = 0; i < weaponNamesForDeserialization.Count; i++) // samma som förra fast weapon
{
    string jsonWeapon = File.ReadAllText($"{weaponNamesForDeserialization[i]}.json");

    Weapon wep = JsonSerializer.Deserialize<Weapon>(jsonWeapon);

    weaponSets.Add(wep);

}


bool gameRunning = true;
while (gameRunning == true)
{

    bool inCombat = false;
    List<Enemy> allFoes = [];
    List<SmallEnemy> smallFoes = [];
    List<BossEnemy> bigFoe = [];
    bool enemiesMade = false;

    while (inCombat == false)
    {

        if (enemiesMade == false)
        {

            BossEnemy bigBoss = new BossEnemy();
            SmallEnemy goon = new SmallEnemy();
            SmallEnemy minion = new SmallEnemy();
            goon.setLeader(bigBoss);
            minion.setLeader(bigBoss);
            bigBoss.SetStats(Random.Shared.Next(30, 50), Random.Shared.Next(3, 7), Random.Shared.Next(10, 15), Random.Shared.Next(5, 8), Random.Shared.Next(3, 5), Random.Shared.Next(10, 20), "Boss Monster");
            goon.SetStats(Random.Shared.Next(5, 15), Random.Shared.Next(0, 5), Random.Shared.Next(5, 9), Random.Shared.Next(2, 4), Random.Shared.Next(1, 3), Random.Shared.Next(3, 12), "Goon");
            minion.SetStats(Random.Shared.Next(5, 15), Random.Shared.Next(0, 5), Random.Shared.Next(5, 9), Random.Shared.Next(2, 4), Random.Shared.Next(1, 3), Random.Shared.Next(3, 12), "Minion");


            bigFoe.Add(bigBoss);
            smallFoes.Add(goon);
            smallFoes.Add(minion);
            allFoes.Add(bigBoss);
            allFoes.Add(goon);
            allFoes.Add(minion);
            enemiesMade = true;
        }

        Console.WriteLine("start? type y for yes or anything else for no");
        string start = Console.ReadLine();
        if (start == "y")
        {
            inCombat = true;
        }
    }

    while (inCombat == true)
    {




        for (int i = 0; i < smallFoes.Count; i++)
        {
                smallFoes[i].SmallEnemyTick();  
                
        }
        bigFoe[0].TimeTick();
        
    }


















}




















// string jone ="e";



// // SERIALIZE ARMOR
// string run = "y";
// while (run == "y")
// {
//     Armor arm = new Armor();
//     Console.WriteLine("armor name");
// arm.name= Console.ReadLine();
// Console.WriteLine("armor protvalue");
// string sarmor = Console.ReadLine();
// Console.WriteLine("armor rarity");
// string sRarity = Console.ReadLine();
// int Rarity;
// int armor;
// int.TryParse (sRarity, out Rarity);
// int.TryParse (sarmor, out armor);
// arm.rarity=Rarity;
// arm.protection=armor;

// armorNamesForDeserialization.Add(arm.name);
//  jone = JsonSerializer.Serialize(armorNamesForDeserialization);
// string json = JsonSerializer.Serialize<Armor>(arm);

// File.WriteAllText($"{arm.name}.json",json);


// Console.WriteLine("continue?");
//     run = Console.ReadLine();
// }
// File.WriteAllText("armor.json",jone);










// string jon="e";


// // SERIALIZE WEAPONS
// string rune = "y";
// while (rune == "y")
// {
//     Weapon wep = new Weapon();
//     Console.WriteLine("wep name");
// wep.name= Console.ReadLine();
// Console.WriteLine("wep dmg");
// string sDmg = Console.ReadLine();
// Console.WriteLine("wep rarity");
// string sRarity = Console.ReadLine();
// int Rarity;
// int Dmg;
// int.TryParse (sRarity, out Rarity);
// int.TryParse (sDmg, out Dmg);
// wep.rarity=Rarity;
// wep.dmg=Dmg;

// weaponNamesForDeserialization.Add(wep.name);
// jon = JsonSerializer.Serialize(weaponNamesForDeserialization);
// string json = JsonSerializer.Serialize<Weapon>(wep);

// File.WriteAllText($"{wep.name}.json",json);


// Console.WriteLine("continue?");
//     rune = Console.ReadLine();
// }

// File.WriteAllText("weapons.json",jon);