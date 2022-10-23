using System;
using System.Linq;
using System.Collections.Generic;
namespace Key_Revolver
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int bulletPirce = int.Parse(Console.ReadLine());
            int gunBarrelSize = int.Parse(Console.ReadLine());
            int[] bullets = Console.ReadLine().Split(' ').Select(bullet => int.Parse(bullet)).ToArray();
            int[] locks = Console.ReadLine().Split(' ').Select(locks => int.Parse(locks)).ToArray();
            int intelligenceValue = int.Parse(Console.ReadLine());
            Stack<int> stack = new Stack<int>(bullets);
            int countBulletsUsed = 0;
            Queue<int> queue = new Queue<int>(locks);
            while (queue.Count>0&&stack.Count>0)
            {
                int currentLock=queue.Peek();
                int currentBullet=stack.Pop();
                countBulletsUsed++;
                if (currentBullet<=currentLock)
                {
                    Console.WriteLine("Bang!");
                    queue.Dequeue();
                }
                else if(currentBullet>currentLock)
                {
                    Console.WriteLine("Ping!");
                }
                if ((countBulletsUsed % gunBarrelSize == 0)&&stack.Count>0)
                {
                    Console.WriteLine("Reloading!");
                }
            }
            int totalBuletsPrice = bulletPirce * countBulletsUsed;
            if (stack.Count==0&&queue.Count>0)
            {
                Console.WriteLine($"Couldn't get through. Locks left: {queue.Count}");
            }
            else 
            {
                Console.WriteLine($"{stack.Count} bullets left. Earned ${intelligenceValue-totalBuletsPrice}");
            }
        }
    }
}
