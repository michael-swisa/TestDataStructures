using TestDataStructures.Models;

internal class Program
{
    static async Task Main()
    {
        // path to json files
        string filePathDefence =
            @"C:\_kodcode2\Omar\TestDataStructures\FileJson\defenceStrategiesBalanced.json";
        string filePathThreats = @"C:\_kodcode2\Omar\TestDataStructures\FileJson\Threats.json";

        // יצירת עץ בינארי
        DefenceStrategiesBST binaryTreeProtection = new DefenceStrategiesBST();
        // טעינת הקובץ json
        binaryTreeProtection = binaryTreeProtection.LoadFromJson(filePathDefence);
        Console.WriteLine("Loaded from JSON:");
        await Task.Delay(4000);
        Console.WriteLine("Binary Tree Protection:");
        await Task.Delay(4000);
        // הדפסת העץ בינארי
        binaryTreeProtection.PrintTree();

        // יצירת רשימת איומים
        List<Threats> threats = LoadThreats.LoadFromJson(filePathThreats);
        await Task.Delay(4000);

        ActivationAttacks attack = new ActivationAttacks(filePathDefence);
        foreach (var item in threats)
        {
            await attack.StartAttack(item);
        }
    }
}
