﻿using MediatR;
using System;

namespace DevFreela.Aplication.Commands.CreateUser
{
    public class CreateUserCommand : IRequest<int>
    {
        public string FullName { get; set; }

        public string Email { get; set; }

        public DateTime BirthDate { get; set; }

        public string Password { get; set; }
    }
}