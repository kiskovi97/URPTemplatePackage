using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace URPTemplate.Database
{
    public interface IFileLoader
    {
        string GetData(string lPath);
        void SaveData(string lPath, string lFullString);
    }
}
