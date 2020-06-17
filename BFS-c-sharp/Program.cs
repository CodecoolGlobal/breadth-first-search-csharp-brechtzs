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
            var fromUser = users[1];
            var toUser = users[3];
            int distance = 4;


            Dictionary<UserNode, int> distanceFromRoot = Traverse(fromUser, toUser);
            foreach (KeyValuePair<UserNode, int> element in distanceFromRoot)
            {
                if (element.Key.Equals(toUser))
                {
                    Console.WriteLine($"Minimum Distance between {fromUser} and {toUser}: {element.Value}");
                }

                if(element.Value == distance)
                {
                    Console.WriteLine($"{element.Key} is {distance} steps from {fromUser}");
                }
                
            }
            Console.ReadLine();
        }


        public static Dictionary<UserNode, int> Traverse(UserNode fromUser, UserNode toUser)
        {
            Queue<UserNode> queue = new Queue<UserNode>();
            HashSet<UserNode> visitedUser = new HashSet<UserNode>();
            Dictionary<UserNode, int> distanceFromRoot = new Dictionary<UserNode, int>();

            queue.Enqueue(fromUser);
            visitedUser.Add(fromUser);
            distanceFromRoot.Add(fromUser, 0);

            while (queue.Count > 0)
            {
                UserNode user = queue.Dequeue();
               
                foreach (var friend in user.Friends)
                {
                    if (!visitedUser.Contains(friend))
                    {
                        queue.Enqueue(friend);
                        visitedUser.Add(friend);
                        distanceFromRoot.Add(friend, distanceFromRoot[user] + 1);
                    }
                }
            }
            return distanceFromRoot;
        }
    }
}
