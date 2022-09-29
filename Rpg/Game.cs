using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;

namespace Rpg
{
    class Game
    {
        /// <summary>
        /// Класс который отвечает за процесс игры
        /// </summary>
        public Game()
        {
            teamOfPlayer = new Teams();
            teamOfComputer = new Teams();
            numberingOfHeroes = new List<BaseHeroe> { new Guardian(), new Archer(), new Knight(), new Wizard() };
            interactionWithUser = new Interaction();
        }
        Teams teamOfPlayer;
        Teams teamOfComputer;
        List<BaseHeroe> numberingOfHeroes;
        Interaction interactionWithUser;
        string nameOfPlayersTeam;
        string nameOfComputersTeam;
        SingleRandom random = SingleRandom.getInstance();

        public string ReadSavedGame(string path)
        { 
            using (StreamReader read = new StreamReader(path))
            {
                string file = read.ReadToEnd();
                return file;
            }
        }
        public void FileOfSavedResults(string savedDatas, string path)
        {

            using (StreamWriter Writer = new StreamWriter(path))
            {
                Writer.Write(savedDatas);
            }
        }

        public void ChoosingName()///<remarks>
                                  ///метод выбора названия команд
                                  ///</remarks>
        {
            List<string> listOfNames = new List<string> {"Воинственные огурчики", "Умиротворённые раки",
                                                         "Хрустящие черепки", "Мирные маллюски", "Нелегальные пирожки"};
            interactionWithUser.ShowTextWriteLine("Выберите название вашей команды");
            nameOfPlayersTeam = interactionWithUser.TakeText();
            nameOfComputersTeam = listOfNames[random.Next(5)];
        }

