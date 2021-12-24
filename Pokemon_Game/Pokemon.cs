using System;
using System.Collections.Generic;
namespace Pokemon_Game
{
    public class Pokemon
    {
        public static int yourGreatestPokemonLevel = 0;
        Random rnd = new Random();
        public String name { get; set; }
        public String user_Given_Alternate_Name { get; set; }
        public bool active { get; set; }
        public int level { get; set; }
        public int HP { get; set; }
        public List<pokemonMove> Moves = new List<pokemonMove>();
        public int maxHP { get; set; }
        public int attack { get; set; }
        public int defense { get; set; }
        public int speed { get; set; }
        public int special { get; set; }
        public int catchRate { get; set; }
        public string typeOfPokemon { get; set; }
        public string evolvesFrom { get; set; }
        public Boolean is_Starting_Pokemon { get; set; }
        public int XP { get; set; }
        public int evolutionNumber { get; set; }



        //Pokemon Creater 1
        public Pokemon(string name, int level, pokemonStats stat)
        {
            this.attack = stat.attack;
            this.maxHP = stat.maxHP;
            this.active = active;
            this.name = name;
            this.HP = stat.HP;
            this.defense = stat.defense;
            this.speed = stat.speed;
            this.special = stat.special;
            this.active = active;
            this.level = level;
            this.XP = 100 * level-100;
            this.typeOfPokemon = stat.typeOfPokemon;
            this.catchRate = stat.catchRate;
            this.evolvesFrom = stat.evolvesFrom;
            this.evolutionNumber = evolutionNumber;
            this.is_Starting_Pokemon = is_Starting_Pokemon;
            this.user_Given_Alternate_Name = name;
            for (int i = 1; i < level; i++)
            {
                maxHP = (int)Math.Round(maxHP * stat.HPmultiplier + maxHP);
                speed = (int)Math.Round(speed * stat.speedMultiplier + speed);
                attack = (int)Math.Round(attack * stat.attackMultiplier + attack);
                defense = (int)Math.Round(defense * stat.defenseMultiplier + defense);
                special = (int)Math.Round(special * stat.specialMultiplier + special);
            }
            if (level > yourGreatestPokemonLevel)
            {
                yourGreatestPokemonLevel = level;
            }
            if (level == 1)
            {
                Moves.Add(GameReference.pokemonMoves["Tackle"]);
                if (GameReference.pokemonInformation[name].typeOfPokemon == "Water")
                {
                    Moves.Add(GameReference.pokemonMoves["Water_Gun"]);
                }
                else if (GameReference.pokemonInformation[name].typeOfPokemon == "Fire")
                {
                    Moves.Add(GameReference.pokemonMoves["Ember"]);
                }
                else
                {
                    Moves.Add(GameReference.pokemonMoves["Vine_Whip"]);
                }
            }
            for (int i = (int)Math.Round(level / 5.0); i > 0; i -= 1)
            {
                if (Moves.Count <= 4)
                {
                    int moveNum = rnd.Next(0, stat.pokemonPossibleMoves.Count);
                    if (Moves.Contains(GameReference.pokemonMoves[stat.pokemonPossibleMoves[moveNum]]))
                    {
                        i += 1;
                        continue;
                    }
                    else
                    {
                        Moves.Add(GameReference.pokemonMoves[stat.pokemonPossibleMoves[moveNum]]);
                    }
                }
                else
                {
                    break;
                }

            }


        }


        // Pokemon Creater 2
        public Pokemon(string name, pokemonStats stat)
        {
            this.attack = stat.attack;
            this.maxHP = stat.maxHP;
            this.active = active;
            this.name = name;
            this.HP = stat.HP;
            this.maxHP = stat.HP;
            this.defense = stat.defense;
            this.speed = stat.speed;
            this.special = stat.special;
            this.typeOfPokemon = stat.typeOfPokemon;
            this.catchRate = stat.catchRate;
            this.evolvesFrom = stat.evolvesFrom;
            this.evolutionNumber = evolutionNumber;
            this.is_Starting_Pokemon = is_Starting_Pokemon;
            this.user_Given_Alternate_Name = name;
            this.XP = (int)Math.Round(rnd.NextDouble()*((5 / 4 * ((yourGreatestPokemonLevel*100)-100))-(3 / 4 * ((yourGreatestPokemonLevel * 100) - 100))));
            if (this.XP < 100) 
            {
                this.level = 1;
            }
            LevelUp();

        }



