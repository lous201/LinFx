﻿using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace LinFx.Extensions.Identity.Models
{
    public class IdentityUserLogin : IdentityUserLogin<string>
    {
        [StringLength(36)]
        public override string UserId { get; set; }
    }
}
