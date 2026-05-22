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
Guy.SetStats(100, name); // sätter namn och maxhp på spelaren

string armorss = File.ReadAllText("armor.json"); //importerar min lista med namnen till alla Armor klasser som jag serialiserade så att jag kan hämta ut dem igen. .json listan ändras automatiskt om jag lägger till fler armor samma med Weapon istan under
string weaponss = File.ReadAllText("weapons.json");
List<Armor> armorSets = [];
List<Weapon> weaponSets = [];

List<string> armorNamesForDeserialization = JsonSerializer.Deserialize<List<string>>(armorss); //här deserialiseras listan
List<string> weaponNamesForDeserialization = JsonSerializer.Deserialize<List<string>>(weaponss);



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



Guy.AddWeaponToInventory(weaponSets[0]);

Guy.EquipWeapon(0);


bool gameRunning = true;
while (gameRunning == true) // själva game loopen
{

    bool inCombat = false; // är man i fighten eller mellan
    List<Enemy> Foes = []; // där man ser om det finns några levande fiender
    bool enemiesMade = false; // finns det enemies för nästa fight

    while (inCombat == false) // delaen av gameloopen som händer mellan fighterna
    {
    Guy.resetAfterCombat();

        if (enemiesMade == false) //skapar nya fiender efter en fight och innan första fighten
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

        Console.WriteLine("do you want to switch weapon or armor? type y for yes type anything else for no");
        string equipmentSwitch = Console.ReadLine();
        if (equipmentSwitch == "y")
        {
            Console.WriteLine("do you want to switch 1. weapon or 2. armor");
            bool weaponOrArmor = false; // välj om spelaren ska byta rustning eller vapen
            while (weaponOrArmor == false)
            {

                Console.WriteLine("type 1 for weapon or 2 for armor or back to stop equiping");

                string wepOrArm = Console.ReadLine();

                if (wepOrArm == "1") // om spelaren valde att byta vapen
                {
                    bool selectingWeapon = true;
                    while (selectingWeapon == true)
                    {
                        Console.WriteLine($"weapons available:");
                        for (int i = 0; i < Guy.weaponsInInventory.Count; i++) // vilka vapen kan man välja mellan
                        {

                            Console.WriteLine(Guy.weaponsInInventory[i].name);
                        }
                        Console.WriteLine("what weapon do you want to equip? if you dont want to equip a weapon type back");
                        string theWeapon = Console.ReadLine();
                        for (int i = 0; i < Guy.weaponsInInventory.Count; i++)  // kollar om vapnet med namnet som spelaren gav finns i deras inventory
                        {
                            if (theWeapon == Guy.weaponsInInventory[i].name)
                            {
                                Guy.EquipWeapon(i);
                                selectingWeapon = false;
                                
                            }




                        }

                        if (theWeapon == "back")
                        {

                            selectingWeapon = false;

                        }

                        if (selectingWeapon == true)
                        {
                            Console.WriteLine("you have to spell correctly");
                        }
                        
                    }
                }
                else if (wepOrArm == "2")
                {
                    bool selectingArmor = true;
                    while (selectingArmor == true)
                    {
                        Console.WriteLine($"Armor sets available:");
                        for (int i = 0; i < Guy.armorInInventory.Count; i++) // gör samma saker som förra stycket fast med armor
                        {

                            Console.WriteLine(Guy.armorInInventory[i].name);
                        }
                        Console.WriteLine("what armor set do you want to equip? if you dont want to equip any armor type back to equip type the name of the armor you want");
                        string theArmor = Console.ReadLine();
                        for (int i = 0; i < Guy.armorInInventory.Count; i++)
                        {
                            if (theArmor.ToLower() == Guy.armorInInventory[i].name.ToLower())
                            {
                                Guy.EquipArmor(i);
                                selectingArmor = false;
                                
                            }




                        }

                        if (theArmor == "back")
                        {

                            selectingArmor = false;
                        }

                        if (selectingArmor == true)
                        {
                            Console.WriteLine("you have to spell correctly");
                        }
                       
                    }
                }
                else if (wepOrArm=="back") // tillbaka till att välja mellan weapon eller armor
                {
                    weaponOrArmor=true; //är de färdiga med att välja ewuipment
                }
                else
                {
                    Console.WriteLine("follow the instructions"); //instruktioner är viktiga
                }
            }
        }

        Console.WriteLine("start? type y for yes or anything else for no"); // startar combat om spelaren vill
        string start = Console.ReadLine();
        if (start == "y")
        {
            inCombat = true;
        }
    }

    while (inCombat == true)
    {
        bool playerIsAlive=true;
        for (int i = 0; i < Foes.Count; i++) // fiendernas tur
        {
            Foes[i].PickAttack(Guy);
        }
        Console.WriteLine($"you have {Guy.GetPlayerHp()} hp");
        bool playersTurn = true; // det är spelarens tur om hen lever
        if (Guy.GetPlayerHp() <= 0)
        {
            playersTurn=false;
            inCombat=false;
            Console.WriteLine("you died");
            playerIsAlive=false;
            Console.ReadLine();
        }
        while (playersTurn == true) //spelarens tur
        {
            Console.WriteLine("your turn");

            Console.WriteLine("who do you want to attack");

            for (int i = 0; i < Foes.Count; i++)
            {
                Console.WriteLine($"{i+1}. {Foes[i].name}");
            }
            Console.WriteLine("answer with the nuber infront of the enemy you want to attack");
            bool actualAnswer = false;
            while (actualAnswer == false)
            {

                string choiceString = Console.ReadLine();

                int choiceInt = 10;

                int.TryParse(choiceString, out choiceInt);


                if (choiceInt < Foes.Count+1 && choiceInt > 0)
                {


                    Guy.Attack(Foes[choiceInt-1]);

                    actualAnswer = true;
                }
                else
                {
                    Console.WriteLine("you need to write one of the numbers no letters or spaces and no numbers that dont appear in the list");
                }
            }


            playersTurn = false;
        }
        

      
        for (int i = 0; i < Foes.Count; i++)  //are the enemies alive
        {

            Foes[i].TimeTick(); // updates isAlive bool i enemy

            if (Foes[i].AliveCheck() == false)
            {


                if (Foes[i].ranaway == false)
                {
                    
                int weaponOrArmorReward = Random.Shared.Next(1,3);
                if (weaponOrArmorReward == 1)
                {
                    Guy.AddWeaponToInventory(weaponSets[Foes[i].lootRarityMod]);  // hittar vapnet i vapen listan som ligger på samma plats som fiendens loot rarity variabel
                    Console.WriteLine($"you got a {weaponSets[Foes[i].lootRarityMod].name}");
                }
                if (weaponOrArmorReward == 2)
                {
                      Guy.AddArmorToInventory(armorSets[Foes[i].lootRarityMod]); // samma som den innan fast för armor
                    Console.WriteLine($"you got a {armorSets[Foes[i].lootRarityMod].name}");
                }
                }

               

                Foes.Remove(Foes[i]);
                i--;
            }
        }
        if (Foes.Count == 0||playerIsAlive==false)
        {
            Console.WriteLine("you won");
            inCombat = false;
            bool continueeee = false;
            while (continueeee == false)
            {
                
            Console.WriteLine("continue to next round? type n to quit out or y to continue");
            string continueue = Console.ReadLine();

                if (continueue == "y")
                {
                    gameRunning=true;
                    continueeee=true;
                }
                if (continueue == "n")
                {
                    gameRunning=false;
                    continueeee=true;
                }



            }
        }
        
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