using System;

namespace GameSix
{
    namespace GameSix
    {
        public class Foe
        {
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

            public void TakeDamage (float damage )
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
            private static void Main(string[] args)
            {
                // C r e a t e a new Foe
            Foe loki = new Foe ("Loki");
            // Changed my mind . Let ’ s u s e t h e f u l l name .
            loki.SetName(" Grindalokki ");
            // Show name and h e a l t h
            Console.WriteLine($"Name is {loki.GetName()} and HP is {loki.GetHealth()}");
            }

            

        }
    }

}