        public void Start()///<remarks>
                           /// Выбор персонажей
                           /// </remarks>
        {
            interactionWithUser.ShowTextWriteLine("Новая игра - 0 \n Сохранённая игра - 1");
            int chooseOfGame = interactionWithUser.TakeNumber();
            if (chooseOfGame == 0)
            {
                int NumberofHeroes = 3;
                for (int i = 0; i < NumberofHeroes; i++)
                {
                    int heroe;
                    interactionWithUser.ShowTextWriteLine("Выбери персонажа:(0 - Страж, 1 - Лучник, 2 - Рыцарь, 3 - Маг.)");
                    heroe = interactionWithUser.TakeNumber();
                    while (teamOfPlayer.ContainsOfHeroes(numberingOfHeroes[heroe]))
                    {
                        interactionWithUser.ShowTextWriteLine("Такой персонаж уже есть в твоей команде!");
                        interactionWithUser.ShowTextWriteLine("Выбери персонажа:(0 - Страж, 1 - Лучник, 2 - Рыцарь, 3 - Маг.)");
                        heroe = interactionWithUser.TakeNumber();
                    }
                    teamOfPlayer.AddingHeroes(numberingOfHeroes[heroe]);
                }
                for (int i = 0; i < NumberofHeroes; i++)
                {
                    int heroeOfComputer = random.Next(4);
                    while (!teamOfComputer.AddingHeroes(numberingOfHeroes[heroeOfComputer]))
                    {
                        heroeOfComputer = random.Next(4);
                    }
                }
                interactionWithUser.Clear();
                ChoosingName();
                interactionWithUser.Clear();
            }
            else
            {
                string pathOfPlayer = "D:\\NekitNig програмирование\\SavedGames\\teamOfPlayer.txt";
                string pathOfComputer = "D:\\NekitNig програмирование\\SavedGames\\teamOfComputer.txt";
                string playersSaves = ReadSavedGame(pathOfPlayer);
                string computersSaves = ReadSavedGame(pathOfComputer);
                Teams savedTeamOfPlayer = JsonConvert.DeserializeObject<Teams>(playersSaves); 
                Teams savedTeamOfComputer = JsonConvert.DeserializeObject<Teams>(computersSaves);
                teamOfPlayer = savedTeamOfPlayer;
                teamOfComputer = savedTeamOfComputer;
            }
        }
        public void TeableofHeroes()///<remarks>
                                    ///метод который показывает информацию о героях команд
                                    ///</remarks>
        {

            interactionWithUser.ShowTextWriteLine(nameOfPlayersTeam);
            for (int i = 0; i < teamOfPlayer.CountOfHeroes; i++)
            {
                interactionWithUser.ShowTextWriteLine($"{i}. {teamOfPlayer.InfoOfHeroe(i)}");
            }
            interactionWithUser.ShowTextWriteLine(nameOfComputersTeam);
            for (int i = 0; i < teamOfComputer.CountOfHeroes; i++)
            {
                interactionWithUser.ShowTextWriteLine($"{i}.{teamOfComputer.InfoOfHeroe(i)}");
            }
        }
        public void Fight()///<remarks>
                           ///процесс сражения
                           ///</remarks>
        {
            while (teamOfPlayer.StatusOfAllHeroes() || teamOfComputer.StatusOfAllHeroes())
            {
                int attackingHeroe;
                int attackedHeroe;
                TeableofHeroes();
                interactionWithUser.ShowTextWriteLine("Кем вы хотите атаковать?");
                attackingHeroe = interactionWithUser.TakeNumber();
                while (!teamOfPlayer.StatusOfHeroe(attackingHeroe))
                {
                    interactionWithUser.ShowTextWriteLine("Этот герой умер. Кем вы хотите атаковать?");
                    attackingHeroe = interactionWithUser.TakeNumber();
                }
                int damage = teamOfPlayer.TakingDamage(attackingHeroe);
                interactionWithUser.ShowTextWriteLine("Кого вы хотите атаковать?");
                attackedHeroe = interactionWithUser.TakeNumber();
                while (!teamOfComputer.StatusOfHeroe(attackedHeroe))
                {
                    interactionWithUser.ShowTextWriteLine("Этот персонаж уже умер. Кого вы хотите атаковать?");
                    attackedHeroe = interactionWithUser.TakeNumber();
                }
                teamOfPlayer.GetDamage(attackedHeroe, damage);
                interactionWithUser.ShowTextWriteLine($"Ваш {numberingOfHeroes[attackingHeroe].Name} нанёс {damage} урона " +
                                             $"{numberingOfHeroes[attackedHeroe].Name}у компьютера. Нажмите enter для продолжения");
                interactionWithUser.TakeText();
                attackingHeroe = random.Next(3);
                while (!teamOfComputer.StatusOfHeroe(attackingHeroe))
                {
                    attackingHeroe = random.Next(3);
                }
                damage = teamOfComputer.TakingDamage(attackingHeroe);
                attackedHeroe = random.Next(4);
                while (!teamOfPlayer.StatusOfHeroe(attackedHeroe))
                {
                    attackedHeroe = random.Next(4);
                }
                teamOfComputer.GetDamage(attackedHeroe, damage);
                interactionWithUser.ShowTextWriteLine($"{numberingOfHeroes[attackingHeroe].Name} компьютера нанёс {damage} урона твоему " +
                                             $"{numberingOfHeroes[attackedHeroe].Name}. Нажмите enter для продолжения");
                interactionWithUser.TakeText();
                interactionWithUser.Clear();
                interactionWithUser.ShowTextWriteLine("Хотите-ли вы сохранить текущий результат(да - 0, нет - 1)?");
                int choise = interactionWithUser.TakeNumber();
                if (choise == 0)
                {
                    string pathOfPlayer = "D:\\NekitNig програмирование\\SavedGames\\teamOfPlayer.txt";
                    string pathOfComputer = "D:\\NekitNig програмирование\\SavedGames\\teamOfComputer.txt";
                    string savingteamOfPlayer = JsonConvert.SerializeObject(teamOfPlayer, Formatting.Indented);
                    FileOfSavedResults(savingteamOfPlayer, pathOfPlayer);
                    string savingteamOfComputer = JsonConvert.SerializeObject(teamOfComputer, Formatting.Indented);
                    FileOfSavedResults(savingteamOfComputer, pathOfComputer);
                }
                interactionWithUser.Clear();
            }
        }
        public void End()///<remarks>
                         ///исходы битв
                         ///</remarks>
        {
            if (teamOfPlayer.StatusOfAllHeroes())
            {
                interactionWithUser.ShowTextWriteLine("Ты проиграл");
            }
            else
            {
                interactionWithUser.ShowTextWriteLine("ты выиграл");
            }
        }
    }
}
