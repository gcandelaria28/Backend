﻿using System.ComponentModel.DataAnnotations;

namespace Backend.Application.DTOs.Identity
{
    public class ForgotPasswordRequest
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}