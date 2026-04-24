using System.Text.Json;
using System.Net.Http.Json;
using System.Text.Json.Serialization;
using System.Security.Cryptography.X509Certificates;


Player Guy = new Player();
Console.WriteLine("what is your name");
string name = Console.ReadLine();
Guy.SetStats(Random.Shared.Next(20,40),name);

string armorss = File.ReadAllText("armor.json");
string weaponss = File.ReadAllText("weapons.json");

List<string> armorNamesForDeserialization = JsonSerializer.Deserialize<List<string>>(armorss);
List<string> weaponNamesForDeserialization = JsonSerializer.Deserialize<List<string>>(weaponss);

Dictionary<string, object> weapons = new Dictionary<string, object>();

for (int i = 0; i < armorNamesForDeserialization.Count; i++)
{
    string json = File.ReadAllText($"{armorNamesForDeserialization[i]}.json");

Armor arm = JsonSerializer.Deserialize<Armor>(json);

}

bool gameRunning = true;
while (gameRunning == true)
{
    




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