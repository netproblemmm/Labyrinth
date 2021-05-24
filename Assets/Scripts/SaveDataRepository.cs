using System.IO;
using UnityEngine;

public sealed class SaveDataRepository
{
    private readonly IData<SavedData> _data;

    private const string _folderName = "dataSave";
    private const string _fileName = "data.xml";
    private readonly string _path;

    public SaveDataRepository()
    {
        _data = new XMLData();
        _path = Path.Combine(Application.dataPath, _folderName);

    }

    public void Save(Ball player)
    {
        if (!Directory.Exists(Path.Combine(_path)))
        {
            Directory.CreateDirectory(_path);
        }
        var savePlayer = new SavedData
        {
            Position = player.transform.position,
            Name = "Yuriy",
            IsEnabled = true
        };

        _data.Save(savePlayer, Path.Combine(_path, _fileName));
    }

    public void Load(Ball player)
    {
        var file = Path.Combine(_path, _fileName);
        if (!File.Exists(file)) return;
        var newPlayer = _data.Load(file);
        player.transform.position = newPlayer.Position;
        player.name = newPlayer.Name;
        player.gameObject.SetActive(newPlayer.IsEnabled);

        Debug.Log(newPlayer);
    }
}

