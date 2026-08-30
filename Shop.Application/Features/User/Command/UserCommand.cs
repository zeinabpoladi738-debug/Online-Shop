using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Features.User.Command
{
    public class UserCommand: IRequest<bool>
    {
        [Required(ErrorMessage ="این داده الزامی است")]
        [MinLength(4)]
        public required string Name { get; set; }   

    }
}
