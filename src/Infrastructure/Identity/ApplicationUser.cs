﻿using System.ComponentModel.DataAnnotations.Schema;
using MediaLink.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace MediaLink.Infrastructure.Identity;

public class ApplicationUser : IdentityUser
{
    public InnerUser? User { get; set; }
}
