using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SuperHeroes.Models
{
    public class SuperHero
    {
        [Key]
        public int Id { get; set; }
        public string name { get; set; }
        public string alterEgo { get; set; }
        public string primaryAbility { get; set; }
        public string secondaryAbility { get; set; }
        public string catchphrase { get; set; }
    }
}
