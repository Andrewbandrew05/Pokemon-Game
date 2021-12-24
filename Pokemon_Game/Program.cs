using System;
using System.Collections.Generic;

namespace Pokemon_Game
{



    class MainClass
    {
        static String input;
        static Random rand = new Random();
        public static void heal_Pokemon(List<Pokemon> pokemon_to_heal)
        {
            foreach (Pokemon pok in pokemon_to_heal)
            {
                pok.HP = pok.maxHP;
                foreach (pokemonMove pokM in pok.Moves)
                {
                    pokM.PP = GameReference.pokemonMoves[pokM.name].PP;
                }
            }
        }
        public static Boolean check_If_Answer_Is_Yes(string answer)
        {
            Boolean is_answer_yes = false;
            if (answer.ToLower().Contains("yes") || answer.ToLower().Contains("sure") || answer.ToLower().Contains("yas") || answer.ToLower().Contains("yeah") || answer.ToLower().Contains("absolutely"))
            {
                is_answer_yes = true;
            }
            else if (answer.ToLower().Contains("no") || answer.ToLower().Contains("never") || answer.ToLower().Contains("nah") || (answer.ToLower().Contains("no") && answer.ToLower().Contains("way")))
            {
                is_answer_yes = false;
            }
            else
            {
                slowTyper("~Sorry but I didn't understand that. Please try retyping your answer.");
                is_answer_yes = check_If_Answer_Is_Yes(slowTyper("~|~"));
            }
            return is_answer_yes;
        }
        public static string slowTyper(string text)
        {
            string input = "";
            char[] text2 = text.ToCharArray();
            for (int i = 0; i < text2.Length; i++)
            {
                if (text2[i].Equals('~'))
                {
                    Console.WriteLine("");
                    Console.WriteLine("");
                }
                else if (text2[i].Equals('`'))
                {
                    Console.WriteLine("");
                }
                else if (text2[i].Equals('|'))
                {
                    while (true)
                    {
                        input = Console.ReadLine();
                        Pokemon_Game.MainClass.HelpChecker(input);
                        if (input.ToLower().Contains("help"))
                        {

                            int numberOfPeroids = 0;
                            foreach (char char1 in text2)
                            {
                                if (char1.Equals('.'))
                                {
                                    numberOfPeroids += 1;
                                }
                                else if (char1.Equals('?'))
                                {
                                    numberOfPeroids += 1;
                                }
                                else if (char1.Equals('!'))
                                {
                                    numberOfPeroids += 1;
                                }
                            }
                            int numberofLoops = 0;
                            string print = "";
                            bool addToPrintOrNot = false;
                            foreach (char char1 in text2)
                            {
                                if (char1.Equals('.'))
                                {
                                    numberofLoops += 1;
                                    if (numberofLoops == numberOfPeroids - 1)
                                    {
                                        addToPrintOrNot = true;

                                    }
                                    else if (numberofLoops == numberOfPeroids)
                                    {
                                        print = print + char1;
                                    }
                                }
                                else if (char1.Equals('?'))
                                {
                                    numberofLoops += 1;
                                    if (numberofLoops == numberOfPeroids - 1)
                                    {
                                        addToPrintOrNot = true;

                                    }
                                    else if (numberofLoops == numberOfPeroids)
                                    {
                                        print = print + char1;
                                    }
                                }
                                else if (char1.Equals('!'))
                                {
                                    numberofLoops += 1;
                                    if (numberofLoops == numberOfPeroids - 1)
                                    {
                                        addToPrintOrNot = true;

                                    }
                                    else if (numberofLoops == numberOfPeroids)
                                    {
                                        print = print + char1;
                                    }
                                }
                                else
                                {
                                    if (addToPrintOrNot == true)
                                    {
                                        print = print + char1;
                                    }
                                }
                            }
                            slowTyper(print);


                        }
                        else
                        {
                            break;
                        }
                    }
                }
                else
                {
                    System.Threading.Thread.Sleep(5);
                    Console.Write(text2[i]);
                }
            }
            return input;


        }
        public static void HelpChecker(string text)
        {
            while (true)
            {
                if (text.ToLower().Contains("help"))
                {
                    input = slowTyper("What do you need help with? I can pull up your Pokedex, give you a description of the area, or tell you how your Pokemon are.~|~");
                    if (input.ToLower().Contains("pokemon"))
                    {
                        slowTyper("Which Pokemon do you want to check on?~");
                        string pokemonInBag2 = "";
                        foreach (Pokemon pok in GameReference.pokemonInBag)
                        {
                            pokemonInBag2 = pokemonInBag2 + pok.user_Given_Alternate_Name + " ";
                        }
                        input = slowTyper(pokemonInBag2 + "~|~");
                        foreach (Pokemon pok in GameReference.pokemonInBag)
                        {
                            if (input.ToLower().Contains(pok.user_Given_Alternate_Name.ToLower()))
                            {
                                input = slowTyper("What aspect would you like to know about this Pokemon? I can tell you about its moves, health, level, and type.~|~");
                                if (input.ToLower().Contains("moves"))
                                {
                                    foreach (pokemonMove pokM in pok.Moves)
                                    {
                                        foreach (KeyValuePair<string, pokemonMove> kvp in GameReference.pokemonMoves)
                                        {
                                            if (kvp.Value == pokM)
                                            {
                                                slowTyper("name " + kvp.Key + "`");
                                                slowTyper("PP " + kvp.Value.PP + "`");
                                            }
                                        }
                                        slowTyper("power " + pokM.power + "`");
                                        slowTyper("accuracy " + pokM.accuracy + "~");
                                    }
                                }
                                else if (input.ToLower().Contains("health"))
                                {
                                    slowTyper("max HP " + pok.maxHP + "`");
                                    slowTyper("current HP " + pok.HP + "~");
                                }
                                else if (input.ToLower().Contains("level"))
                                {
                                    slowTyper("level " + pok.level + "~");
                                }
                                else if (input.ToLower().Contains("type"))
                                {
                                    slowTyper("type " + pok.typeOfPokemon + "~");
                                }
                                else
                                {
                                    slowTyper("Sorry, but I didn't understand that.~");
                                }
                            }
                        }
                    }
                    else if (input.ToLower().Contains("pokedex"))
                    {

                    }
                    else if (input.ToLower().Contains("description") || input.ToLower().Contains("area"))
                    {
                        if (GameReference.townNumber == 1)
                        {
                            slowTyper("Your home town is decent sized, not too big, but also not too small. There's a PokeCenter and, of course, Professor Pine's offices, but there isn't a gym. Just outside the town there's a field and a path running through it leading into the next town which does have a Pokemon Gym.~");
                        }
                    }
                    input = slowTyper("Is there anything else I can do for you?~|~");
                    if (check_If_Answer_Is_Yes(input))
                    {
                        continue;
                    }
                    else
                    {
                        slowTyper("Ok.~");
                        break;
                    }
                }
                else
                {
                    break;
                }
            }
        }

