using System;

class StudentResultsProcessingSystem
{
    static string[] names = new string[3];
    static string[] ids = new string[3];
    static string[] programmes = new string[3];
    static string[] levels = new string[3];
    static double[,] scores = new double[3, 5];

    static string[] courses = {
        "Programming with C#",
        "Database Systems",
        "Computer Networks",
        "Web Development",
        "Mathematics for Computing"
    };

    static bool dataEntered = false;

    static void Main(string[] args)
    {
        int choice;

        do
        {
            Console.WriteLine("\n===== STUDENT RESULTS PROCESSING SYSTEM =====");
            Console.WriteLine("1. Enter Student Results");
            Console.WriteLine("2. View Student Report");
            Console.WriteLine("3. Exit");
            Console.Write("\nChoose an option: ");

            while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > 3)
            {
                Console.Write("Invalid option. Please enter 1, 2, or 3: ");
            }

            switch (choice)
            {
                case 1:
                    EnterStudentResults();
                    break;
                case 2:
                    ViewStudentReport();
                    break;
                case 3:
                    Console.WriteLine("\nThank you for using the Student Results Processing System.");
                    break;
            }

        } while (choice != 3);
    }

    static void EnterStudentResults()
    {
        for (int i = 0; i < 3; i++)
        {
            Console.WriteLine($"\n--- Enter details for Student {i + 1} ---");

            Console.Write("Enter full name: ");
            names[i] = Console.ReadLine();

            Console.Write("Enter student ID: ");
            ids[i] = Console.ReadLine();

            Console.Write("Enter programme: ");
            programmes[i] = Console.ReadLine();

            Console.Write("Enter level: ");
            levels[i] = Console.ReadLine();

            Console.WriteLine();
            for (int j = 0; j < 5; j++)
            {
                double score;
                do
                {
                    Console.Write($"Enter score for {courses[j]}: ");
                    while (!double.TryParse(Console.ReadLine(), out score))
                    {
                        Console.WriteLine("Invalid score. Score must be between 0 and 100.");
                        Console.Write($"Enter score for {courses[j]}: ");
                    }

                    if (score < 0 || score > 100)
                        Console.WriteLine("Invalid score. Score must be between 0 and 100.");

                } while (score < 0 || score > 100);

                scores[i, j] = score;
            }
        }

        dataEntered = true;
        Console.WriteLine("\nAll student results entered successfully!");
    }

    static void ViewStudentReport()
    {
        if (!dataEntered)
        {
            Console.WriteLine("\nNo data entered yet. Please select Option 1 first.");
            return;
        }

        Console.WriteLine("\n===== STUDENT RESULTS REPORT =====");

        for (int i = 0; i < 3; i++)
        {
            double total = 0;
            for (int j = 0; j < 5; j++)
                total += scores[i, j];

            double average = total / 5;
            string grade = GetGrade(average);
            string status = average >= 50 ? "Passed" : "Failed";

            Console.WriteLine($"\nStudent Name : {names[i]}");
            Console.WriteLine($"Student ID   : {ids[i]}");
            Console.WriteLine($"Programme    : {programmes[i]}");
            Console.WriteLine($"Level        : {levels[i]}");
            Console.WriteLine();

            for (int j = 0; j < 5; j++)
                Console.WriteLine($"  {courses[j],-30}: {scores[i, j]}");

            Console.WriteLine();
            Console.WriteLine($"  Total Score  : {total}");
            Console.WriteLine($"  Average Score: {average:F1}");
            Console.WriteLine($"  Grade        : {grade}");
            Console.WriteLine($"  Status       : {status}");
            Console.WriteLine(new string('-', 45));
        }
    }

    static string GetGrade(double average)
    {
        if (average >= 80) return "A";
        if (average >= 70) return "B";
        if (average >= 60) return "C";
        if (average >= 50) return "D";
        return "F";
    }
}
