using System;
using System.ComponentModel.DataAnnotations;

namespace PermAdminAPI.DTOs;

public class RegisterDTO
{
    [Required]
    public required string Username { get; set; }
    [Required]
    public required string Password {get; set;  }
}