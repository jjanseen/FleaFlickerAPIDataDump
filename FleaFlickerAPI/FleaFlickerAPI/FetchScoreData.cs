using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System.IO;

namespace FleaFlickerAPI
{
    public class FetchScoreData
    {
        private IProgress<string> _reportProgress;
        private static readonly HttpClient client = new HttpClient();
        private readonly string _leagueID;
        private readonly string _season;

        public FetchScoreData(string leagueID, string season)
        {
            _leagueID = leagueID;
            _season = season;
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Add("User-Agent", "JJ FetchScore Data");
            client.DefaultRequestHeaders.Add("Accept", "*/*");
            client.DefaultRequestHeaders.Add("Accept-Encoding", "gzip, deflate, br");
            client.DefaultRequestHeaders.Add("Connection", "keep-alive");
        }

        public async Task ExecuteAsync(IProgress<string> progress, IProgress<string> importComplete)
        {
            //https://www.fleaflicker.com/api-docs/index.html

            _reportProgress = progress;

            _reportProgress.Report($"Starting download...");
            string url = $"https://www.fleaflicker.com/api/FetchLeagueStandings?sport=NFL&league_id={_leagueID}&season={_season}";
            var jsonResult = await client.GetStreamAsync(url);
            Standings standings = DeserializeCompressed<Standings>(jsonResult);
            //iterate each team in divicion[0], put team id, name into sheet 1 of new excel workbook

            //then call https://www.fleaflicker.com/api/FetchLeagueScoreboard?sport=NFL&league_id=295664&season=2019&scoring_period=1
            //for each scoring period, get data for the scoring period, output game info
            //each weeks games in new sheet

            var currentDirectory = Directory.GetCurrentDirectory();
            var fullFilePath = Path.Combine(currentDirectory, $"{_season}LeageData.xlsx");
            using (FileStream stream = new FileStream(fullFilePath, FileMode.Create, FileAccess.Write))
            {

                IWorkbook wb = new XSSFWorkbook();
                ISheet teamSheet = wb.CreateSheet("Teams");
                WriteTeamHeaderRow(teamSheet);
                WriteTeamRows(standings, teamSheet);

                await WriteScores(wb);

                for (int i = 0; i < 12; i++)
                {
                    teamSheet.AutoSizeColumn(i);
                }

                wb.Write(stream);
            }

            importComplete.Report(fullFilePath);

            return;
        }

        private void WriteTeamHeaderRow(ISheet sheet)
        {
            IRow header = sheet.CreateRow(0);

            int column = 0;
            var cell = header.CreateCell(column);
            cell.SetCellValue("Team ID");
            column++;

            cell = header.CreateCell(column);
            cell.SetCellValue("Team Name");
            column++;

            cell = header.CreateCell(column);
            cell.SetCellValue("Total Points For");
            column++;

            cell = header.CreateCell(column);
            cell.SetCellValue("Total Points Against");
            column++;

            cell = header.CreateCell(column);
            cell.SetCellValue("Wins");
            column++;

            cell = header.CreateCell(column);
            cell.SetCellValue("Losses");
            column++;

            cell = header.CreateCell(column);
            cell.SetCellValue("Overall Rank");
            column++;

            cell = header.CreateCell(column);
            cell.SetCellValue("Postseason Wins");
            column++;

            cell = header.CreateCell(column);
            cell.SetCellValue("Postseason Losses");
            column++;

            cell = header.CreateCell(column);
            cell.SetCellValue("Postseason Rank");
            column++;

            cell = header.CreateCell(column);
            cell.SetCellValue("Streak");
            column++;

            cell = header.CreateCell(column);
            cell.SetCellValue("Draft Position");
            column++;
        }

