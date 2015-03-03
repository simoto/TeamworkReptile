namespace TeamWorkGame.Data
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using TeamWorkGame.GameObjects;

    public class RankingManager
    {
        private const string FilePath = @"../../Data/Ranking/top10.txt";
        private const int RankingSize = 10;
        private static List<Participant> ranking;
                
        public static List<Participant> Save(Participant participant)
        {
            ranking = Load();

            bool hasTenPlayers = ranking.Count == RankingSize;
            bool isLastPlayerLevelBigger = ranking.Last().Level > participant.Level;
            bool hasEqualLevelButMoreMoves = ranking.Last().Level == participant.Level && ranking.Last().Moves < participant.Moves;

            if (hasTenPlayers
                && (isLastPlayerLevelBigger
                    || hasEqualLevelButMoreMoves))
            {
                return ranking;
            }

            bool isReplaced = ReplaceIfPlayerIsInTheRanking(participant);

            if (isReplaced == false)
            {
                ranking.Add(participant);
            }

            List<Participant> finalRanking = ranking.OrderByDescending(p => p.Level)
                                .ThenBy(p => p.Moves)
                                .Take(10)
                                .ToList();

            try
            {
                using (StreamWriter sw = new StreamWriter(FilePath))
                {
                    foreach (var player in finalRanking)
                    {
                        sw.WriteLine("{0} {1} {2}", player.Name, player.Level, player.Moves);
                    }
                }
            }
            catch (FileNotFoundException ex)
            {
                throw new FileNotFoundException("Error: Could not read file from disk. Original error: " + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Error: Something went wrong. Original error: " + ex.Message);
            }

            return finalRanking;
        }

        private static List<Participant> Load(int rankingSize = RankingSize)
        {
            StreamReader reader = null;
            var ranking = new List<Participant>();

            try
            {
                reader = new StreamReader(FilePath);
                char[] separators = { ' ' };
                int counter = 0;
                string line = string.Empty;

                while ((line = reader.ReadLine()) != null && counter < rankingSize)
                {
                    string[] data = line.Split(separators, StringSplitOptions.RemoveEmptyEntries);
                    string name = data[0];
                    int level = int.Parse(data[1]);
                    int moves = int.Parse(data[2]);
                    var participant = new Participant(name, level, moves);
                    ranking.Add(participant);
                    counter++;
                }
            }
            catch (FileNotFoundException ex)
            {
                throw new FileNotFoundException("Error: Could not read file from disk. Original error: " + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Error: Something went wrong. Original error: " + ex.Message);
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
            }

            return ranking;
        }

        private static bool ReplaceIfPlayerIsInTheRanking(Participant newParticipant)
        {
            foreach (var participant in ranking)
            {
                if (newParticipant.Name == participant.Name && newParticipant.Moves < participant.Moves)
                {
                    ranking.Remove(participant);
                    ranking.Add(newParticipant);
                    return true;
                }
                else if (newParticipant.Name == participant.Name)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
