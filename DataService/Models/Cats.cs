using DataService.Interfaces;
using System;
using System.Collections.Generic;

namespace DataService.Models
{
    public partial class Cats : IEntity
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string LifeSpan { get; set; }
        public string UniqueTraits { get; set; }
        public string Size { get; set; }
        public string Coat { get; set; }
        public string PictureUrl { get; set; }
    }
}
