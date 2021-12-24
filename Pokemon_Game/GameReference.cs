using System;
using System.Collections.Generic;
namespace Pokemon_Game
{
	public class pokemonMove
	{
		public string type { get; set; }
		public int PP { get; set; }
		public int power { get; set; }
		public int accuracy { get; set; }
        public string name { get; set; }

	}
	public class pokemonStats
	{
		public string typeOfPokemon { get; set; }
		public int HP { get; set; }
		public int attack { get; set; }
		public int defense { get; set; }
		public int speed { get; set; }
		public int special { get; set; }
		public List<string> pokemonPossibleMoves = new List<string>();
        public double HPmultiplier { get; set; }
		public double speedMultiplier{ get; set; }
		public double attackMultiplier{ get; set; }
        public double defenseMultiplier{ get; set; }
		public double specialMultiplier{ get; set; }
        public int maxHP { get; set; }
        public int catchRate { get; set; }
        public int evolutionNumber { get; set; }
        public string evolvesFrom { get; set; }


	}
    public class pokemonTrainer
    {
        public string name { get; set; }
        public List<string> typesOfPokemon = new List<string>();
        public double levelMultiplier { get; set; }
    }
    public class item
    {
        public string typeOfItem { get; set; }
        public string nameOfItem { get; set; }
        public int power { get; set; }
    }
    public class typeStrengths
    {
        public double normal { get; set; }
        public double fight { get; set; }
        public double flying { get; set; }
        public double poison { get; set; }
        public double ground { get; set; }
        public double rock { get; set; }
        public double bug { get; set; }
        public double ghost { get; set; }
        public double fire { get; set; }
        public double water { get; set; }
        public double plant { get; set; }
        public double electric { get; set; }
        public double psychic { get; set; }
        public double ice { get; set; }
        public double dragon { get; set; }
    }
    public class GameReference
    {
        public static Dictionary<string, typeStrengths> typeStrengths = new Dictionary<string, typeStrengths>() 
        { 
            {"Normal", new typeStrengths{normal=1,fight=1,flying=1,poison=1, ground=1, rock=0.5, bug=1, ghost=0, fire=1, water=1, plant=1, electric=1, psychic=1, ice=1, dragon=1}},
            {"Fight", new typeStrengths{normal=2,fight=1,flying=0.5,poison=0.5, ground=1, rock=2, bug=0.5, ghost=0, fire=1, water=1, plant=1, electric=1, psychic=0.5, ice=2, dragon=1}},
            {"Flying", new typeStrengths{normal=1,fight=2,flying=1,poison=1, ground=1, rock=0.5, bug=2, ghost=1, fire=1, water=1, plant=2, electric=0.5, psychic=1, ice=1, dragon=1}},
            {"Poison", new typeStrengths{normal=1,fight=1,flying=1,poison=0.5, ground=0.5, rock=0.5, bug=2, ghost=0.25, fire=1, water=1, plant=2, electric=1, psychic=1, ice=1, dragon=1}},
            {"Ground", new typeStrengths{normal=1,fight=1,flying=0,poison=2, ground=1, rock=2, bug=0.5, ghost=1, fire=2, water=1, plant=0.5, electric=2, psychic=1, ice=1, dragon=1}},
            {"Rock", new typeStrengths{normal=1,fight=0.5,flying=2,poison=1, ground=0.5, rock=1, bug=2, ghost=1, fire=2, water=1, plant=1, electric=1, psychic=1, ice=2, dragon=1}},
            {"Bug", new typeStrengths{normal=1,fight=0.5,flying=0.5,poison=2, ground=1, rock=1, bug=1, ghost=0.5, fire=0.5, water=1, plant=2, electric=1, psychic=2, ice=1, dragon=1}},
            {"Ghost", new typeStrengths{normal=0,fight=1,flying=1,poison=1, ground=1, rock=1, bug=1, ghost=2, fire=1, water=1, plant=1, electric=1, psychic=0, ice=1, dragon=1}},
            {"Fire", new typeStrengths{normal=1,fight=1,flying=1,poison=1, ground=1, rock=0.5, bug=2, ghost=1, fire=0.5, water=0.5, plant=2, electric=1, psychic=1, ice=2, dragon=0.5}},
            {"Water", new typeStrengths{normal=1,fight=1,flying=1,poison=1, ground=2, rock=2, bug=1, ghost=1, fire=2, water=0.5, plant=0.5, electric=1, psychic=1, ice=1, dragon=0.5}},
            {"Plant", new typeStrengths{normal=1,fight=1,flying=0.5,poison=0.5, ground=2, rock=2, bug=0.5, ghost=1, fire=0.5, water=2, plant=0.5, electric=1, psychic=1, ice=1, dragon=0.5}},
            {"Electric", new typeStrengths{normal=1,fight=1,flying=2,poison=1, ground=0, rock=1, bug=1, ghost=1, fire=1, water=2, plant=0.5, electric=0.5, psychic=1, ice=1, dragon=0.5}},
            {"Psychic", new typeStrengths{normal=1,fight=2,flying=1,poison=2, ground=1, rock=1, bug=1, ghost=1, fire=1, water=1, plant=1, electric=1, psychic=0.5, ice=1, dragon=1}},       
            {"Ice", new typeStrengths{normal=1,fight=1,flying=2,poison=1, ground=2, rock=1, bug=1, ghost=1, fire=1, water=0.5, plant=2, electric=1, psychic=1, ice=0.5, dragon=2}},
            {"Dragon", new typeStrengths{normal=1,fight=1,flying=1,poison=1, ground=1, rock=1, bug=1, ghost=1, fire=1, water=1, plant=1, electric=1, psychic=1, ice=1, dragon=2}},       
        };
        public static Dictionary<string, pokemonTrainer> pokemonTrainers = new Dictionary<string, pokemonTrainer>()
        {
            {"Robert", new pokemonTrainer{name="Robert",typesOfPokemon={"Plant","Normal"}, levelMultiplier=0.4}},
            {"James", new pokemonTrainer{name="James",typesOfPokemon={"Plant","Normal","Water","Fire","Ice","Flying","Electric","Poison","Psychic","Fighting","Dark","Dragon","Fairy","Rock","Ghost","Ground","Bug"},levelMultiplier=0.8}}
        };
        public static Dictionary<string, item> itemDataBase = new Dictionary<string, item>()
        {
            {"Pokeball", new item{nameOfItem="Pokeball",typeOfItem="Poke-Capture",power=20}},

        };
		public static Dictionary<string, pokemonStats> pokemonInformation = new Dictionary<string, pokemonStats>()
		{
            //Name, Type;Hp;Attack;Defense;Speed;Special (Stats are all base)
            {"Bulbasuar",new pokemonStats{typeOfPokemon="Plant", evolutionNumber=1,HP=45, maxHP=45, attack=49, defense=49,speed=45, special=65, HPmultiplier=0.15, attackMultiplier=0.2, defenseMultiplier=0.2,speedMultiplier=0.1, specialMultiplier=0.15, catchRate=45,pokemonPossibleMoves={"Tackle","Vine_Whip","Poison_Powder","Sleep_Powder","Take_Down","Razer_Leaf, Double-Edge"}}},
			{"Charmander",new pokemonStats{typeOfPokemon="Fire", evolutionNumber=1,HP=39, maxHP=39, attack=52, defense=43,speed=65, special=50, HPmultiplier=0.15, attackMultiplier=0.3, defenseMultiplier=0.1,speedMultiplier=0.2, specialMultiplier=0.15, catchRate=45,pokemonPossibleMoves={"Scratch", "Ember", "Fury_Swipes", "Fire_Spin", "Slash", "Flamethrower"}}},
			{"Squirtle",new pokemonStats{typeOfPokemon="Water", evolutionNumber=1,HP=44, maxHP=44, attack=48, defense=65,speed=43, special=50, HPmultiplier=0.15, attackMultiplier=0.15, defenseMultiplier=0.3,speedMultiplier=0.1, specialMultiplier=0.15, catchRate=45,pokemonPossibleMoves={"Tackle", "Bubble", "Water Gun", "Bite", "Bubble_Beam", "Headbutt", "Hydro_Pump", "Skull_Bash"}}},
            {"Pidgey",new pokemonStats{typeOfPokemon="Normal", evolutionNumber=1,HP=40, maxHP=40, attack=45, defense=40,speed=56, special=35, HPmultiplier=0.15, attackMultiplier=0.15, defenseMultiplier=0.15,speedMultiplier=0.2, specialMultiplier=0.15, catchRate=255,pokemonPossibleMoves={"Pound", "Tackle", "Gust", "Headbutt", "Quick_Attack", "Wing_Attack", "Peck"}}},
            {"Caterpie",new pokemonStats{typeOfPokemon="Bug",evolutionNumber=1, HP=45, maxHP=45, attack=30, defense=35,speed=45, special=20, HPmultiplier=0.15, attackMultiplier=0.15, defenseMultiplier=0.2,speedMultiplier=0.15, specialMultiplier=0.15, catchRate=255,pokemonPossibleMoves={"Pound", "Tackle", "Twinneedle", "Pin_Missile", "Quick_Attack", "Vine_Whip", "Headbutt"}}},
            {"Weedle",new pokemonStats{typeOfPokemon="Bug", evolutionNumber=1,HP=40, maxHP=40, attack=35, defense=30,speed=50, special=20, HPmultiplier=0.15, attackMultiplier=0.15, defenseMultiplier=0.15,speedMultiplier=0.2, specialMultiplier=0.15,catchRate=255,pokemonPossibleMoves={"Pound", "Tackle", "Twinneedle", "Pin_Missile", "Quick_Attack", "Poison_Sting", "Headbutt"}}},
            {"Rattata",new pokemonStats{typeOfPokemon="Normal",evolutionNumber=1, HP=30, maxHP=30, attack=56, defense=35,speed=72, special=25, HPmultiplier=0.1, attackMultiplier=0.2, defenseMultiplier=0.15,speedMultiplier=0.3, specialMultiplier=0.15, catchRate=255,pokemonPossibleMoves={"Pound", "Tackle", "Take Down", "Headbutt", "Quick_Attack", "Body_Slam", "Thrash"}}},
			{"Raticate",new pokemonStats{typeOfPokemon="Normal", evolutionNumber=2,HP=55, maxHP=55, attack=81, defense=60,speed=97, special=50,catchRate=255,pokemonPossibleMoves={"Pound", "Tackle", "Take Down", "Headbutt", "Quick_Attack", "Body_Slam", "Thrash"},evolvesFrom="Rattata"}},

		};

