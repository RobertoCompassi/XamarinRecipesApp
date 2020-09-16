using System;
using SQLite;

namespace GostosoDemaisApp.Models
{
    public class Account
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Email { get; set; }
    }
}
