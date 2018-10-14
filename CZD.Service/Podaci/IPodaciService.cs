using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CZD.Service.Podaci
{
    public interface IPodaciService
    {
        List<Model.Podaci.DTO.PodaciDTO> UcitajDatoteku(string path);
        void SpremiDatoteku(List<Model.Podaci.DTO.PodaciDTO> podaciDTO);
    }
}
