using CsvHelper;
using CZD.Repository;
using CZD.Repository.Podaci;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CZD.Service.Podaci
{
    public class PodaciService : IPodaciService
    {
        private readonly IPodaciRepository _podaciRepository;
        private readonly IUnitOfWork _unitOfWork;

        public PodaciService(IPodaciRepository podaciRepository, IUnitOfWork unitOfWork)
        {
            _podaciRepository = podaciRepository;
            _unitOfWork = unitOfWork;
        }

        public List<Model.Podaci.DTO.PodaciDTO> UcitajDatoteku(string path)
        {
            StreamReader reader = new StreamReader(path, Encoding.Default);
            var config = new CsvHelper.Configuration.Configuration
            {
                HasHeaderRecord = false,
                Delimiter = ";"
            };

            using (CsvReader csvReader = new CsvReader(reader, config, true))
            {
                return csvReader.GetRecords<Model.Podaci.DTO.PodaciDTO>().ToList();
            }
        }

        public void SpremiDatoteku(List<Model.Podaci.DTO.PodaciDTO> podaciDTO)
        {
            foreach (var row in podaciDTO)
            {
                var isValid = int.TryParse(row.PostanskiBroj, out int result);
                if (isValid)
                {
                    _podaciRepository.InsertWithProcedure(new Model.Podaci.Podaci
                    {
                        Ime = row.Ime,
                        Prezime = row.Prezime,
                        Grad = row.Grad,
                        PostanskiBroj = int.Parse(row.PostanskiBroj),
                        Telefon = row.Telefon
                    });
                }
            }
        }
    }
}