		public static Dictionary<string, pokemonMove> pokemonMoves = new Dictionary<string, pokemonMove>(){
            //Normal Moves PP;Power;Accuracy
            {"Pound",new pokemonMove {type="Normal", PP=35, power=40, accuracy=100, name="Pound"}},
			{"Double_Slap", new pokemonMove{type="Normal", PP=10, power=15, accuracy=85, name="Double_Slap"}},
			{"Comet_Punch",new pokemonMove{type="Normal", PP=15, power=18, accuracy=85, name="Comet_Punch"}},
			{"Mega_Punch",new pokemonMove{type="Normal", PP=20, power=80, accuracy=85, name="Mega_Punch"}},
			{"Pay_Day",new pokemonMove{type="Normal", PP=20, power=40, accuracy=100, name="Pay_Day"}},
			{"Scratch",new pokemonMove{type="Normal", PP=30, power=55, accuracy=100, name="Scratch"}},
			{"Vice_Grip",new pokemonMove{type="Normal", PP=30, power=55, accuracy=100, name="Vice_Grip"}},
			{"Guillotine",new pokemonMove{type="Normal", PP=5, power=999999999, accuracy=30, name="Guillotine"}},
			{"Razer_Wind",new pokemonMove{type="Normal", PP=10, power=80, accuracy=100, name="Razer_Wind"}},
			{"Cut",new pokemonMove{type="Normal", PP=30, power=50, accuracy=95, name="Cut"}},
			{"Bind",new pokemonMove{type="Normal", PP=20, power=15, accuracy=85, name="Bind"}},
			{"Slam",new pokemonMove{type="Normal", PP=20, power=80, accuracy=75, name="Slam"}},
			{"Stomp",new pokemonMove{type="Normal", PP=20, power=65, accuracy=100, name="Stomp"}},
			{"Mega_Kick",new pokemonMove{type="Normal", PP=5, power=120, accuracy=75, name="Mega_Kick"}},
			{"Headbutt",new pokemonMove{type="Normal", PP=15, power=70, accuracy=100, name ="Headbutt"}},
			{"Horn_Attack",new pokemonMove{type="Normal", PP=25, power=65, accuracy=100, name="Horn_Attack"}},
			{"Fury_Attack",new pokemonMove{type="Normal", PP=20, power=15, accuracy=85, name="Fury_Attack"}},
			{"Horn_Drill",new pokemonMove{type="Normal", PP=5, power=999999999, accuracy=30, name="Horn_Drill"}},
			{"Tackle",new pokemonMove{type="Normal", PP=35, power=40, accuracy=100, name="Tackle"}},
			{"Body_Slam",new pokemonMove{type="Normal", PP=15, power=85, accuracy=100, name="Body_Slam"}},
			{"Wrap",new pokemonMove{type="Normal", PP=20, power=15, accuracy=90, name="Wrap"}},
			{"Take_Down",new pokemonMove{type="Normal", PP=20, power=90, accuracy=85, name="Take_Down"}},
			{"Thrash",new pokemonMove{type="Normal", PP=10, power=120, accuracy=100, name="Thrash"}},
			{"Double-Edge",new pokemonMove{type="Normal", PP=15, power=120, accuracy=100, name="Double-Edge"}},
			{"Hyper_Beam",new pokemonMove{type="Normal", PP=5, power=150, accuracy=90, name="Hyper_Beam"}},
			{"Strength",new pokemonMove{type="Normal", PP=15, power=80, accuracy=100,name="Strength"}},
			{"Quick_Attack",new pokemonMove{type="Normal", PP=30, power=40, accuracy=100, name="Quick_Attack"}},
			{"Rage",new pokemonMove{type="Normal", PP=20, power=20, accuracy=100,name="Rage"}},
			{"Self-Destruct",new pokemonMove{type="Normal", PP=5, power=200, accuracy=100, name="Self-Destruct"}},
			{"Egg Bomb",new pokemonMove{type="Normal", PP=10, power=100, accuracy=75, name="Egg Bomb"}},
            //Water Moves
            {"Water_Gun",new pokemonMove{type="Water", PP=25, power=40, accuracy=100, name="Water_Gun"}},
			{"Hydro_Pump",new pokemonMove{type="Water", PP=5, power=110, accuracy=80, name="Hydro_Pump"}},
			{"Surf",new pokemonMove{type="Water", PP=15, power=90, accuracy=100, name="Surf"}},
			{"Bubble_Beam",new pokemonMove{type="Water", PP=20, power=65, accuracy=100, name="Bubble_Beam"}},
            //Plant Moves
            {"Vine_Whip",new pokemonMove{type="Plant", PP=25, power=40, accuracy=100, name="Vine_Whip"}},
			{"Absorb",new pokemonMove{type="Plant", PP=15, power=40, accuracy=100, name="Absorb"}},
			{"Mega_Drain",new pokemonMove{type="Plant", PP=10, power=75, accuracy=100, name="Mega_Drain"}},
			{"Razer_Leaf",new pokemonMove{type="Plant", PP=25, power=55, accuracy=95, name="Razer_Leaf"}},
			{"Solar_Beam",new pokemonMove{type="Plant", PP=10, power=200, accuracy=100, name="Solar_Beam"}},
			{"Petal_Dance",new pokemonMove{type="Plant", PP=10, power=120, accuracy=100, name="Petal_Dance"}},
            //Fire Moves
            {"Fire_Punch",new pokemonMove{type="Fire", PP=15, power=75, accuracy=100, name="Fire_Punch"}},
			{"Ember",new pokemonMove{type="Fire", PP=25, power=40, accuracy=100, name="Ember"}},
			{"Flamethrower",new pokemonMove{type="Fire", PP=15, power=90, accuracy=100, name="Flamethrower"}},
			{"Fire_Spin",new pokemonMove{type="Fire", PP=15, power=35, accuracy=85, name="Fire_Spin"}},
            //Ice Moves
            {"Ice_Punch",new pokemonMove{type="Ice", PP=15, power=75, accuracy=100, name="Ice_Punch"}},
			{"Ice_Beam",new pokemonMove{type="Ice", PP=10, power=90, accuracy=100, name="Ice_Beam"}},
			{"Blizzard",new pokemonMove{type="Ice", PP=5, power=110, accuracy=70, name="Blizzard"}},
			{"Aurora_Beam",new pokemonMove{type="Ice", PP=20, power=65, accuracy=100, name="Aurora_Beam"}},
            //Flying Moves
            {"Gust",new pokemonMove{type="Flying", PP=35, power=40, accuracy=100, name="Gust"}},
			{"Wing_Attack",new pokemonMove{type="Flying", PP=35, power=60, accuracy=100, name="Wing_Attack"}},
			{"Fly",new pokemonMove{type="Flying", PP=15, power=90, accuracy=95, name="Fly"}},
			{"Peck",new pokemonMove{type="Flying", PP=35, power=35, accuracy=100, name="Peck"}},
			{"Drill_Peck",new pokemonMove{type="Flying", PP=20, power=80, accuracy=100, name="Drill_Peck"}},
            //Electric Moves
            {"Thunder_Shock",new pokemonMove{type="Electric", PP=30, power=40, accuracy=100, name="Thunder_Shock"}},
			{"Thunderbolt",new pokemonMove{type="Electric", PP=15, power=90, accuracy=100, name="Thunderbolt"}},
			{"Thunder",new pokemonMove{type="Electric", PP=10, power=110, accuracy=70, name="Thunder"}},
			{"Thunder_Punch",new pokemonMove{type="Electric", PP=15, power=75, accuracy=100, name="Thunder_Punch"}},
            //Poison Moves
            {"Smog",new pokemonMove{type="Poison", PP=20, power=30, accuracy=70, name="Smog"}},
			{"Sludge",new pokemonMove{type="Poison", PP=20, power=65, accuracy=100, name="Sludge"}},
			{"Poison_Sting",new pokemonMove{type="Poison", PP=35, power=15, accuracy=100, name="Poison_Sting"}},
			{"Acid",new pokemonMove{type="Poison", PP=30, power=40, accuracy=100, name="Acid"}},
            //Fighting Moves
            {"Karate_Chop",new pokemonMove{type="Fighting", PP=25, power=50, accuracy=100, name="Karate_Chop"}},
			{"Double_Kick",new pokemonMove{type="Fighting", PP=30, power=30, accuracy=100, name="Double_Kick"}},
			{"Jump_Kick",new pokemonMove{type="Fighting", PP=10, power=100, accuracy=95, name="Jump_Kick"}},
			{"Rolling_Kick",new pokemonMove{type="Fighting", PP=15, power=60, accuracy=85, name="Rolling_Kick"}},
			{"Submission",new pokemonMove{type="Fighting", PP=20, power=80, accuracy=80, name="Submission"}},
            //Psychic Moves
            {"Confusion",new pokemonMove{type="Psychic", PP=25, power=50, accuracy=100, name="Confusion"}},
			{"Psychic",new pokemonMove{type="Psychic", PP=10, power=90, accuracy=100, name="Psychic"}},
			{"Pysbeam",new pokemonMove{type="Psychic", PP=20, power=65, accuracy=100, name="Pysbeam"}},
            //Bug Moves
            {"Twinneedle",new pokemonMove{type="Bug", PP=20, power=25, accuracy=100, name="Twinneedle"}},
			{"Pin_Missle",new pokemonMove{type="Bug", PP=20, power=25, accuracy=95, name="Pin_Missle"}},
            //Ground Moves
            {"Bone_Club",new pokemonMove{type="Ground", PP=20, power=65, accuracy=85, name="Bone_Club"}},
			{"Earthquake",new pokemonMove{type="Ground", PP=10, power=100, accuracy=100, name="Earthquake"}},
			{"Dig",new pokemonMove{type="Ground", PP=10, power=80, accuracy=100, name="Dig"}},
            //Dark Moves
            {"Bite",new pokemonMove{type="Dark", PP=25, power=60, accuracy=100, name="Bite"}},
            //Ghost Moves
            {"Lick",new pokemonMove{type="Ghost", PP=30, power=30, accuracy=100, name="Lick"}},
            //Rock Moves
            {"Rock_Throw",new pokemonMove{type="Rock", PP=15, power=50, accuracy=90, name="Rock_Throw"}}
		};
        public static List<string> startingPokemon = new List<string> { "Charmander", "Bulbasuar", "Squirtle", "Chikorita", "Totodile", "Cyndaquil", "Mudkip", "Treeko", "Torchic", "Turtwig", "Chimchar", "Piplup", "Oshawott", "Snivy", "Tepig", "Froakie", "Fennekin", "Chespin", "Rowlet", "Litten", "Popplio" };
        public static List<Pokemon> pokemonInBag = new List<Pokemon>() { };
        public static List<item> itemsInBag = new List<item>() { };
        public static List<Pokemon> rivalsPokemon = new List<Pokemon>() { };
        public static string characterName;
        public static int townNumber = 1;
    }
}
