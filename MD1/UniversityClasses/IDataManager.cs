using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityClasses
{
    public interface IDataManager
    {
        string Print();
        void Save(string path);
        void Load(string path);
        void CreateTestData();
        void Reset();
    }
}
