using System;
using System.Collections.Generic;
using System.Text;

namespace AnimalAdoption.Common.Logic
{
    public class AnimalService
    {
        public Animal[] ListAnimals => new Animal[] {
            new Animal { Id = 1, Name = "dog", Age = 50, Description = "The dog or domestic dog (Canis familiaris)[4] is a domesticated descendant of the wolf, characterized by an upturning tail." },
            new Animal { Id = 2, Name = "cat", Age = 50, Description = "The cat (Felis catus) is a domestic species of small carnivorous mammal." },
            new Animal { Id = 3, Name = "horse", Age = 50, Description = "The horse or domestic horse (Equus caballus or Equus ferus caballus)[2][3] is a domesticated one-toed hoofed mammal." },
        };
    }
}
