using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Threading;
using Microsoft.SqlServer.Server;

namespace FlyAndShootz
{
    internal class Create
    {
        /// <summary>
        /// Készít egy objektumot egy új szálon. Objektumlista: "projectile", "enemy", "enemyprojectile".
        /// </summary>
        public static void Threading(string data)
        {
            switch (data)
            {
                case "projectile":
                    Thread ProjectileThread = new Thread(Projectile);
                    ProjectileThread.Name = "Projectile";
                    ProjectileThread.Start();
                    break;
                case "enemy":
                    Thread EnemyThread = new Thread(Enemy);
                    EnemyThread.Name = "Enemy";
                    EnemyThread.Start();
                    break;
                case "enemyprojectile":
                    Thread EnemyProjectileThread = new Thread(EnemyProjectile);
                    EnemyProjectileThread.Name = "EnemyProjectile";
                    EnemyProjectileThread.Start();
                    break;
            }
        }

        private static void Projectile()
        {
            Display.xProjPos = Display.xPos;
            Display.yProjPos = Display.yPos;
            Console.Beep(100, 100);
            while (Display.isProjectile)
            {
                Thread.Sleep(100);
                if (Display.xProjPos == 1)
                {
                    Delete.Projectile();
                }
                Display.xProjPos--;
            }
        }

        private static void Enemy()
        {
            Random EnemyMoves = new Random();
            Display.yEnemyPos = EnemyMoves.Next(1, Display.Lenght - 2);
            Display.xEnemyPos = 2;
            int EnemyNextMove;
            bool EnemyMoveDone;
            while (Display.isEnemy)
            {
                if (!Display.isEnemyProjectile && Display.yEnemyPos >= Display.yPos - 5 && Display.yEnemyPos <= Display.yPos + 5)
                {
                    Display.isEnemyProjectile = true;
                    Threading("enemyprojectile");
                }
                EnemyNextMove = EnemyMoves.Next(0, 2);
                EnemyMoveDone = false;
                new Thread(() =>
                {
                    while (Display.isProjectile)
                    {
                        if (Display.yEnemyPos == Display.yProjPos && Display.xEnemyPos == Display.xProjPos)
                        {
                            Delete.Enemy();
                            Delete.Projectile();
                            Display.KilledEnemies++;
                            Console.Beep(400, 100);
                            Thread.Sleep(1);
                            Console.Beep(1200, 100);
                        }
                        Thread.Sleep(10);
                    }

                }){ Name = "ProjectileChech" }.Start();
                if (Display.yEnemyPos == 1)
                {
                    Display.yEnemyPos++;
                    EnemyMoveDone = true;
                }
                else if (Display.yEnemyPos == Display.Lenght - 1)
                {
                    Display.yEnemyPos--;
                    EnemyMoveDone = true;
                }
                else if (EnemyNextMove == 0 && !EnemyMoveDone)
                {
                    Display.yEnemyPos--;
                }
                else if (EnemyNextMove == 1 && !EnemyMoveDone)
                {
                    Display.yEnemyPos++;
                }
                Thread.Sleep(500);
            }
        }

        private static void EnemyProjectile()
        {
            Display.xEnemyProjPos = Display.xEnemyPos;
            Display.yEnemyProjPos = Display.yEnemyPos;
            while (Display.isEnemyProjectile)
            {
                if (Display.xEnemyProjPos == Display.xPos && Display.yEnemyProjPos == Display.yPos)
                {
                    for (int i = 0; i <= 2; i++)
                    {
                        Program.isProgram = false;
                        Console.Clear();
                        Console.WriteLine("Meghaltál! Nyomj egy akármilyen gombot a folytatáshoz!");
                        Thread.Sleep(500);
                    }
                    Data.Save();
                }
                Thread.Sleep(400);
                if (Display.xEnemyProjPos == Display.Height - 1)
                {
                    Delete.EnemyProjectile();
                }
                Display.xEnemyProjPos++;
            }
        }
    }
    
    internal class Delete
    {
        /// <summary>
        /// Törli az "enemy" entitást.
        /// </summary>
        public static void Enemy()
        {
            Display.isEnemy = false;
            Display.xEnemyPos = 0;
            Display.yEnemyPos = 0;
        }

        public static void Projectile()
        {
            Display.isProjectile = false;
            Display.xProjPos = 1;
            Display.yProjPos = 0;
        }

        public static void EnemyProjectile()
        {
            Display.isEnemyProjectile = false;
            Display.xEnemyProjPos = -1;
            Display.yEnemyProjPos = 0;
        }
    }
}
