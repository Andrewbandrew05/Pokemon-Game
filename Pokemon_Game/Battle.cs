using System;
using System.Collections.Generic;
namespace Pokemon_Game
{
    
public class Battle
    {
        static Random rand = new Random();
        private class individual_pokemon_XP
        {
            public int XP_to_Gain { get; set; }
            public Pokemon Pokemon_to_Get_XP { get; set; }
        }
        private static List<Pokemon> opponents_Pokemon = new List<Pokemon>();
        private static Pokemon players_Active_Pokemon = null;
        private static Pokemon opposing_Active_Pokemon = null;
        private static Boolean is_a_Trainer_Battle = false;
        private static string name_of_Opposing_Trainer = null;
        private static List<individual_pokemon_XP> pokemon_to_get_XP= new List<individual_pokemon_XP>();
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
        public void reset_All_Variables() 
        {

            opposing_Active_Pokemon = null;
            opponents_Pokemon.Clear();
            players_Active_Pokemon = null;
            is_a_Trainer_Battle = false;
            name_of_Opposing_Trainer = null;
            pokemon_to_get_XP.Clear();
        }
        public void give_Pokemon_XP() 
        {
            foreach (individual_pokemon_XP XP in pokemon_to_get_XP)
            {
                XP.Pokemon_to_Get_XP.XP += XP.XP_to_Gain;
                XP.Pokemon_to_Get_XP.LevelUp();
                slowTyper("~"+XP.Pokemon_to_Get_XP.user_Given_Alternate_Name + " gained " + XP.XP_to_Gain+" XP! It needs "+((XP.Pokemon_to_Get_XP.level*100)-XP.Pokemon_to_Get_XP.XP)+" more XP to level up!");
            }
        }
        public Pokemon makePokemonForTrainer(pokemonTrainer trainer)
        {
            int highestLevel = 0;
            foreach (Pokemon pok in GameReference.pokemonInBag)
            {
                if (pok.level > highestLevel)
                {
                    highestLevel = pok.level;
                }
            }
            int how_many_pokemon_of_types_in_dictionary = 0;
            foreach (string pokemon_Type in trainer.typesOfPokemon) 
            {
                foreach (KeyValuePair<string, pokemonStats> kvp in GameReference.pokemonInformation)
                {
                    if (kvp.Value.typeOfPokemon == pokemon_Type)
                    {
                        how_many_pokemon_of_types_in_dictionary += 1;
                    }
                }
            }
            
            int which_pokemon = rand.Next(0, how_many_pokemon_of_types_in_dictionary);
            int times_looped = 0;
            foreach (KeyValuePair<string, pokemonStats> kvp in GameReference.pokemonInformation)
            {
                if (times_looped == which_pokemon)
                {
                    Pokemon Opponents_Pokemon = new Pokemon(kvp.Key, (int)Math.Round(highestLevel * trainer.levelMultiplier), kvp.Value);
                    return Opponents_Pokemon;
                }
                times_looped += 1;
            }
            return null;
        }
        public List<Pokemon> getPokemonOfTrainer(string name)
        {
            List<Pokemon> pokemon_of_trainer = new List<Pokemon>();
            if (name == "James")
            {
                foreach (Pokemon pok in GameReference.rivalsPokemon) 
                {
                    pokemon_of_trainer.Add(pok);
                }
                
            }
            else
            {
                pokemonTrainer trainer = GameReference.pokemonTrainers[name];
                int how_many_pokemon = rand.Next(1, 6);
                for (int i = 0; i <= how_many_pokemon; i += 1)
                {
                    pokemon_of_trainer.Add(makePokemonForTrainer(trainer));
                    int which_Pokemon_is_active = rand.Next(0, how_many_pokemon);
                    int times_looped = 0;
                    foreach (Pokemon pok in pokemon_of_trainer)
                    {
                        if (which_Pokemon_is_active == times_looped)
                        {
                            pok.active = true;
                            pok.is_Starting_Pokemon = true;
                        }
                        else
                        {
                            pok.active = false;
                            pok.is_Starting_Pokemon = false;
                        }
                        times_looped += 1;
                    }
                }
            }
            return pokemon_of_trainer;
        }
        public void TrainerBattle(string typeOfBattle)
        {
            is_a_Trainer_Battle = true;
            if (typeOfBattle == "rival")
            {
                foreach (KeyValuePair<string, pokemonTrainer> kvp in GameReference.pokemonTrainers)
                {
                    if (kvp.Key == "James")
                    {
                        opponents_Pokemon = getPokemonOfTrainer(kvp.Key);
                        name_of_Opposing_Trainer = kvp.Key;
                    }
                }
            }
            else
            {
                int whichPokemonTrainer = rand.Next(1, GameReference.pokemonTrainers.Count - 1);
                int how_many_cycles = 0;
                foreach (KeyValuePair<string, pokemonTrainer> kvp in GameReference.pokemonTrainers)
                {
                    how_many_cycles += 1;
                    if (how_many_cycles == whichPokemonTrainer)
                    {
                        opponents_Pokemon = getPokemonOfTrainer(kvp.Key);
                        name_of_Opposing_Trainer = kvp.Key;
                    }
                }
            }
            foreach (Pokemon pok in GameReference.pokemonInBag)
            {
                if (pok.is_Starting_Pokemon == true)
                {
                    pok.active = true;
                    Console.WriteLine(opponents_Pokemon.Count);
                    foreach (Pokemon pok2 in opponents_Pokemon)
                    {
                        if (pok2.is_Starting_Pokemon== true)
                        {
                            pok2.active = true;
                            Battle B = new Battle();
                            B.PokemonBattle(pok2, pok);
                            break;
                        }
                    }
                    break;
                }
                else 
                {
                    pok.active = false;
                }
            }
        }
        public Boolean switchPokemon(Boolean is_switch_due_to_fainted_pokemon)
        {
            Boolean all_pokemon_fainted = false;
            Boolean do_damage_to_pokemon_or_not = false;
            while (true)
            {
                
                string pokemon = "";
                string input = "";
                foreach (Pokemon pok in GameReference.pokemonInBag)
                {
                    if (pok.HP > 0 && pok.active == false)
                    {
                        pokemon = pokemon + pok.user_Given_Alternate_Name + "`";
                    }
                }
                if (pokemon.Length > 0)
                {
                    if (is_switch_due_to_fainted_pokemon == true) 
                    {
                        slowTyper("~What Pokemon would you like to switch to?");
                    }
                    else 
                    {
                        slowTyper("~What Pokemon would you like to switch to? If you don't actually want to switch your Pokemon just type back.");
                    }
                    input = slowTyper("~"+pokemon + "~|~");
                    if (input.ToLower().Contains("back") && is_switch_due_to_fainted_pokemon == false) 
                    {
                        do_damage_to_pokemon_or_not = false;
                        break;
                    }
                }
                else 
                {
                    Boolean pokemon_to_backup = false;
                    foreach (Pokemon pok in GameReference.pokemonInBag)
                    {
                        if (pok.HP > 0)
                        {
                            pok.active = true;
                            pokemon_to_backup = true;
                        }
                    }
                    if (pokemon_to_backup == true)
                    {
                        do_damage_to_pokemon_or_not = false;
                        slowTyper("You do not have any Pokemon to switch to.");
                        break;
                    }
                    else
                    {
                        foreach (Pokemon pok in GameReference.pokemonInBag)
                        {
                            pok.HP = pok.maxHP;
                        }
                        all_pokemon_fainted = true;
                        break;
                    }
                }
                bool succesful_Pokemon_Switch = false;
                foreach (Pokemon pok in GameReference.pokemonInBag)
                {
                    if (input.ToLower().Contains(pok.user_Given_Alternate_Name.ToLower()))
                    {
                        pok.active = true;
                        succesful_Pokemon_Switch = true;
                        slowTyper("~Your new active Pokemon is " + pok.user_Given_Alternate_Name);
                        players_Active_Pokemon.active = false;
                        players_Active_Pokemon = pok;
                        Boolean does_XP_gain_for_Pokemon_Exist = false;
                        foreach(individual_pokemon_XP XP in pokemon_to_get_XP) 
                        {
                            if (XP.Pokemon_to_Get_XP == players_Active_Pokemon) 
                            {
                                XP.XP_to_Gain += 20;
                                does_XP_gain_for_Pokemon_Exist = true;
                            }
                        }
                        if (does_XP_gain_for_Pokemon_Exist == false) 
                        {
                            pokemon_to_get_XP.Add(new individual_pokemon_XP { XP_to_Gain = 20, Pokemon_to_Get_XP = players_Active_Pokemon });
                        }
                    }
                }
                if (succesful_Pokemon_Switch == true)
                {
                    do_damage_to_pokemon_or_not = true;
                    break;
                }
                else
                {
                    slowTyper("~You do not have that Pokemon with you.");
                }
            }
            if (all_pokemon_fainted == false && do_damage_to_pokemon_or_not == true && is_switch_due_to_fainted_pokemon==false)
            {
                Boolean did_pokemon_faint = PokemonAttack(opposing_Active_Pokemon, players_Active_Pokemon, opposing_Active_Pokemon.Moves[rand.Next(opposing_Active_Pokemon.Moves.Count)]);
                if (did_pokemon_faint == true)
                {
                    switchPokemon(true);
                }
            }
            return all_pokemon_fainted;
        }

