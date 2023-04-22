using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediaLink.Application.Common.Mappings;
using MediaLink.Domain.Entities;

namespace MediaLink.Application.Educations.Queries.SearchEducation;
public class EducationDto : IMapFrom<Education>
{
    public int Id { get; set; }
    public string? Level { get; set; }
}
