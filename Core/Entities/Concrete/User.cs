﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.Concrete
{
    public class User : IEntity
    {
        public int UserId { get; set; }
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        public string UserEMail { get; set; }
        public byte[] UserPasswordSalt { get; set; }
        public byte[] UserPasswordHash { get; set; }
        public bool UserStatus { get; set; }
    }
}
