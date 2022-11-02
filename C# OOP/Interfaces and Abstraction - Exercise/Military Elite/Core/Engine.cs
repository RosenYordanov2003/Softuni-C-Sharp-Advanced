using Military_Elite.Contracts;
using Military_Elite.Enums;
using Military_Elite.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Military_Elite
{
    public class Engine : IEngine
    {
        Dictionary<int, ISoldier> soldiers;
        public Engine()
        {
            this.soldiers = new Dictionary<int, ISoldier>();
        }
        public void Run()
        {
            string command = string.Empty;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] tokens = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string typeSoldier = tokens[0];
                if (typeSoldier == "Private")
                {
                    ISoldier privateSoldier = new Private(int.Parse(tokens[1]), tokens[2], tokens[3], decimal.Parse(tokens[4]));
                    this.soldiers[int.Parse(tokens[1])] = privateSoldier;
                }
                else if (typeSoldier == "LieutenantGeneral")
                {
                    Dictionary<int, IPrivate> generalPrivateSet = new Dictionary<int, IPrivate>();
                    for (int i = 5; i < tokens.Length; i++)
                    {
                        int currentId = int.Parse(tokens[i]);
                        IPrivate @private = (IPrivate)soldiers[currentId];
                        generalPrivateSet.Add(currentId, @private);
                    }
                    ISoldier generalSoldier = new LieutenantGeneral(int.Parse(tokens[1]), tokens[2], tokens[3], decimal.Parse(tokens[4]), generalPrivateSet);
                    this.soldiers[int.Parse(tokens[1])] = generalSoldier;
                }
                else if (typeSoldier == "Commando")
                {
                    string corp = tokens[5];
                    bool isValidCorp = Enum.TryParse<Corps>(corp, out Corps corpResult);
                    if (!isValidCorp)
                    {
                        continue;
                    }
                    ICollection<IMission> missions = new List<IMission>();
                    for (int i = 6; i < tokens.Length; i += 2)
                    {
                        string codeName = tokens[i];
                        string state = tokens[i + 1];
                        bool isValidState = Enum.TryParse<State>(state, out State stateResult);
                        if (!isValidState)
                        {
                            continue;
                        }
                        else
                        {
                            IMission mission = new Mission(codeName, stateResult);
                            missions.Add(mission);
                        }
                    }
                    ISoldier commando = new Commando(int.Parse(tokens[1]), tokens[2], tokens[3], decimal.Parse(tokens[4]), corpResult, missions);
                    soldiers[int.Parse(tokens[1])] = commando;
                }
                else if (typeSoldier == "Engineer")
                {
                    string corp = tokens[5];
                    bool isValidCorp = Enum.TryParse<Corps>(corp, out Corps corpResult);
                    if (!isValidCorp)
                    {
                        continue;
                    }
                    ICollection<IRepair> repairs = new List<IRepair>();
                    for (int i = 6; i < tokens.Length; i += 2)
                    {
                        string repairPart = tokens[i];
                        int workedHours = int.Parse(tokens[i + 1]);
                        IRepair currentRepair = new Repair(repairPart, workedHours);
                        repairs.Add(currentRepair);
                    }
                    IEngineer engineer = new Engineer(int.Parse(tokens[1]), tokens[2], tokens[3], decimal.Parse(tokens[4]), corpResult, repairs);
                    soldiers[int.Parse(tokens[1])] = engineer;
                }
                else if (typeSoldier == "Spy")
                {
                    ISpy spy = new Spy(int.Parse(tokens[1]), tokens[2], tokens[3], int.Parse(tokens[4]));
                    soldiers[int.Parse(tokens[1])] = spy;
                }
            }
            PrintResult(soldiers);
        }

        private void PrintResult(Dictionary<int, ISoldier> soldiers)
        {
            foreach (KeyValuePair<int,ISoldier> soldier in soldiers)
            {
               
                Console.WriteLine(soldier.Value.ToString());
            }
        }
    }
}
