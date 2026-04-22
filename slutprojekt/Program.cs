using System.Text.Json;
using System.Net.Http.Json;
using System.Text.Json.Serialization;


Player Guy = new Player();
Console.WriteLine("what is your name");
string name = Console.ReadLine();
Guy.SetStats(Random.Shared.Next(20,40),name);

List<string> armorNamesForDeserialization = ["leather armor", "chainmail", "iron plate", "adamantium chainmail","adamantium plate"];
List<string> weaponNamesForDeserialization = ["wooden sword","bronze sword","iron sword","longsword","excalibur"];


// Weapon startersword = JsonSerializer.Deserialize<Weapon>
// Guy.AddItemToInventory()
// bool gameRunning = true;
// while (gameRunning == true)
// {
    




//  }
























// SERIALIZE ARMOR
string run = "y";
while (run == "y")
{
    Armor arm = new Armor();
    Console.WriteLine("armor name");
arm.name= Console.ReadLine();
Console.WriteLine("armor protvalue");
string sarmor = Console.ReadLine();
Console.WriteLine("armor rarity");
string sRarity = Console.ReadLine();
int Rarity;
int armor;
int.TryParse (sRarity, out Rarity);
int.TryParse (sarmor, out armor);
arm.rarity=Rarity;
arm.protection=armor;

//armorNamesForDeserialization.Add(arm.name);
string json = JsonSerializer.Serialize<Armor>(arm);

//File.WriteAllText($"{arm.name}.json",json);


Console.WriteLine("continue?");
    run = Console.ReadLine();
}













// SERIALIZE WEAPONS
string rune = "y";
while (rune == "y")
{
    Weapon wep = new Weapon();
    Console.WriteLine("wep name");
wep.name= Console.ReadLine();
Console.WriteLine("wep dmg");
string sDmg = Console.ReadLine();
Console.WriteLine("wep rarity");
string sRarity = Console.ReadLine();
int Rarity;
int Dmg;
int.TryParse (sRarity, out Rarity);
int.TryParse (sDmg, out Dmg);
wep.rarity=Rarity;
wep.dmg=Dmg;

//weaponNamesForDeserialization.Add(wep.name);
string jon = JsonSerializer.Serialize(weaponNamesForDeserialization);
string json = JsonSerializer.Serialize<Weapon>(wep);

File.WriteAllLines("list.json",jon);
//File.WriteAllText($"{wep.name}.json",json);


Console.WriteLine("continue?");
    rune = Console.ReadLine();
}