        private void WriteTeamRows(Standings standings, ISheet sheet)
        {
            int rowNum = 1;
            foreach (var team in standings.Divisions[0].Teams)
            {
                int column = 0;
                IRow row = sheet.CreateRow(rowNum);

                var cell = row.CreateCell(column);
                cell.SetCellValue(team.Id.ToString());
                column++;

                cell = row.CreateCell(column);
                cell.SetCellValue(team.Name);
                column++;

                cell = row.CreateCell(column);
                cell.SetCellValue(team.PointsFor.Formatted);
                column++;

                cell = row.CreateCell(column);
                cell.SetCellValue(team.PointsAgainst.Formatted);
                column++;

                cell = row.CreateCell(column);
                cell.SetCellValue(team.RecordOverall.Wins.GetValueOrDefault());
                column++;

                cell = row.CreateCell(column);
                cell.SetCellValue(team.RecordOverall.Losses.GetValueOrDefault());
                column++;

                cell = row.CreateCell(column);
                cell.SetCellValue(team.RecordOverall.Rank.ToString());
                column++;

                cell = row.CreateCell(column);
                cell.SetCellValue(team.RecordPostseason.Wins.GetValueOrDefault());
                column++;

                cell = row.CreateCell(column);
                cell.SetCellValue(team.RecordPostseason.Losses.GetValueOrDefault());
                column++;

                cell = row.CreateCell(column);
                cell.SetCellValue(team.RecordPostseason.Rank.ToString());
                column++;

                cell = row.CreateCell(column);
                cell.SetCellValue(team.Streak.Formatted);
                column++;

                cell = row.CreateCell(column);
                cell.SetCellValue(team.DraftPosition.ToString());
                column++;

                rowNum++;
            }

        }

        private async Task WriteScores(IWorkbook workbook)
        {
            //get first period just to get all the elligible schedule periods
            string url = $"https://www.fleaflicker.com/api/FetchLeagueScoreboard?sport=NFL&league_id={_leagueID}&season={_season}&scoring_period=1";
            var jsonResult = await client.GetStreamAsync(url);
            Scoring scores = DeserializeCompressed<Scoring>(jsonResult);
            foreach (var period in scores.EligibleSchedulePeriods)
            {
                url = $"https://www.fleaflicker.com/api/FetchLeagueScoreboard?sport=NFL&league_id={_leagueID}&season={_season}&scoring_period={period.Ordinal}";
                jsonResult = await client.GetStreamAsync(url);
                scores = DeserializeCompressed<Scoring>(jsonResult);

                ISheet sheet = workbook.CreateSheet("Week " + period.Ordinal.ToString());
                WriteWeeklyScoresHeaderRow(sheet);
                WriteGameResultsRows(sheet, scores);

                for (int i = 0; i < 6; i++)
                {
                    sheet.AutoSizeColumn(i);
                }
            }

            return;
        }

        private void WriteWeeklyScoresHeaderRow(ISheet sheet)
        {
            IRow header = sheet.CreateRow(0);

            int column = 0;
            var cell = header.CreateCell(column);
            cell.SetCellValue("Home Team ID");
            column++;

            cell = header.CreateCell(column);
            cell.SetCellValue("Home Team Name");
            column++;

            cell = header.CreateCell(column);
            cell.SetCellValue("Home Team Points");
            column++;

            cell = header.CreateCell(column);
            cell.SetCellValue("Away Team ID");
            column++;

            cell = header.CreateCell(column);
            cell.SetCellValue("Away Team Name");
            column++;

            cell = header.CreateCell(column);
            cell.SetCellValue("Away Team Points");
            column++;
        }

        private void WriteGameResultsRows(ISheet sheet, Scoring scores)
        {
            int rowNum = 1;
            foreach (var game in scores.Games)
            {
                IRow row = sheet.CreateRow(rowNum);

                int column = 0;

                var cell = row.CreateCell(column);
                cell.SetCellValue(game.Home.Id.ToString());
                column++;

                cell = row.CreateCell(column);
                cell.SetCellValue(game.Home.Name);
                column++;

                cell = row.CreateCell(column);
                cell.SetCellValue(game.HomeScore.ScoreScore.Value.GetValueOrDefault());
                column++;

                cell = row.CreateCell(column);
                cell.SetCellValue(game.Away.Id.ToString());
                column++;

                cell = row.CreateCell(column);
                cell.SetCellValue(game.Away.Name);
                column++;

                cell = row.CreateCell(column);
                cell.SetCellValue(game.AwayScore.ScoreScore.Value.GetValueOrDefault());
                column++;

                rowNum++;
            }
        }

        public static T DeserializeCompressed<T>(System.IO.Stream stream, Newtonsoft.Json.JsonSerializerSettings settings = null)
        {
            using (var compressor = new System.IO.Compression.GZipStream(stream, System.IO.Compression.CompressionMode.Decompress))
            using (var reader = new System.IO.StreamReader(compressor))
            using (var jsonReader = new Newtonsoft.Json.JsonTextReader(reader))
            {
                var serializer = Newtonsoft.Json.JsonSerializer.CreateDefault(settings);
                return serializer.Deserialize<T>(jsonReader);
            }
        }
    }
}