        public static void wildPokemonEncounter(string pokemonRegion)
        {
            Pokemon wildPokemonEncountered = null;
            int possiblePokemon = 0;

            foreach (KeyValuePair<string, pokemonStats> kvp in GameReference.pokemonInformation)
            {
                if (kvp.Key != "Bublbasuar" && kvp.Key != "Squirtle" && kvp.Key != "Charmander")
                {
                    if (pokemonRegion == "Plain")
                    {

                        if ((kvp.Value.typeOfPokemon == "Plant" || kvp.Value.typeOfPokemon == "Normal" || kvp.Value.typeOfPokemon == "Bug") && kvp.Value.evolutionNumber == 1)
                        {
                            possiblePokemon += 1;
                        }
                    }
                }
            }
            int whichPokemon = rand.Next(1, possiblePokemon);
            int i = 1;
            foreach (KeyValuePair<string, pokemonStats> kvp in GameReference.pokemonInformation)
            {
                if (kvp.Key != "Bulbasuar" && kvp.Key != "Squirtle" && kvp.Key != "Charmander")
                {
                    if (pokemonRegion == "Plain")
                    {
                        pokemonStats thisPokemonsStats = GameReference.pokemonInformation[kvp.Key];
                        if ((thisPokemonsStats.typeOfPokemon == "Plant" || thisPokemonsStats.typeOfPokemon == "Normal" || thisPokemonsStats.typeOfPokemon == "Bug") && thisPokemonsStats.evolutionNumber == 1)
                        {
                            if (i == whichPokemon)
                            {
                                wildPokemonEncountered = new Pokemon(kvp.Key, kvp.Value);
                                slowTyper("`");
                                slowTyper("You found a Pokemon! Its a " + wildPokemonEncountered.name + "! Its level " + wildPokemonEncountered.level + " and of the type " + wildPokemonEncountered.typeOfPokemon + ".~");
                                Battle B = new Battle();
                                slowTyper("You enter into battle with the opposing Pokemon.");
                                Pokemon your_active_pokemon = null;
                                foreach (Pokemon pok in GameReference.pokemonInBag)
                                {
                                    if (pok.is_Starting_Pokemon == true)
                                    {
                                        your_active_pokemon = pok;
                                        pok.active = true;
                                    }
                                    else
                                    {
                                        pok.active = false;
                                    }
                                }
                                B.PokemonBattle(wildPokemonEncountered, your_active_pokemon);
                                break;
                            }
                            else
                            {
                                i += 1;
                            }
                        }
                    }
                }
            }
        }




