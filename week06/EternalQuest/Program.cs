class Program
{
    static void Main()
    {
        GoalManager manager = new GoalManager();
        while (true)
        {
            Console.WriteLine($"\nCurrent Score: {manager.GetScore()} | Level: {manager.GetScore() / 1000}");
            Console.WriteLine("1. Create Goal\n2. List Goals\n3. Record Event\n4. Save\n5. Load\n6. Quit");
            Console.Write("Choose option: ");
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                Console.WriteLine("Select goal type:\n1. Simple\n2. Eternal\n3. Checklist\n4. Negative");
                int type = int.Parse(Console.ReadLine());

                Console.Write("Name: ");
                string name = Console.ReadLine();
                Console.Write("Description: ");
                string desc = Console.ReadLine();
                Console.Write("Points: ");
                int points = int.Parse(Console.ReadLine());

                switch (type)
                {
                    case 1:
                        manager.CreateGoal(new SimpleGoal(name, desc, points));
                        break;
                    case 2:
                        manager.CreateGoal(new EternalGoal(name, desc, points));
                        break;
                    case 3:
                        Console.Write("Target times: ");
                        int target = int.Parse(Console.ReadLine());
                        Console.Write("Bonus: ");
                        int bonus = int.Parse(Console.ReadLine());
                        manager.CreateGoal(new ChecklistGoal(name, desc, points, target, bonus));
                        break;
                    case 4:
                        manager.CreateGoal(new NegativeGoal(name, desc, points));
                        break;
                }
            }
            else if (choice == "2") manager.ListGoals();
            else if (choice == "3")
            {
                manager.ListGoals();
                Console.Write("Which goal? ");
                int index = int.Parse(Console.ReadLine()) - 1;
                manager.RecordEvent(index);
            }
            else if (choice == "4")
            {
                Console.Write("Filename: ");
                manager.Save(Console.ReadLine());
            }
            else if (choice == "5")
            {
                Console.Write("Filename: ");
                manager.Load(Console.ReadLine());
            }
            else if (choice == "6") break;
        }
    }
}
