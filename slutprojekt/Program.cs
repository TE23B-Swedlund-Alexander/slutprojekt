using System.Text.Json;
using System.Net.Http.Json;
using System.Text.Json.Serialization;
using System.Security.Cryptography.X509Certificates;
using System.Runtime.InteropServices;
using System.Formats.Asn1;
using System.Diagnostics.CodeAnalysis;

Console.WriteLine("all prompts need to be followed to the letter or they will be disregarded and you will have to answer the prompt again or it will be taken as a no in yes or no questions (thank hjalmar for this warning)");
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
Guy.weaponsInInventory.Add(weaponSets[0]);
Guy.EquipWeapon(0);

bool gameRunning = true;
while (gameRunning == true) // själva game loopen
{

    bool inCombat = false; // är man i fighten eller mellan
    List<Enemy> Foes = []; // där man ser om det finns några levande fiender
    bool enemiesMade = false; // finns det enemies för nästa fight


    while (inCombat == false) //
    {

        if (enemiesMade == false) //makes new enemies inbetween combats, rerolling their stats
        {

            BossEnemy bigBoss = new BossEnemy();
            SmallEnemy goon = new SmallEnemy();
            SmallEnemy minion = new SmallEnemy();
            goon.setLeader(bigBoss);
            minion.setLeader(bigBoss);
            bigBoss.name = "Boss";
            goon.name = "Goon";
            minion.name = "Minion";


            Foes.Add(bigBoss);
            Foes.Add(goon);
            Foes.Add(minion);

            enemiesMade = true;
        }

        Console.WriteLine("do you want to switch weapon or armor? type y for yes type anything else for no"); // so that you can switch equipment if you got a better weapon or armor
        string equipmentSwitch = Console.ReadLine();
        if (equipmentSwitch == "y")
        {
            Console.WriteLine("do you want to switch 1. weapon or 2. armor");
            bool weaponOrArmor = false; // did they want to switch or not
            while (weaponOrArmor == false)
                Console.WriteLine("type 1 for weapon or 2 for armor");
            string wepOrArm = Console.ReadLine();
            if (wepOrArm == "1")
            {
                while (true)
                {
                    Console.WriteLine($"weapons available:");
                    for (int i = 0; i < Guy.weaponsInInventory.Count; i++)
                    {

                        Console.WriteLine(Guy.weaponsInInventory[i].name);
                    }
                    Console.WriteLine("what weapon do you want to equip? if you dont want to equip a weapon type back");
                    string theWeapon = Console.ReadLine();
                    for (int i = 0; i < Guy.weaponsInInventory.Count; i++)
                    {
                        if (theWeapon == Guy.weaponsInInventory[i].name)
                        {

                        }

                    }




                    return;
                }
            }
            else if (wepOrArm == "2")
            {

            }
            else
            {
                Console.WriteLine("follow the instructions");
            }
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
        bool playersTurn = true; // det är spelarens tur
        for (int i = 2; i < Foes.Count; i++) // enemies take their actions
        {
            Foes[0].TakeDmg(100);
        }

        while (playersTurn == true) //player takes their action
        {
            Console.WriteLine("your turn");

            Console.WriteLine("who do you want to attack");

            for (int i = 0; i < Foes.Count; i++)
            {
                Console.WriteLine($"{i}. {Foes[i].name}");
            }
            Console.WriteLine("answer with the nuber infront of the enemy you want to attack");
            bool actualAnswer = false;
            while (actualAnswer == false)
            {

                string choiceString = Console.ReadLine();

                int choiceInt = 10;

                int.TryParse(choiceString, out choiceInt);


                if (choiceInt < Foes.Count && choiceInt > 0)
                {


                    Guy.Attack(Foes[choiceInt]);

                    actualAnswer = true;
                }
                else
                {
                    Console.WriteLine("you need to write one of the numbers no letters or spaces and no numbers that dont appear in the list");
                }
            }


            playersTurn = false;
        }
        Console.ReadLine();

        for (int i = 0; i < Foes.Count; i++)  //are the enemies alive
        {

            Foes[i].TimeTick(); // updates isAlive bool i enemy
            if (Foes[i].AliveCheck() == false)
            {

                Foes.Remove(Foes[i]);
            }
        }
        if (Foes.Count == 0)
        {
            inCombat = false;
        }
        Console.ReadLine();
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