﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using WebConsoleAPI.Models;

namespace WebConsoleAPI.Context
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext() : base("DefaultConnection") { }

        public DbSet<ConsoleModel> ConsoleMessage { get; set; }
    }
}