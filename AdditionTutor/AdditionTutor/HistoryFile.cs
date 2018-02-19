using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdditionTutor
{
    class HistoryFile
    {
        const string FILES_SUBFOLDER = "AdditionTutor";
        const string FILE_HISTORY_NAME = "hist.txt";
        const string FILE_RESULT_NAME = "results.txt";

        public void AddItem(AdditionQuestion question)
        {
            var appDataPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            var path = Path.Combine(appDataPath, FILES_SUBFOLDER);
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            var pathHistory = Path.Combine(path, FILE_HISTORY_NAME);
            var pathResult = Path.Combine(path, FILE_RESULT_NAME);

            File.AppendAllText(pathResult, question.ToBeautifulString());
            File.AppendAllText(pathHistory, question.ToString());
        }

        public List<AdditionQuestion> GetAllItens()
        {
            List<AdditionQuestion> retList = new List<AdditionQuestion>();
            var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), $"{FILES_SUBFOLDER}/{FILE_HISTORY_NAME}");

            foreach (string line in File.ReadAllLines(path))
                retList.Add(new AdditionQuestion(line));

            return retList;
        }
    }
}