        //Stroy Line Methods meant for the story

        public static void CatchPokemon()
        {
            if (GameReference.townNumber == 1)
            {
                slowTyper("You head towards the grassy plane located just beside your town in search of Pokemon. You start searching through the gras for Pokemon.~");
                while (true)
                {
                    int didYouFindPokemon = rand.Next(1, 20);
                    if (didYouFindPokemon > 15)
                    {
                        wildPokemonEncounter("Plain");
                        break;
                    }
                    else
                    {
                        slowTyper("rustle rustle`");
                    }
                }
            }
        }
        public static void Main(string[] args)
        {
            slowTyper("Hello and welcome to Pokemon Steal, a Pokemon Spin-Off! ");
            slowTyper("My name is professor Pine, and it is my mission to study facsinating creatures called Pokemon. ");
            slowTyper("I have been searching for someone to help me with this project for a long time now, and am excited to begin work with you. ");
            input = slowTyper("Wait a minute, I apologize if I'm getting ahead of myself. You are here to become a Pokemon Trainer, right? ~|~");
            while (true)
            {
                input.ToLower();

                if (input.Contains("no"))
                {
                    input = slowTyper("Awww. Ok then. If you change your mind just tell me.~|~");


                }
                else
                {
                    slowTyper("That's great! Let's go ahead and choose your starting Pokemon! ");
                    break;
                }
            }
            slowTyper("There are many different types of Pokemon in the world. Some are big, some are small, some of them more powerful than others. Some are even rumored to be a different color, or shiny. ");
            slowTyper("Every different Pokemon species has a different type as well. There are plant, fire, water, dark, physcich, fairy, dragon, electric, ground, rock, normal, fight, flying, poison, bug, ghost, steel, and ice. ");
            slowTyper("The starting Pokemon only are fire, water, or plant, but some can learn moves of different types, and some even can evolve into Pokemon with their starting type plus another. ");
            slowTyper("Any way thats enough talking for now. Let's go ahead and choose your starting Pokemon! Here's a list of the starting Pokemon. ~");
            int i = 0;
            string startingPokemon2 = "";
            while (i < GameReference.startingPokemon.Count)
            {
                startingPokemon2 = startingPokemon2 + " " + GameReference.startingPokemon[i];
                i += 1;
            };
            while (true)
            {
                slowTyper(startingPokemon2 + "~");

                input = slowTyper("Which Pokemon would you like? ~|~");
                input = input.ToLower();
                if (input.Contains("bulbasuar"))
                {
                    Pokemon Bulbasuar = new Pokemon("Bulbasuar", 1, GameReference.pokemonInformation["Bulbasuar"]);
                    Bulbasuar.active = true;
                    Bulbasuar.is_Starting_Pokemon = true;
                    GameReference.pokemonInBag.Add(Bulbasuar);
                    Pokemon Charmander = new Pokemon("Charmander", 1, GameReference.pokemonInformation["Charmander"]);
                    Charmander.active = true;
                    Charmander.is_Starting_Pokemon = true;
                    GameReference.rivalsPokemon.Add(Charmander);
                    break;
                }
                else if (input.Contains("charmander"))
                {
                    Pokemon Charmander = new Pokemon("Charmander", 1, GameReference.pokemonInformation["Charmander"]);
                    Charmander.active = true;
                    Charmander.is_Starting_Pokemon = true;
                    GameReference.pokemonInBag.Add(Charmander);
                    Pokemon Squirtle = new Pokemon("Squirtle", 1, GameReference.pokemonInformation["Squirtle"]);
                    Squirtle.active = true;
                    Squirtle.is_Starting_Pokemon = true;
                    GameReference.rivalsPokemon.Add(Squirtle);
                    break;
                }
                else if (input.Contains("squirtle"))
                {
                    Pokemon Squirtle = new Pokemon("Squirtle", 1, GameReference.pokemonInformation["Squirtle"]);
                    Squirtle.active = true;
                    Squirtle.is_Starting_Pokemon = true;
                    GameReference.pokemonInBag.Add(Squirtle);
                    Pokemon Bulbasuar = new Pokemon("Bulbasuar", 1, GameReference.pokemonInformation["Bulbasuar"]);
                    Bulbasuar.active = true;
                    Bulbasuar.is_Starting_Pokemon = true;
                    GameReference.rivalsPokemon.Add(Bulbasuar);
                    break;
                }
                else
                {
                    slowTyper("Sorry, but I don't know of that pokemon.");
                }
            }
            foreach (Pokemon pok in GameReference.pokemonInBag)
            {
                foreach (KeyValuePair<string, pokemonMove> kvp in GameReference.pokemonMoves)
                {
                    if (kvp.Value == pok.Moves[1])
                    {
                        slowTyper("Greate choice! " + pok.name + " is an amazing pokemon! It is of the type " + pok.typeOfPokemon + ", and knows the moves Tackle and " + kvp.Key.Replace("_", " ") + ".");
                    }
                }

            }

            slowTyper("There are many different species of Pokemon out in the wild all of which can be caught. You need a Pokeball or some other type of ball in order to catch them. I suggest you try to knock down the other Pokemon's health some before trying to catch them, as it will increase your chances of catching it. Here are six Pokeballs. You may use them whenever you are in an encounter with a wild Pokemon.");
            item Pokeball = new item();
            foreach (KeyValuePair<string, item> kvp in GameReference.itemDataBase)
            {
                if (kvp.Key == "Pokeball")
                {
                    Pokeball = kvp.Value;
                }
            }
            for (i = 0; i < 6; i++)
            {
                GameReference.itemsInBag.Add(Pokeball);
            }
            foreach (Pokemon pok in GameReference.pokemonInBag)
            {
                slowTyper("You also get a device called a Pokedex. This Pokedex will show you information about different Pokemon once you have caught them. Right now It only has an entry on " + pok.name + ", but soon you will have more entries than you would expect. The information you put into this will be sent back to me as well, allowing me to add to my Pokemon data base. Now I think that's it... Oh wait! I didn't get your name! What should I call you? ~");
            }
            input = slowTyper("|");
            GameReference.characterName = input;
            slowTyper("~");
            slowTyper("It's been nice metting you " + GameReference.characterName + ". If you ever find yourself in need of finding out what you can do just type 'help'. Now go forth into the world of Pokemon!");
            slowTyper("You exit Professor Pine's office and enter your home village once again.~Whew! that guys kinda eccentric.~Soon your friend James runs up to you. He looks really exited and as soon as he sees you starts talking so fast you cant understand what he's saying.~Its finally happening efhbhefbehbs Im getting my first iwefbiabgiulrghiurpug`Woah there buddy! Whats going on?`I'm getting my first Pokemon today!`Cool!`Yeah I know I've been looking forwards to this for years!`I know.`Anyway I'm gonna go get my Pokemon. Go catch some Pokemon and then we can have a battle afterwards!~James runs into the office, and you are left with a descicion. Do you want to go and catch Pokemon now, or do you want to wait and have you're first battle? (type your descicion in the entry below.");
            CatchPokemon();
            slowTyper("~You return to professor Pine's office to battle James. You remember that your Pokemon took some damage in the battle on the way, and stop by a pokeStop to heal up. You arrive at Porefessor Pine's office right as James is leaving it.~");
            heal_Pokemon(GameReference.pokemonInBag);
            slowTyper("Hey! There you are! I see you ran of to catch some Pokemon, did you think you couldn't beat me?`Nah, I just got board.`If you say so. Anyway you ready?`Yup.~");
            Battle B1 = new Battle();
            B1.TrainerBattle("rival");
            heal_Pokemon(GameReference.pokemonInBag);
            heal_Pokemon(GameReference.rivalsPokemon);
            input = slowTyper("~Hey, you wanna go catch some Pokemon in the field?~|~");
            if (check_If_Answer_Is_Yes(input))
            {
                slowTyper("~Ok! Let's go!~Ah! Here we are! I'll search the left side, you the right, we'll meet up in 15 minutes or so.`Ok.~");
                CatchPokemon();
                int whichPokemon = rand.Next(0, GameReference.pokemonInformation.Count - 3);
                int timesLooped = 0;
                foreach (KeyValuePair<string, pokemonStats> kvp in GameReference.pokemonInformation)
                {
                    if (whichPokemon == timesLooped)
                    {
                        Pokemon Yeet = new Pokemon(Convert.ToString(kvp.Key), GameReference.pokemonInformation[Convert.ToString(kvp.Key)]);
                        GameReference.rivalsPokemon.Add(Yeet);
                    }
                }
                input = slowTyper("~Hey! There you are! Do you want to battle again now that we have more Pokemon?~|~");
                if (check_If_Answer_Is_Yes(input))
                {
                    slowTyper("~Ok! Let's do this!~");
                    Battle B = new Battle();
                    B.TrainerBattle("rival");
                    heal_Pokemon(GameReference.pokemonInBag);
                    heal_Pokemon(GameReference.rivalsPokemon);
                }
            }
            else
            {
                slowTyper("Ok. I'll see you at the next gym I guess.`Yah, sounds good.~");
            }
            slowTyper("For the first time you find yourself alone with a mostly open storyline ahead of you. You must decide what to do. Remember if you ever need help, just type help in the text box.~");
            while (true)
            {
                input = slowTyper("|");
                slowTyper("~");
                if (input.ToLower().Contains("catch"))
                {
                    CatchPokemon();
                }
                else if (input.ToLower().Contains("heal") || input.ToLower().Contains("center"))
                {
                    slowTyper("You head to the PokeCenter to heal your Pokemon.");
                    foreach (Pokemon pok in GameReference.pokemonInBag)
                    {
                        pok.HP = pok.maxHP;
                    }
                }
                else if (input.ToLower().Contains("path"))
                {
                    slowTyper("You begin walking along the path towards the other town.");
                    i = 0;
                    while (i < 100)
                    {

                        int pokemonEncounter = rand.Next(0, 4);
                        slowTyper(Convert.ToString(pokemonEncounter));
                        if (pokemonEncounter == 4)
                        {
                            slowTyper("You encountered a Pokemon!~");
                            wildPokemonEncounter("Plains");
                            slowTyper("Would you like to continue on the path or return to the town to heal up?~|~");
                            if (input.ToLower().Contains("heal"))
                            {
                                slowTyper("You return to the PokeCenter and heal your Pokemon.~");
                                foreach (Pokemon pok in GameReference.pokemonInBag)
                                {
                                    pok.HP = pok.maxHP;
                                    foreach (pokemonMove pokM in pok.Moves)
                                    {
                                        foreach (KeyValuePair<string, pokemonMove> kvp in GameReference.pokemonMoves)
                                        {
                                            if (pokM == kvp.Value)
                                            {
                                                pokM.PP = kvp.Value.PP;
                                            }
                                        }
                                    }
                                }
                                break;
                            }

                        }
                        else
                        {
                            slowTyper("step`");
                        }
                        i += 1;
                    }
                }
            }
        }
    }
}
