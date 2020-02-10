﻿using DataService.Interfaces;

namespace DataService.Models
{
    public partial class Dogs : IEntity
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
