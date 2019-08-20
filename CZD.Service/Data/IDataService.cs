using System.Collections.Generic;
using CZD.Service.DTO;

namespace CZD.Service
{
	public interface IDataService
    {
        List<DataDTO> LoadFile(string path);
        void SaveFile(List<DataDTO> podaciDTO);
    }
}
