using System.IO;
using System.Text;

static class SaveFile
{
    static public string FolderPath => "resource";
    static public string FilePath => "resource/UserScores.csv";

    static public void CheckSaveFile()
    {
        string folderPath = "resource";
        string filePath = "resource/UserScores.csv";

        // 폴더가 없을때
        if (!Directory.Exists(folderPath))
        {
            Directory.CreateDirectory(folderPath);
            File.Create(filePath).Close();
        }
        else //폴더는 있는데 파일이 없을때
        {
            if (!File.Exists(filePath))
            {
                File.Create(filePath).Close();
            }
        }
    }
}