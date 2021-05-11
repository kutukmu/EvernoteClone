﻿using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvernoteClone.Models
{
    public class Notebook
    {
        [PrimaryKey]
        public int Id { get; set; }
        [Indexed]
        public int UserId { get; set; }
        public string  Name { get; set; }
    }
}
