using UnityEditor;
using UnityEngine;

public class MyWindow : EditorWindow
{
	public static GameObject ObjectInstantiate;
	public string _nameObject = "Object";
	public bool _groupEnabled;
	public bool _randomColor = true;
	public int _countObject = 1;
	public int _shift = 1;
	private static int _offset;

	private void OnGUI()
	{
		GUILayout.Label("Базовые настройки", EditorStyles.boldLabel);
		ObjectInstantiate =
			EditorGUILayout.ObjectField("Объект который хотим вставить",
					ObjectInstantiate, typeof(GameObject), true)
				as GameObject;
		_nameObject = EditorGUILayout.TextField("Имя объекта", _nameObject);
		_groupEnabled = EditorGUILayout.BeginToggleGroup("Дополнительные настройки", _groupEnabled);
		_randomColor = EditorGUILayout.Toggle("Случайный цвет", _randomColor);
		_countObject = EditorGUILayout.IntSlider("Количество объектов", _countObject, 1, 5);
		_shift = EditorGUILayout.IntSlider("Смещение", _shift, 1, 10);
		var button = GUILayout.Button("Создать объекты");
		if (button)
		{
			if (ObjectInstantiate)
			{
				GameObject root = new GameObject("Root");
				for (int i = 0; i < _countObject; i++)
				{
					Vector3 pos = new Vector3(i * _shift, 0, 0);
					GameObject temp = Instantiate(ObjectInstantiate, pos, Quaternion.identity);
					temp.name = _nameObject + "(" + i + ")";
					temp.transform.parent = root.transform;
					var tempRenderer = temp.GetComponent<Renderer>();
					if (tempRenderer && _randomColor)
					{
						tempRenderer.material.color = Random.ColorHSV();
					}
				}
				root.transform.position = new Vector3(0, _offset++);
			}
		}
	}
}