        public Boolean catchPokemon()
        {
            int pokeBalls = 0;
            int greatBalls = 0;
            int ultraBalls = 0;
            Boolean successFullCatch = false;
            Boolean do_damage_or_not = false;
            foreach (item item in GameReference.itemsInBag)
            {
                if (item.nameOfItem == "Pokeball")
                {
                    pokeBalls += 1;
                }
                else if (item.nameOfItem == "Great Ball")
                {
                    greatBalls += 1;
                }
                else if (item.nameOfItem == "Ultra Ball")
                {
                    ultraBalls += 1;
                }
            }
            slowTyper("~You have " + pokeBalls + " pokeballs, " + greatBalls + " greatballs, and " + ultraBalls + " ultraballs.");
            string input = slowTyper("~Which one of these would you like to use? Or if you don't want to catch the Pokemon at all, just type back.~|~");
            while (true)
            {
                if (input.ToLower().Contains("back"))
                {
                    do_damage_or_not = false;
                    break;
                }
                if (input.ToLower().Contains("pokeball") && pokeBalls >= 1)
                {
                    double random_catch_addition = rand.Next(-1, 1) * 0.1;
                    if (((opposing_Active_Pokemon.HP/opposing_Active_Pokemon.maxHP)-random_catch_addition)*255 < 0.3*opposing_Active_Pokemon.catchRate)
                    {
                        slowTyper("You caught the Pokemon!");
                        do_damage_or_not = false;
                        foreach (item I in GameReference.itemsInBag)
                        {
                            if (I.nameOfItem == "Pokeball")
                            {
                                GameReference.itemsInBag.Remove(I);
                                break;
                            }

                        }
                        opposing_Active_Pokemon.active = false;
                        successFullCatch = true;
                        GameReference.pokemonInBag.Add(opposing_Active_Pokemon);
                        int repetitions_of_name = 0;
                        foreach (Pokemon pok in GameReference.pokemonInBag) 
                        {
                            if (pok.name == opposing_Active_Pokemon.name) 
                            {
                                repetitions_of_name += 1;
                            }
                        }
                        if (repetitions_of_name>1) 
                        {
                            input=slowTyper("Since you already have a Pokemon of the same name, please rename this Pokemon. ~|~");
                            if (input != opposing_Active_Pokemon.name) 
                            {
                                opposing_Active_Pokemon.user_Given_Alternate_Name = input;
                            }
                        }
                        
                    }
                    else
                    {
                        do_damage_or_not = true;
                        slowTyper("~The Pokemon broke free!");
                        foreach (item I in GameReference.itemsInBag)
                        {
                            if (I.nameOfItem == "Pokeball")
                            {
                                GameReference.itemsInBag.Remove(I);
                                break;
                            }

                        }
                    }
                    break;
                }
                else 
                {
                    input=slowTyper("~Sorry but I didn't understand that. Can you try typing again?~|~");
                }
            }
            if (successFullCatch == false && do_damage_or_not == true)
            {
                Boolean did_pokemon_faint = PokemonAttack(opposing_Active_Pokemon, players_Active_Pokemon, opposing_Active_Pokemon.Moves[rand.Next(opposing_Active_Pokemon.Moves.Count)]);
                if (did_pokemon_faint == true)
                {
                    switchPokemon(true);
                }
            }
            return successFullCatch;
        }
        public Boolean Pokemon_Fight()
        {
            List<string> your_pokemons_moves = new List<string>();
            string input = "";
            Boolean all_Pokemon_Fainted = false;
            pokemonMove your_selected_move = null;
            pokemonMove your_opponents_move = null;
            Boolean did_pokemon_faint = false;
            while (true)
            {
                slowTyper("~Your " +players_Active_Pokemon.name+" knows the moves`");
                foreach (KeyValuePair<string, pokemonMove> kvp in GameReference.pokemonMoves)
                {
                    foreach (pokemonMove pokM in players_Active_Pokemon.Moves)
                    {

                        if (pokM == kvp.Value)
                        {
                            slowTyper(("`" + kvp.Key).Replace("_"," "));
                            your_pokemons_moves.Add(kvp.Key);
                        }
                    }
                }
                slowTyper("~Which one of these moves would you like to use? Or if you would like to not attack at all, just type back.");
                input = slowTyper("~|~").ToLower().Replace(" ","");
                if (input.ToLower().Contains("back")) 
                {
                    return all_Pokemon_Fainted;
                }
                foreach (string pokemon_move in your_pokemons_moves)
                {
                    if (input.ToLower().Contains(pokemon_move.ToLower().Replace("_","")) && pokemon_move.ToLower().Length>0)
                    {
                        your_selected_move = GameReference.pokemonMoves[pokemon_move];
                    }
                }
                if (your_selected_move != null)
                {
                    if (your_selected_move.PP > 0)
                    {
                        break;
                    }
                    else 
                    {
                        slowTyper("Sorry but you cannot use that move because your Pokemon has used it too many times.");
                    }
                }
                else 
                {
                    slowTyper("Your Pokemon does not know that move.");
                }
            }
            int timeslooped = 0;
            foreach (pokemonMove pokM in opposing_Active_Pokemon.Moves) 
            {
                timeslooped += 1;
            }
            int which_move = rand.Next(0, timeslooped);
            timeslooped = 0;
            foreach (pokemonMove pokM in opposing_Active_Pokemon.Moves) 
            {
                if (timeslooped == which_move) 
                {
                    your_opponents_move = pokM;
                }
                timeslooped += 1;
            }
            did_pokemon_faint= PokemonAttack(players_Active_Pokemon, opposing_Active_Pokemon, your_selected_move);
            if (did_pokemon_faint == true) 
            {
                slowTyper("~The opposing " + opposing_Active_Pokemon.name + " fainted!");
                opposing_Active_Pokemon.active = false;
                if (opponents_Pokemon.Count > 1) 
                {
                    int switchable_Pokemon = 0;
                    foreach (Pokemon pok2 in opponents_Pokemon)
                    {
                        if (pok2.HP > 0)
                        {
                            switchable_Pokemon += 1;
                        }
                    }
                    if (switchable_Pokemon <= 0)
                    {
                        all_Pokemon_Fainted = true;
                        if (is_a_Trainer_Battle == true) 
                        {
                            slowTyper("~You defeated " + name_of_Opposing_Trainer + "!");
                        }
                        return all_Pokemon_Fainted;
                    }
                    else
                    {
                        int what_Pokemon_To_Switch_To = rand.Next(0, switchable_Pokemon);
                        timeslooped = 0;
                        foreach (Pokemon pok2 in opponents_Pokemon)
                        {
                            if (pok2.HP > 0)
                            {
                                if (timeslooped == what_Pokemon_To_Switch_To)
                                {
                                    opposing_Active_Pokemon = pok2;
                                    opposing_Active_Pokemon.active = true;
                                }
                                timeslooped += 1;
                            }
                        }
                    }
                    return all_Pokemon_Fainted;
                }
                else 
                {
                    all_Pokemon_Fainted = true;
                    if (is_a_Trainer_Battle == true)
                    {
                        slowTyper("~You defeated " + name_of_Opposing_Trainer + "!");
                    }
                    return all_Pokemon_Fainted;
                }
            }
            did_pokemon_faint= PokemonAttack(opposing_Active_Pokemon, players_Active_Pokemon, your_opponents_move);
            if (did_pokemon_faint == true) 
            {
                slowTyper("~"+players_Active_Pokemon.user_Given_Alternate_Name+" fainted!");
                players_Active_Pokemon.active = false;
                all_Pokemon_Fainted = switchPokemon(true);
                if (all_Pokemon_Fainted == true) 
                {
                    slowTyper("~All of your Pokemon have fainted! You rush to a Pokestop to heal them.");
                    //healing code in switch Pokemon
                }
                
            }
            return all_Pokemon_Fainted;
        }
        public void PokemonBattle(Pokemon wildPokemonEncountered, Pokemon pok)
        {
            opposing_Active_Pokemon = wildPokemonEncountered;
            players_Active_Pokemon = pok;
            pokemon_to_get_XP.Add(new individual_pokemon_XP { XP_to_Gain = 20, Pokemon_to_Get_XP = pok });
            while (true)
            {
                string input;
                input = slowTyper("~The opposing "+opposing_Active_Pokemon.name+" has " + opposing_Active_Pokemon.HP + " health left.~Your "+players_Active_Pokemon.name+" has " + players_Active_Pokemon.HP + " health left.~Would you like to now attack the other Pokemon, switch your Pokemon, or attempt to catch the other Pokemon?~|~");
                input = input.ToLower();
                if (input.Contains("run"))
                {
                    slowTyper("You ran away from the Pokemon.");
                    reset_All_Variables();
                    break;
                }
                else if (input.Contains("switch"))
                {
                    Boolean are_all_pokemon_fainted=switchPokemon(false);
                    if (are_all_pokemon_fainted == true) 
                    {
                        slowTyper("~All of your Pokemon have fainted! You rush to a Pokestop to heal them.");
                        //healing code in switch Pokemon
                        give_Pokemon_XP();
                        reset_All_Variables();
                        break;
                    }
                    continue;
                }
                else if (input.Contains("catch"))
                {
                    if (is_a_Trainer_Battle == false)
                    {
                        Boolean success = catchPokemon();
                        if (success == true)
                        {
                            give_Pokemon_XP();
                            reset_All_Variables();
                            break;
                        }
                    }
                    else 
                    {
                        slowTyper("~Sorry, but you are not allowed to attempt to steal other trainer's Pokemon.");
                    }
                }
                else if(input.Contains("attack"))
                {
                    Boolean all_Pokemon_Fainted=Pokemon_Fight();
                    if (all_Pokemon_Fainted == true) 
                    {
                        give_Pokemon_XP();
                        reset_All_Variables();
                        break;
                    }
                }
                else 
                {
                    slowTyper("~Sorry but I don't understand that. Please try again.");
                }
            }
        }
        public void speak_Of_Pokemon_Damage(Pokemon pokemon, int damage) 
        {
            if (GameReference.pokemonInBag.Contains(pokemon)) 
            { 
                slowTyper("~"+pokemon.user_Given_Alternate_Name+" took " + damage+".");
                foreach(individual_pokemon_XP XP in pokemon_to_get_XP) 
                {
                    if (XP.Pokemon_to_Get_XP == pokemon) 
                    {
                        XP.XP_to_Gain += Convert.ToInt32(Math.Round(damage*0.5));
                    }
                }
            }
            else 
            {
                if (is_a_Trainer_Battle == true)
                {
                    slowTyper("~Your opponent's " + pokemon.name + " took " + damage + ".");
                }
                else 
                {
                    slowTyper("~The wild " + pokemon.name + " took " + damage + ".");
                }
            }
        }
        public Boolean PokemonAttack(Pokemon attacker, Pokemon defender, pokemonMove pokMove)
        {
            Boolean did_Pokemon_Faint=false;
            if (pokMove.accuracy == 100)
            {
                pokMove.PP -= 1;
                DealDamage(attacker, defender, pokMove);
            }
            else
            {
                int dodgeOrNot = rand.Next(1, 10);
                if (dodgeOrNot == 10)
                {
                    pokMove.PP -= 1;
                    if (GameReference.pokemonInBag.Contains(attacker))
                    {
                        slowTyper("~"+attacker.user_Given_Alternate_Name+"'s attack missed!");
                    }
                    else
                    {
                        slowTyper("~The opposing" + attacker.name + "'s attack missed!");
                    }
                }
                else if (dodgeOrNot == 1)
                {

                    pokMove.PP -= 1;
                    DealDamage(attacker, defender, pokMove);
                }
                else
                {
                    if ((defender.speed * dodgeOrNot) / 2 - attacker.speed > 100)
                    {
                        pokMove.PP -= 1;
                        if (GameReference.pokemonInBag.Contains(attacker))
                        {
                            slowTyper("~"+attacker.user_Given_Alternate_Name + "'s attack missed!");
                        }
                        else 
                        {
                            slowTyper("~The opposing" + attacker.name + "'s attack missed!");
                        }
                    }
                    else
                    {
                        pokMove.PP -= 1;
                        DealDamage(attacker, defender, pokMove);
                    }
                }
            }
            if (defender.HP <= 0) 
            {
                did_Pokemon_Faint = true;
            }
            return (did_Pokemon_Faint);

        }
        public void DealDamage(Pokemon attacker, Pokemon defender, pokemonMove pokMove)
        {
            int damageChange = rand.Next(217, 255);
            double sameTypeBonus = 1;
            double typeModifier = 0;
            if (pokMove.type == attacker.typeOfPokemon)
            {
                sameTypeBonus = 1.5;
            }
            foreach (KeyValuePair<string, typeStrengths> kvp in GameReference.typeStrengths)
            {
                if (kvp.Key == pokMove.type)
                {
                    if (defender.typeOfPokemon == "Normal")
                    {
                        typeModifier = kvp.Value.normal;
                    }
                    else if (defender.typeOfPokemon == "Fight")
                    {
                        typeModifier = kvp.Value.fight;
                    }
                    else if (defender.typeOfPokemon == "Flying")
                    {
                        typeModifier = kvp.Value.flying;
                    }
                    else if (defender.typeOfPokemon == "Poison")
                    {
                        typeModifier = kvp.Value.poison;
                    }
                    else if (defender.typeOfPokemon == "Ground")
                    {
                        typeModifier = kvp.Value.ground;
                    }
                    else if (defender.typeOfPokemon == "Rock")
                    {
                        typeModifier = kvp.Value.rock;
                    }
                    else if (defender.typeOfPokemon == "Bug")
                    {
                        typeModifier = kvp.Value.bug;
                    }
                    else if (defender.typeOfPokemon == "Ghost")
                    {
                        typeModifier = kvp.Value.ghost;
                    }
                    else if (defender.typeOfPokemon == "Fire")
                    {
                        typeModifier = kvp.Value.fire;
                    }
                    else if (defender.typeOfPokemon == "Water")
                    {
                        typeModifier = kvp.Value.water;
                    }
                    else if (defender.typeOfPokemon == "Plant")
                    {
                        typeModifier = kvp.Value.plant;
                    }
                    else if (defender.typeOfPokemon == "Electric")
                    {
                        typeModifier = kvp.Value.electric;
                    }
                    else if (defender.typeOfPokemon == "Psychic")
                    {
                        typeModifier = kvp.Value.psychic;
                    }
                    else if (defender.typeOfPokemon == "Ice")
                    {
                        typeModifier = kvp.Value.ice;
                    }
                    else
                    {
                        typeModifier = kvp.Value.dragon;
                    }
                }
            }
            int damage = Convert.ToInt32(Math.Round(Convert.ToDouble(((((((((2 * attacker.level / 5 + 2) * attacker.attack * pokMove.power) / defender.defense) / 50) + 2) * sameTypeBonus) * typeModifier) * damageChange / 255))));
            defender.HP -= damage;
            speak_Of_Pokemon_Damage(defender, damage);
        }
    }
}