        public void LevelUp()
        {
            Boolean is_your_Pokemon = false;
            foreach (Pokemon pok in GameReference.pokemonInBag)
            {
                if (this.name == pok.name && this.attack == pok.attack && this.Moves == pok.Moves && this.special == pok.special && this.defense == pok.defense && this.level == level)
                {
                    is_your_Pokemon = true;
                }
            }
            while (true)
            {
                bool isInt = (level / 5 % 1) == 0;
                if (this.level == 1 && XP<100)
                {
                    if (isInt == true && this.Moves.Count <= this.level / 5)
                    {
                        AddMoves();
                    }
                    else
                    {
                        break;
                    }
                }
                if (this.XP >= (this.level * 100))
                {
                    foreach (KeyValuePair<string, pokemonStats> kvp in GameReference.pokemonInformation)
                    {
                        if (this.name == kvp.Key)
                        {
                            this.maxHP = (int)Math.Round(this.maxHP * kvp.Value.HPmultiplier + this.maxHP);
                            this.speed = (int)Math.Round(this.speed * kvp.Value.speedMultiplier + this.speed);
                            this.attack = (int)Math.Round(this.attack * kvp.Value.attackMultiplier + this.attack);
                            this.defense = (int)Math.Round(this.defense * kvp.Value.defenseMultiplier + this.defense);
                            this.special = (int)Math.Round(this.special * kvp.Value.specialMultiplier + this.special);
                        }
                    }
                    this.level += 1;
                    isInt = (level / 5 % 1) == 0;
                    if (is_your_Pokemon == true)
                    {
                        Pokemon_Game.MainClass.slowTyper("~Your " + this.name + " leveled up! It is now level " + this.level + "!");
                    }
                    continue;
                }
                else if (this.level >= 25 && isInt == true && this.evolutionNumber == 1)
                {
                    foreach (KeyValuePair<string, pokemonStats> kvp in GameReference.pokemonInformation)
                    {
                        if (kvp.Value.evolvesFrom == this.name)
                        {
                            Pokemon evolved_Pokemon = new Pokemon(kvp.Key, 1, kvp.Value);
                            evolved_Pokemon.XP = this.XP;
                            while (XP >= (level * 100))
                            {
                                evolved_Pokemon.maxHP = (int)Math.Round(evolved_Pokemon.maxHP * kvp.Value.HPmultiplier + evolved_Pokemon.maxHP);
                                evolved_Pokemon.speed = (int)Math.Round(evolved_Pokemon.speed * kvp.Value.speedMultiplier + evolved_Pokemon.speed);
                                evolved_Pokemon.attack = (int)Math.Round(evolved_Pokemon.attack * kvp.Value.attackMultiplier + evolved_Pokemon.attack);
                                evolved_Pokemon.defense = (int)Math.Round(evolved_Pokemon.defense * kvp.Value.defenseMultiplier + evolved_Pokemon.defense);
                                evolved_Pokemon.special = (int)Math.Round(evolved_Pokemon.special * kvp.Value.specialMultiplier + evolved_Pokemon.special);
                                level += 1;
                            }
                            foreach (pokemonMove pokM in this.Moves)
                            {
                                evolved_Pokemon.Moves.Add(pokM);
                            }
                            //turns this Pokemon into evolved Pokemon
                            this.attack = evolved_Pokemon.attack;
                            this.maxHP = evolved_Pokemon.maxHP;
                            this.active = evolved_Pokemon.active;
                            this.name = evolved_Pokemon.name;
                            this.HP = evolved_Pokemon.HP;
                            this.maxHP = evolved_Pokemon.HP;
                            this.defense = evolved_Pokemon.defense;
                            this.speed = evolved_Pokemon.speed;
                            this.special = evolved_Pokemon.special;
                            this.typeOfPokemon = evolved_Pokemon.typeOfPokemon;
                            this.catchRate = evolved_Pokemon.catchRate;
                            this.evolvesFrom = evolved_Pokemon.evolvesFrom;
                            this.evolutionNumber = evolved_Pokemon.evolutionNumber;
                            this.is_Starting_Pokemon = evolved_Pokemon.is_Starting_Pokemon;

                        }
                    }
                }
                else if (isInt == true && this.Moves.Count <= level / 5)
                {
                    AddMoves();
                }
                else
                {
                    break;
                }
            }

        }


