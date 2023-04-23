using System;

namespace GameSix
{
    namespace GameSix
    {
        public class Foe
        {
            [Flags]
            enum PowerUp
            {
                Health = 1 << 0 , // 1
                Shield = 1 << 1 , // 2
            } ;

            private string name;
            private float health;
            private float shield;

            public Foe (string name)
            {
                this.name = name; 
                health = 100 ;
                shield = 0 ;
            }

            public string GetName()
            {
                return name;
            }

            public void TakeDamage (float damage)
            {
                shield -= damage ; //A variável "shield" retira a ela própria o valor de "damage"
                if (shield < 0 ) //Se o shield for menor que 0
                {
                    float damageStillToInflict = -shield; //A variável "damageStillToInflict" recebe o valor negativo de "Shield"
                    shield = 0 ; //"shield" volta a 0
                    health -= damageStillToInflict; //A variável "health" retira a ela própria o valor de "damageStillToInflict"
                    if (health < 0 ) health = 0 ; //Se a vida é menor que 0, volta a 0
                }
            }

            public float GetHealth()
            {
                return health;
            }

            public float GetShield()
            {
                return shield;
            }

            public void SetName(string _name)
            {   
                string newname = "";
                string space = " ";
                char funcspace = char.Parse(space); //como o "name[0]" é um char, tenho de fazer Parse desta variável para char
                if(_name[0] == funcspace)            //podia apenas criar uma varável char mas não estava a aceitar o espaço então tive que forçar
                {
                    for(int i = 1; i <= (_name.Length - 2); i++)
                    {
                        newname += _name[i];
                    }
                }
                if(_name[_name.Length - 1] != funcspace)
                    {
                        newname += _name[_name.Length -1];
                    }

                name = newname;
            }

            public void PickupPowerup(PowerUp _enemypower ,float numero)
            {
                if((_enemypower & PowerUp.Health) == PowerUp.Health)
                {
                    if(health + numero <= 100)   
                        health += numero;
                }

                if((_enemypower & PowerUp.Shield) == PowerUp.Shield)
                {
                    if(shield + numero <= 100)   
                        shield += numero;
                }
            }

            

            private static void Main(string[] args)
            { 
                PowerUp enemypower = 0;
                //int enemypowerup = 0;

                // C r e a t e a new Foe
                Foe loki = new Foe ("Loki");
                // Changed my mind . Let ’ s u s e t h e f u l l name .
                loki.SetName(" Grindalokki ");
                // Show name and h e a l t h
                Console.WriteLine($"Name is {loki.GetName()} and HP is {loki.GetHealth()}");

                Console.Write("How much enemies: ");
                string enemystr = Console.ReadLine();
                int enemyarraynumber = int.Parse(enemystr);

                string[] enemies = new string[enemyarraynumber];

                for (int i = 0; i < enemyarraynumber; i++)
                {
                    Console.Write($"What is the name of the {i + 1}º enemy: ");
                    enemies[i] = Console.ReadLine();
                }

                for (int i = 0; i < enemies.Length; i++)
                {
                    Console.WriteLine($"The name of the {i + 1}º enemy is {enemies[i]}");
                }

                TakeDamage(5);
                PickupPowerup(enemypower, 5);

                Console.WriteLine($"\nHealth:{this.health}\nShield:{this.shield}");

            }

            

        }
    }

}