using System;
using Domain.Entities;

namespace Application.Interfaces;

public interface IAuthRepository
{
    Task Register(User user);
}
