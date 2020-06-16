using BFS_c_sharp.Model;
using System;
using System.Collections.Generic;

namespace BFS_c_sharp
{
    class Program
    {
        static void Main(string[] args)
        {
            RandomDataGenerator generator = new RandomDataGenerator();
            List<UserNode> users = generator.Generate();

            Console.WriteLine($"Minimum Distance between {users[1]} and {users[3]}");
            Console.WriteLine(MinimumDistance(users[1], users[3]));

            Console.WriteLine($"Traverse from {users[1]}");
            Traverse(users[1]);

            /*Console.WriteLine("All Users:\n");
            foreach (var user in users)
            {
                Console.WriteLine(user);
            }

            Console.WriteLine("Done");
            Console.ReadKey();*/

        }
        public static int MinimumDistance(UserNode fromUser, UserNode toUser)
        {
            Queue<UserNode> queue = new Queue<UserNode>();
            HashSet<UserNode> visitedUser = new HashSet<UserNode>();
            queue.Enqueue(fromUser);
            visitedUser.Add(fromUser);

            while (queue.Count > 0)
            {
                UserNode user = queue.Dequeue();
                if (user.FirstName == toUser.FirstName && user.LastName == toUser.LastName)
                {
                    return visitedUser.Count - 1;
                }

                foreach (var friend in user.Friends)
                {
                    if (!visitedUser.Contains(friend))
                    {
                        queue.Enqueue(friend);
                        visitedUser.Add(friend);
                    }
                }
            }
            return visitedUser.Count - 1;
        }

        public static void Traverse(UserNode fromUser)
        {
            Queue<UserNode> traverseOrder = new Queue<UserNode>();
            Queue<UserNode> queue = new Queue<UserNode>();
            HashSet<UserNode> visitedUser = new HashSet<UserNode>();
            queue.Enqueue(fromUser);
            visitedUser.Add(fromUser);

            while (queue.Count > 0)
            {
                UserNode user = queue.Dequeue();
                traverseOrder.Enqueue(user);

                foreach (var friend in user.Friends)
                {
                    if (!visitedUser.Contains(friend))
                    {
                        queue.Enqueue(friend);
                        visitedUser.Add(friend);
                    }
                }
            }
            Console.WriteLine("Traverse order:\n");
            while (traverseOrder.Count > 0)
            {
                UserNode user = traverseOrder.Dequeue();
                Console.WriteLine(user);
            }
        }
    }
}
