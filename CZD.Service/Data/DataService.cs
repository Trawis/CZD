using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using CsvHelper;
using CZD.Infrastructure;
using CZD.Model;

namespace CZD.Service
{
	public class DataService : IDataService
    {
        private readonly IDataRepository _podaciRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DataService(IDataRepository podaciRepository, IUnitOfWork unitOfWork)
        {
            _podaciRepository = podaciRepository;
            _unitOfWork = unitOfWork;
        }

        public List<DTO.DataDTO> LoadFile(string path)
        {
            StreamReader reader = new StreamReader(path, Encoding.Default);
            var config = new CsvHelper.Configuration.Configuration
            {
                HasHeaderRecord = false,
                Delimiter = ";"
            };

            using (CsvReader csvReader = new CsvReader(reader, config, true))
            {
                return csvReader.GetRecords<DTO.DataDTO>().ToList();
            }
        }

        public void SaveFile(List<DTO.DataDTO> podaciDTO)
        {
            foreach (var row in podaciDTO)
            {
                var isValid = int.TryParse(row.PostanskiBroj, out int result);
                if (isValid)
                {
                    _podaciRepository.InsertWithProcedure(new Data
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
