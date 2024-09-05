using TestDataStructures.Models;

internal class Program
{
    static async Task Main()
    {
        // path to json files
        string filePathDefence =
            @"C:\_kodcode2\Omar\TestDataStructures\FileJson\defenceStrategiesBalanced.json";
        string filePathDefence1 =
            @"C:\_kodcode2\Omar\TestDataStructures\FileJson\defenceStrategiesBalanced1.json";
        string filePathThreats = @"C:\_kodcode2\Omar\TestDataStructures\FileJson\Threats.json";

        // יצירת עץ בינארי
        DefenceStrategiesBST binaryTreeProtection = new DefenceStrategiesBST();
        DefenceStrategiesBST binaryTreeProtection1 = new DefenceStrategiesBST();
        // טעינת הקובץ json
        binaryTreeProtection1 = binaryTreeProtection1.LoadFromJson(filePathDefence1);
        binaryTreeProtection = binaryTreeProtection.LoadFromJsonNotBalanced(filePathDefence1);
        Console.WriteLine("Loaded from JSON:");
        await Task.Delay(4000);
        Console.WriteLine("Binary Tree Protection:");
        await Task.Delay(4000);
        // הדפסת העץ בינארי
        binaryTreeProtection.PrintTree();
        await Task.Delay(4000);
        binaryTreeProtection1.PrintTree();
        await Task.Delay(4000);

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