        public void AddMoves()
        {
            Random rand = new Random();
            int moveNum = 0;
            pokemonStats thisPokemonsStats = GameReference.pokemonInformation[this.name];
            if (this.Moves.Count <= 4)
            {
                this.Moves.Add(GameReference.pokemonMoves[thisPokemonsStats.pokemonPossibleMoves[moveNum]]);
            }
            else
            {
                while (true)
                {
                    moveNum = rnd.Next(0, thisPokemonsStats.pokemonPossibleMoves.Count);
                    if (this.Moves.Contains(GameReference.pokemonMoves[thisPokemonsStats.pokemonPossibleMoves[moveNum]]))
                    {
                        continue;
                    }
                    else
                    {
                        Boolean is_players_pokemon = false;
                        foreach (Pokemon pok in GameReference.pokemonInBag)
                        {
                            if (pok.Moves == Moves && pok.HP == HP && pok.name == name && pok.special == special && pok.attack == attack)
                            {
                                is_players_pokemon = true;
                            }
                        }
                        if (is_players_pokemon == true)
                        {
                            string input = Pokemon_Game.MainClass.slowTyper("~" + this.name + " would like to learn the move " + GameReference.pokemonMoves[thisPokemonsStats.pokemonPossibleMoves[moveNum]].name + ". WOuld you like " + this.name + " to learn this move?~|~");
                            if (Pokemon_Game.MainClass.check_If_Answer_Is_Yes(input))
                            {
                                if (this.Moves.Count == 4)
                                {
                                    string moves = "";
                                    int amount_of_commas = 0;
                                    foreach (pokemonMove pokM in this.Moves)
                                    {
                                        moves = moves + pokM.name;
                                        amount_of_commas += 1;
                                        if (amount_of_commas == 3)
                                        {
                                            moves = moves + ", and ";
                                        }
                                        else if (amount_of_commas == 4)
                                        {
                                            moves = moves + ".";
                                        }
                                        else
                                        {
                                            moves = moves + ", ";
                                        }

                                    }
                                    string what_move_to_forget = Pokemon_Game.MainClass.slowTyper("~Your " + this.name + " already knows 4 moves. They are " + moves + "Which one would you like " + this.name + " to forget. If you don't want to forget one just type none. ~|~");
                                    while (true)
                                    {
                                        foreach (pokemonMove pokM in this.Moves)
                                        {
                                            if (pokM.name.ToLower().Replace("_", "").Contains(what_move_to_forget.ToLower().Replace(" ", "")))
                                            {
                                                this.Moves.Remove(pokM);
                                                this.Moves.Add(GameReference.pokemonMoves[thisPokemonsStats.pokemonPossibleMoves[moveNum]]);
                                                Pokemon_Game.MainClass.slowTyper("~Your " + this.name + " forgot the move " + pokM.name + " and learned the move " + GameReference.pokemonMoves[thisPokemonsStats.pokemonPossibleMoves[moveNum]].name + "!");
                                            }
                                        }
                                        if (what_move_to_forget.ToLower().Contains("none"))
                                        {
                                            break;
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {

                            int move_to_remove = rand.Next(0, 4);
                            int times_looped = 0;
                            foreach (pokemonMove pokM in this.Moves)
                            {
                                times_looped += 1;
                                if (times_looped == move_to_remove)
                                {
                                    this.Moves.Remove(pokM);
                                }
                            }
                            this.Moves.Add(GameReference.pokemonMoves[thisPokemonsStats.pokemonPossibleMoves[moveNum]]);
                        }
                    }
                }
            }

        }
    }
}
