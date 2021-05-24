using UnityEditor;

public class MenuItems
{
	[MenuItem("Geekbrains/Создание объектов")]
	private static void MenuOption()
	{
		EditorWindow.GetWindow(typeof(MyWindow), false, "Geekbrains");
	}
}
