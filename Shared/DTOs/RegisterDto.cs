﻿namespace Shared.DTOs;

public class RegisterDto
{
    public string Username { get; }
    public string Password { get; }
    public string PhoneNumber{ get; }
    public string Email{ get; }

    public RegisterDto(string username, string password, string phoneNumber, string email)
    {
        Username = username;
        Password = password;
        PhoneNumber = phoneNumber;
        Email = email;
    }
}