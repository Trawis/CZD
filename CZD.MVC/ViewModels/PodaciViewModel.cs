using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CZD.ViewModels
{
    public class PodaciViewModel
    {
        public List<Model.Podaci.DTO.PodaciDTO> Podaci { get; set; }
    }
}