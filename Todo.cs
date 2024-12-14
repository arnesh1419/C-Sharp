using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Dictionary<string, int> candidates = new Dictionary<string, int>()
        {
            { "EPS", 0 },
            { "MKS", 0 },
            { "KA", 0 }
        };

        int totalVotes = 0;

        int choice;
        do
        {
            Console.Clear();
            Console.WriteLine("Simple Voting System");
            Console.WriteLine("====================\n");
            Console.WriteLine("1. Cast a Vote");
            Console.WriteLine("2. View Results");
            Console.WriteLine("3. Exit");
            Console.Write("\nEnter your choice: ");

            if (int.TryParse(Console.ReadLine(), out choice))
            {
                switch (choice)
                {
                    case 1:
                        CastVote(candidates, ref totalVotes);
                        break;
                    case 2:
                        ViewResults(candidates, totalVotes);
                        break;
                    case 3:
                        Console.WriteLine("\nThank you for using the Voting System!");
                        break;
                    default:
                        Console.WriteLine("\nInvalid choice. Please try again.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("\nPlease enter a valid number.");
            }

            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();

        } while (choice != 3);
    }

    static void CastVote(Dictionary<string, int> candidates, ref int totalVotes)
    {
        Console.Clear();
        Console.WriteLine("Cast Your Vote");
        Console.WriteLine("==============\n");

        int candidateNumber = 1;
        foreach (var candidate in candidates)
        {
            Console.WriteLine($"{candidateNumber}. {candidate.Key}");
            candidateNumber++;
        }

        Console.Write("\nEnter the number of the candidate you want to vote for: ");
        if (int.TryParse(Console.ReadLine(), out int vote) && vote > 0 && vote <= candidates.Count)
        {
            string chosenCandidate = GetCandidateByIndex(candidates, vote);
            candidates[chosenCandidate]++;
            totalVotes++;
            Console.WriteLine($"\nYour vote for '{chosenCandidate}' has been recorded.");
        }
        else
        {
            Console.WriteLine("\nInvalid choice. Please try again.");
        }
    }

    static void ViewResults(Dictionary<string, int> candidates, int totalVotes)
    {
        Console.Clear();
        Console.WriteLine("Voting Results");
        Console.WriteLine("==============\n");

        if (totalVotes == 0)
        {
            Console.WriteLine("No votes have been cast yet.");
        }
        else
        {
            foreach (var candidate in candidates)
            {
                double percentage = (double)candidate.Value / totalVotes * 100;
                Console.WriteLine($"{candidate.Key}: {candidate.Value} votes ({percentage:F2}%)");
            }
        }
    }

    static string GetCandidateByIndex(Dictionary<string, int> candidates, int index)
    {
        int currentIndex = 1;
        foreach (var candidate in candidates)
        {
            if (currentIndex == index)
                return candidate.Key;
            currentIndex++;
        }
        return null;
    }
}
