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
                this.name = name ; 
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


        }
    }

}
