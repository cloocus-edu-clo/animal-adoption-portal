using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalAdoption.Common.Logic
{
    public class AnimalService
    {
        public Animal[] ListAnimals => new Animal[] {
            new Animal { Id = 1, Name = "여름", Age = 18, Description = "hot hot" },
            new Animal { Id = 2, Name = "가을", Age = 27, Description = "chill chill" },
            new Animal { Id = 3, Name = "겨울", Age = 29, Description = "cold cold" },
        };
    }
}
