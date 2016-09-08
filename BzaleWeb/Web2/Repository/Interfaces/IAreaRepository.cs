using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web2.Repository.Interfaces
{
    public interface IAreaRepository<T> :IDisposable
    {
        List<T> GetAll_MainAreas();

        List<T> GetAll_SubArea(T mainarea);

        T GetSpecificArea(int areaid);
        T GetSpecificArea(string areaname);
        void AddNewArea(T area);
        T UpdateArea(T area);
    }
}
