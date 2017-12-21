﻿using System;

namespace DatingProj.Models
{
    public class Posts
    {

        public int Id { get; set; }
        public string Text { get; set; }
        public virtual ApplicationUser FromUser { get; set; }
        public virtual ApplicationUser ToUser { get; set; }

    }
}