﻿using Shared.Domain;
using Shared.DTO_s;

namespace Logic.Interfaces;

public interface IUserLogic
{
    public Task<UserInformation> CreateAsync(UserCreationDTO dto);

    public Task<UserInformation> GetByUsernameAsync(string username);

    Task<IEnumerable<UserInformation>> GetAllAsync();
}
