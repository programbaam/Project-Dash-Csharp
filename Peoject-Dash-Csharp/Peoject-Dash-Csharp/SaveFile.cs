using System.IO;
using System.Text;

static class SaveFile
{
    static public string FolderPath => "resource";
    static public string FilePath => "resource/UserScores.csv";

    static public void CheckSaveFile()
    {
        // 폴더가 없을때
        if (!Directory.Exists(FolderPath))
        {
            Directory.CreateDirectory(FolderPath);
            File.Create(FilePath).Close();
        }
        else //폴더는 있는데 파일이 없을때
        {
            if (!File.Exists(FilePath))
            {
                File.Create(FilePath).Close();
            }
        }
    }
}