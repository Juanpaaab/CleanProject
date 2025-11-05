using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanCodeApp.Application.DTOs.Request
{
    public class UserReqDto
    {
        public string Name { get; set; } = default!;
        public string Email { get; set; } = default!;
    }

    public class UserUpdateReqDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = default!;
        public string Email { get; set; } = default!;
    }
}
