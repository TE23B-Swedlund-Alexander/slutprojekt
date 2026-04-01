using System.Text.Json;

string run = "y";
while (run == "y")
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



  

string json = JsonSerializer.Serialize<Weapon>(wep);




Console.WriteLine("continue?");
    run = Console.ReadLine();
}